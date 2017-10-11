using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTT.WebSocketManager
{
    class EventAggregator
    {
        private List<IListen> subscribers = new List<IListen>();

        public void Subscribe(IListen model)
        {
            this.subscribers.Add(model);
        }

        public void Unsubscribe(IListen model)
        {
            this.subscribers.Remove(model);
        }

        public void Publish<T>(T message)
        {
            foreach (var item in this.subscribers.OfType<IListen<T>>())
            {
                item.Handle(message);
            }
        }
    }
}
