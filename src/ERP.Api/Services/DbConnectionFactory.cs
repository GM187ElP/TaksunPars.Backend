using ERP.Api.DTOs;
using Npgsql;

namespace ERP.Api.Services;

public class DbConnectionStringFactory
{
    public static string BuildConnectionString(IHostEnvironment env, DbData db)
    {
        bool isDev = env.IsDevelopment();

        try
        {
            var local = new NpgsqlConnectionStringBuilder
            {
                Host = db.LocalHost,
                Database = isDev ? db.LocalDatabaseDev : db.LocalDatabaseProd,
                Username = db.LocalUsername,
                Password = db.LocalPassword,
                Port = 5432,
                Pooling = true
            };

            using var test = new NpgsqlConnection(local.ConnectionString);
            test.Open();
            Console.WriteLine("Connected to local database");
            return local.ConnectionString;
        }
        catch
        {
            var neon = new NpgsqlConnectionStringBuilder
            {
                Host = isDev ? db.NeonHostDev : db.NeonHostProd,
                Database = db.NeonDatabase,
                Username = db.NeonUsername,
                Password = isDev ? db.NeonPasswordDev : db.NeonPasswordProd,

                Port = 5432,
                SslMode = SslMode.Require,
                TrustServerCertificate = true,
                ChannelBinding = ChannelBinding.Require
            };

            using var test = new NpgsqlConnection(neon.ConnectionString);
            test.Open();
            Console.WriteLine("Connected to Neon database");
            return neon.ConnectionString;
        }
    }

}
