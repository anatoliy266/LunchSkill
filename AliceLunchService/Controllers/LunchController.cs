using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AliceLunchService.Models;

namespace AliceLunchService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LunchController : ControllerBase
    {
        
        // POST: api/Lunch
        [HttpPost]
        public AliceResponse Post([FromBody] AliceRequest request)
        {

        }

        
    }
}
