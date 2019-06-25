using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureDemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsInfoController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public ClaimsInfoController(DemoDbContext context)
        {
            _context = context;
        }


    }
}