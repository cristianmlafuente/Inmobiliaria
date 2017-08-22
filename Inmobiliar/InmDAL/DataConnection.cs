using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmDAL
{
    public class DataConnection : IDisposable
    {
        private IDbConnection _connection;

        protected IDbConnection Connection
        {
            get
            {
                if (_connection.State != ConnectionState.Open && _connection.State != ConnectionState.Connecting)
                    _connection.Open();

                return _connection;
            }
        }
        public DataConnection(string dataBaseName)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            stopWatch.Restart();
            try
            {
                _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AySConexionDesarrollo"].ConnectionString);
            }
            catch (Exception ex)
            {
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}", ts.Seconds, ts.Milliseconds / 10);
            }
            finally
            { stopWatch.Stop(); }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string entornoEjecucion { get; set; }
    }
}
