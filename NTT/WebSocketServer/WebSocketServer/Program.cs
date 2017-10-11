using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace WebSocketServer
{
    class Program
    {
        public class Laputa : WebSocketBehavior
        {
            protected override void OnOpen()
            {
                int i = 0;
                int y = 0;

                while (i.Equals(0))
                {
                    Console.Write(i + y);
                    Send((i+y).ToString());
                    y++;
                    Thread.Sleep(10000);
                }

            }

            protected override void OnMessage(MessageEventArgs e)
            {
                Send(e.Data);
            }
        }

        static void Main(string[] args)
        {
            var wssv = new WebSocketSharp.Server.WebSocketServer("ws://localhost");
            wssv.AddWebSocketService<Laputa>("/Laputa");
            wssv.Start();
            Console.ReadKey(true);
            wssv.Stop();
        }
    }
}
