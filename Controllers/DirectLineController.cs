using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EmergencyServicesBot.Controllers
{
    public class DirectLineController : ApiController
    {

        public async Task<BotSrc> Get()
        {
            var botName = ConfigurationManager.AppSettings["BotName"];
            var directLineSecret = ConfigurationManager.AppSettings["DirectLineSecret"];

            return (new BotSrc() { BotName = botName, DirectLineSecret = directLineSecret });
        }
    }

    public class BotSrc
    {
        public string BotName { get; set; }
        public string DirectLineSecret { get; set; }
    }
}
