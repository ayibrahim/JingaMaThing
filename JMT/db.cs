using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JMT
{
    public partial class db : DbContext
    {
        //SqlConnection con;
        //public db()
        //{
        //    var configuration = GetConfiguration();
        //    con = new SqlConnection(configuration.GetSection("Data").GetSection("ConnectionString").Value);
        //}
        //public IConfigurationRoot GetConfiguration()
        //{
        //    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //    return builder.Build();
        //}

    }
}
