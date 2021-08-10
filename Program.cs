using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebCampeonato
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();


        private static DbProviderFactory GetFactory()
        {
            // register SqlClientFactory in provider factories
            DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", SqlClientFactory.Instance);

            return DbProviderFactories.GetFactory("Microsoft.Data.SqlClient");
        }

        /* consulta para o Resultado do Campeonato */
        public DataTable ConsultaResultado()
        {
            using (var conn=SqlClientFactory.Instance.CreateConnection())
            {
                conn.ConnectionString = "Server = (localdb)\\MSSQLLocalDB; Database = Campeonato; Trusted_connection = True; MultipleActiveResultSets = True";
                using (var cmd=conn.CreateCommand())
                {
                    cmd.CommandText = " Select nome, sum(vitorias) vitorias, sum(empates) as empates, sum(derrotas) as derrotas,sum(gp) as golsPro,sum(gc) as golsContra,sum(gp - gc) as saldodeGol, sum(vitorias + empates + derrotas) as qtdjogos,sum(vitorias * 3 + empates) as PontosGanhos From Time group by nome";
                    conn.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));

                    return dt;
                }
            }
        }
    }
}
