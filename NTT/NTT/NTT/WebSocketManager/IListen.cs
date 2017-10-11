using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTT.WebSocketManager
{
    public interface IListen { }
    public interface IListen<T> : IListen
    {
        void Handle(T obj);
    }
}
