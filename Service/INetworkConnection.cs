using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDefender_MAUI.Service
{
    public interface INetworkConnection
    {
        //bool IsConnected { get; }
        bool CheckNetworkConnection();
    }
}
