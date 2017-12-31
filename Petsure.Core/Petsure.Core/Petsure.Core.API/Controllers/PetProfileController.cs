using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetSure.Core.Services;
using PetSure.Core.Services.Interfaces;
using PetSure.Core.Common;
using Newtonsoft.Json;

namespace PetSure.Core.API.Controllers
{
    [Route("api/[controller]")]
    public class PetProfileController : Controller
    {
        IPetProfileService petProfileService = new PetProfileService();
        // GET api/petprofile
        [HttpGet]
        public JsonResult Get()
        {
            var results = JsonConvert.SerializeObject(petProfileService.GetAllPetProfile());
            return Json(results);
        }

        // GET petprofile/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/petprofile
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/petprofile/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/petprofile/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
