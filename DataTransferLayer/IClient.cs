using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferLayer
{
    public interface IClient
    {
        string Receive();
        void Send(string text);
    }
}
