using System.Web.Http;
using API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace API.Controllers
{
    public class StatusController : ApiController
    {
        [HttpPost]
        public void Index(Status status)
        {
            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();



            var socket = SocketHelper.GetSocket();
            socket.Emit("status", JsonConvert.SerializeObject(status, settings));
        }
    }
}