using DatingApp.Api.Entities;
using DatingApp.Api.Model;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        public ApiControllerBase()
        {

        }
    }
}
