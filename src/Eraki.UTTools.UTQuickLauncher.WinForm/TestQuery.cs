using System;
using System.Net;

namespace Eraki.UTTools.UTQuickLauncher.WinForm
{
    public class TestQuery
    {
        internal void Query()
        {
            var clientIPEndPoint1 = new IPEndPoint(IPAddress.Parse("81.169.240.101"), 7778); // Barbies
            var clientIPEndPoint2 = new IPEndPoint(IPAddress.Parse("212.129.59.81"), 3001); // ComboGib MediaHost
            var clientIPEndPoint3 = new IPEndPoint(IPAddress.Parse("66.85.80.155"), 7798); // NFR

            var utServerQuery = new UTServerQuery();
            var responseEndPoint3 = utServerQuery.Query(clientIPEndPoint3);
            var responseEndPoint1 = utServerQuery.Query(clientIPEndPoint1);
            var responseEndPoint2 = utServerQuery.Query(clientIPEndPoint2);

            //Task.Run(async () =>
            //{
            //    //var listenIPEndPoint = new IPEndPoint(IPAddress.Any, 7778);
            //    //var udpServer = new UdpClient(listenIPEndPoint);

            //    //var clientIPEndPoint1 = new IPEndPoint(IPAddress.Parse("81.169.240.101"), 7778); // Barbies
            //    //var clientIPEndPoint2 = new IPEndPoint(IPAddress.Parse("212.129.59.81"), 3001); // ComboGib MediaHost
            //    //var clientIPEndPoint3 = new IPEndPoint(IPAddress.Parse("66.85.80.155"), 7798); // NFR

            //    var statusMessage = Encoding.UTF8.GetBytes(@"\info\"); // hex: BitConverter.ToString(statusMessage).Replace("-", "");

            //    var udpClient = new UdpClient();
            //    var sendResult3 = udpClient.Send(statusMessage, statusMessage.Length, clientIPEndPoint3);
            //    var sendResult2 = udpClient.Send(statusMessage, statusMessage.Length, clientIPEndPoint2);
            //    var sendResult1 = udpClient.Send(statusMessage, statusMessage.Length, clientIPEndPoint1);

            //    var tempIPEndPoint = new IPEndPoint(IPAddress.Any, 0);
            //    var response2 = udpClient.Receive(ref tempIPEndPoint);
            //    var s2IpEndPoint = tempIPEndPoint.ToString();
            //    var s2 = UTServerResponse.Parse(response2);

            //    var response3 = udpClient.Receive(ref tempIPEndPoint);
            //    var s3IpEndPoint = tempIPEndPoint.ToString();
            //    var s3 = UTServerResponse.Parse(response3);

            //    var response4 = udpClient.Receive(ref tempIPEndPoint);
            //    var s4IpEndPoint = tempIPEndPoint.ToString();
            //    var s4 = UTServerResponse.Parse(response4);
            //});
        }
    }
}