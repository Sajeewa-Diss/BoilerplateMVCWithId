using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoilerplateMVCWithId.Data;
using BoilerplateMVCWithId.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BoilerplateMVCWithId
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyApiController : ControllerBase
    {
        private readonly IConfiguration _config; //
        //private readonly PositionOptions _options;
        private ApplicationDbContext _db;

        //public MyApiController(IOptions<PositionOptions> options)
        public MyApiController(IConfiguration config, ApplicationDbContext db)
        
        {
            //_options = options.Value;
            _config = config;
            _db = db;
        }

        // GET: api/MyApi
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var number = _config.GetValue<int>("NumberKey", 99); //if NumberKey isn't found in the configuration, the default value of 99 is used
            string s = "";
            //use GetSection.Exists and GetChildren to check for and return subsections.
            /*
            var selection = _config.GetSection("section2");
            if (!selection.Exists())
            {
                throw new System.Exception("section2 does not exist.");
            }
            var children = selection.GetChildren();
            foreach (var subSection in children)
            {
                int i = 0;
                var key1 = subSection.Key + ":key" + i++.ToString();
                s += selection[key1];               //a value is returned using the Key in such an expression.
            }
            */
             if(_db.TestValues.Count() == 0)
            {
                return new string[] { "testvalue has no rows" };
            }


            //return new string[] { "value1", "value2" };
            //return new string[] { _options.Title + _options.Name };
            return new string[] { _config["Position:Name"]};


        }

        // GET: api/MyApi/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MyApi
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/MyApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
