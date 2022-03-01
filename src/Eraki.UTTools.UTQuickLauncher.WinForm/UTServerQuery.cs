using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Eraki.UTTools.UTQuickLauncher.WinForm
{
    public class UTServerQuery
    {
        public static readonly byte[] StatusMessageBytes = Encoding.UTF8.GetBytes(@"\info\"); // hex: BitConverter.ToString(statusMessage).Replace("-", "");

        private bool _running = false;
        private Thread _receiveThread;
        private UdpClient _udpClient;
        private ConcurrentDictionary<string, UTServerEntryItem> _lockStore = new ConcurrentDictionary<string, UTServerEntryItem>();

        public delegate void OnReceiveEventHandler(object sender, OnReceiveEventArgs e);
        public event OnReceiveEventHandler OnReceiveEvent;

        public UTServerQuery()
        {
            _udpClient = new UdpClient(0);
            //var freePort = ((IPEndPoint)(_udpClient.Client.LocalEndPoint)).Port;
            //var localEndPointForListen = new IPEndPoint(IPAddress.Any, 0);
            //_udpClient.ExclusiveAddressUse = false;
            //_udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            //_udpClient.Client.Bind(localEndPointForListen);
            _receiveThread = new Thread(ReceiveLoop);
            _receiveThread.Priority = ThreadPriority.BelowNormal;
            //_receiveThread.IsBackground = false;
            _running = true;
            _receiveThread.Start();
        }

        public void Close()
        {
            _running = false;
            _receiveThread.Abort();
            _udpClient.Close(); // needed?
        }

        private void ReceiveLoop()
        {
            while (_running)
            {
                var tempIPEndPoint = new IPEndPoint(IPAddress.Any, 0);
                //if (_udpClient.Available > 0)
                //{
                try
                {
                    var response = _udpClient.Receive(ref tempIPEndPoint);
                    if (response == null || response.Length == 0)
                        return;

                    if (_lockStore.TryGetValue(tempIPEndPoint.ToString(), out UTServerEntryItem lockItem))
                    {
                        var responseParsed = UTServerResponse.Parse(response);
                        lockItem.Response = responseParsed;
                        if (lockItem.ResponseCompletionTask != null)
                        {
                            lockItem.ResponseCompletionTask.SetResult(responseParsed);
                        }
                        else
                        {
                            lockItem.WaitHandler.Set();
                        }
                    }
                }
                catch (ThreadAbortException threadAbortException)
				{
                    // do nothing, thank you.
					Console.WriteLine(threadAbortException);
				}
                //}

                //Thread.Sleep(5);
            }
        }

        public async Task<UTServerResponse> QueryAsync(IPEndPoint ipEndPoint, CancellationToken cancellation = default)
		{
            var tcs = new TaskCompletionSource<UTServerResponse>();
            var sendResponse = await _udpClient.SendAsync(StatusMessageBytes, StatusMessageBytes.Length, ipEndPoint);
            cancellation.ThrowIfCancellationRequested();
            var key = ipEndPoint.ToString();
            var entryItem = new UTServerEntryItem { ResponseCompletionTask = tcs };
            _lockStore.TryAdd(key, entryItem);

            UTServerResponse response = null;
            var timeOut = Task.Delay(System.TimeSpan.FromSeconds(1));
            if (await Task.WhenAny(tcs.Task, timeOut) == timeOut)
			{
                //tcs.SetException(new TimeoutException());

            }
            else
			{
                response = (await tcs.Task);
			}
            _lockStore.TryRemove(key, out UTServerEntryItem item);
            OnReceiveEvent?.Invoke(this, new OnReceiveEventArgs { Response = response, Address = key });
            return response;
        }

        public UTServerResponse Query(IPEndPoint ipEndPoint)
        {
            var sendResponse = _udpClient.Send(StatusMessageBytes, StatusMessageBytes.Length, ipEndPoint);
            var waitEvent = new ManualResetEvent(false);
            var entryItem = new UTServerEntryItem { WaitHandler = waitEvent };
            var key = ipEndPoint.ToString();
            _lockStore.TryAdd(key, entryItem);
            var waitOneResult = waitEvent.WaitOne(System.TimeSpan.FromSeconds(1));
            
            _lockStore.TryRemove(key, out UTServerEntryItem item);
            UTServerResponse response = null;
            if (waitOneResult)
            {
                response = item.Response;
            }
            OnReceiveEvent?.Invoke(this, new OnReceiveEventArgs { Response = response, Address = key });
            return item.Response;
        }

        public UTServerResponse Query(string address, int port)
        {
            return Query(new IPEndPoint(IPAddress.Parse(address), port));
        }

        private class UTServerEntryItem
        {
			public TaskCompletionSource<UTServerResponse> ResponseCompletionTask { get; set; }
			public ManualResetEvent WaitHandler { get; set; }
            public UTServerResponse Response { get; set; }
        }

        public class OnReceiveEventArgs
        {
            public string Address { get; set; }
            public UTServerResponse Response { get; set; }
        }
    }
}