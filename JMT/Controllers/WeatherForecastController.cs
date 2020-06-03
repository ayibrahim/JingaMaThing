using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Data.SqlClient;

namespace JMT.Controllers
{
    public class WeatherForecastController : ControllerBase
    {
        //db dbop = new db();
        [HttpGet]
        [Route("api/testing")]
        public string GetTesting()
        {

            string test = "1";
            return test;
        }
        
    }
   
}
