using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RunningAppData.Entities;
using RunningAppServices.CommonFunction;
using RunningAppServices.IServices;

namespace RunningAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialDataController : ControllerBase
    {
        private readonly InitialDataService _service;

        public InitialDataController(InitialDataService service)
        {
            _service = service;
        }

        [HttpGet(Name = "Init Data")]
        public bool Get()
        {
            var result = _service.InitData();
            return result;
        }
    }
}
