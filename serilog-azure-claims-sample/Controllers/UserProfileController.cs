using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace serilog_azure_claims_sample.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {


        [HttpGet]
        public async Task<ActionResult<string>> GetUserOid()
        {

            Log.Information("GetUserProfile");

            var Oid = (User.FindFirst(c => c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier"))?.Value;

            // return Oid;
            // Task here is just to keep async and return a task not really doing anything useful
            return await Task.Run(() => Oid);
        }

    }
}