using FileDefender_MAUI.Service;
using Microsoft.Maui.Essentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileDefender_MAUI.Platforms.Android.Service
{
    internal class NetworkConnection : INetworkConnection
    {
        //public bool IsConnected;

        public bool CheckNetworkConnection()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                // Connection to internet is available
                return true;
            }
            return false;
        }
    }
}
