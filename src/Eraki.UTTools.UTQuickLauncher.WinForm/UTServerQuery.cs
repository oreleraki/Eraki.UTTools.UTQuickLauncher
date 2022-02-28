using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Eraki.UTTools.UTQuickLauncher.WinForm
{
    public class UTServerQuery
    {
        private static UdpClient _udpClient = new UdpClient(0);
        public static readonly byte[] StatusMessageBytes = Encoding.UTF8.GetBytes(@"\info\"); // hex: BitConverter.ToString(statusMessage).Replace("-", "");

        private bool _running = false;
        private Thread _receiveThread;
        private ConcurrentDictionary<string, UTServerEntryItem> _lockStore = new ConcurrentDictionary<string, UTServerEntryItem>();

        public delegate void OnReceiveEventHandler(object sender, OnReceiveEventArgs e);
        public event OnReceiveEventHandler OnReceiveEvent;

        public UTServerQuery()
        {
            _receiveThread = new Thread(ReceiveLoop);
            _receiveThread.Priority = ThreadPriority.BelowNormal;
            //_receiveThread.IsBackground = false;
            _running = true;
            _receiveThread.Start();
        }

        public void Close()
        {
            _running = false;
            _udpClient.Close(); // needed?
        }

        private void ReceiveLoop()
        {
            while (_running)
            {
                var tempIPEndPoint = new IPEndPoint(IPAddress.Any, 0);
                if (_udpClient.Available > 0)
                {
                    var response = _udpClient.Receive(ref tempIPEndPoint);

                    if (_lockStore.TryGetValue(tempIPEndPoint.ToString(), out UTServerEntryItem lockItem))
                    {
                        var responseParsed = UTServerResponse.Parse(response);
                        lockItem.Response = responseParsed;
                        lockItem.WaitHandler.Set();
                    }
                }

                Thread.Sleep(50);
            }
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