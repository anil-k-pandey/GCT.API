using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GCT.API.Models;
using Newtonsoft.Json;

namespace GCT.API.Controllers
{
    public class LoginController : ApiController
    {
        GCTEntities DB = new GCTEntities();

        // GET: api/Login
        public IEnumerable<string> Get()
        {
            User user = new User();

            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public User GetUser(int id)
        {
            return DB.Users.Where(x => x.UserId == id).FirstOrDefault();
        }

        // POST: api/Login
        public string Login(Login model)
        {
            var response = new object();
            var user = DB.Users.Where(x => x.UserName == model.UserName && x.Password == model.Password).FirstOrDefault();
            if (user != null)
            {
                response = new
                {
                    ID = user.UserId.ToString(),
                    Name = user.UserName.ToString()
                };
            }
            else {
                response = new
                {
                    ID = "0",
                    Name = string.Empty
                };
            }
            return JsonConvert.SerializeObject(response);
        }

    

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
