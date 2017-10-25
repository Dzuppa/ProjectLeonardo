using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace NTT.WebSocketManager
{
    class WebSocketManager
    {
        private EventAggregator eventAggregator;
        private WebSocket webSocket;
        private static WebSocketManager _wbm;

        private WebSocketManager() { }

        /// <summary>
        /// Factory with singleton style inside
        /// </summary>
        /// <param name="listen"></param>
        /// <returns></returns>
        public static WebSocketManager InitializeWebSocketManager(IListen listen)
        {
            if (_wbm == null)
            {
                _wbm = new WebSocketManager(listen);
            }
            else
            {
                _wbm.eventAggregator.Subscribe(listen);
            }
            return _wbm;
        }
        
        /// <summary>
        /// Private constructor
        /// </summary>
        /// <param name="listen"></param>
        private WebSocketManager(IListen listen)
        {
            this.eventAggregator = new EventAggregator();

            this.eventAggregator.Subscribe(listen);

            webSocket = new WebSocket("ws://dev02-frt-srv1.mngt.dev:7073/GFInotificationserver/wsEndpoint/topic/receiveMessage");
            

            webSocket.SetProxy("https://10.29.140.134:8080", "ditteesterne\\mtroia", "password3");

            webSocket.OnOpen += (sender, e) =>
            {
                Signal(3);
            };

            webSocket.OnMessage += (sender, e) =>
            {
                Signal(e.Data);
            };

            webSocket.OnError += (sender, e) =>
            {
                throw new Exception("Error on websocket");
            };

            webSocket.OnClose += (sender, e) =>
            {
                
            };

            webSocket.Connect();

        }



        public void Signal(object obj)
        {
            this.eventAggregator.Publish(obj);
        }
    }
}
