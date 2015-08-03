using System.Web.Http;
using API.Models;
using Quobject.SocketIoClientDotNet.Client;

namespace API.Controllers
{
    public class MessagesController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            return "hello";
        }

        // POST api/messages
        [HttpPost]
        public void Post(Message message)
        {
            var socket = IO.Socket("http://localhost:3000");
            socket.Emit("chat message", message.Body);
        }

    }
}
