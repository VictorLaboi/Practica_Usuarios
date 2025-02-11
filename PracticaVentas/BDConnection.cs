using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaVentas
{
    class BDConnection : IConnectBD
    {
        public string GetConnection {get;}
        public BDConnection(string connectionString)
        {
            GetConnection = connectionString ?? throw new ArgumentNullException(nameof(connectionString));  
        }
    }

}
