using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Technics.com.Models;

namespace Technics.com.Services
{
    public class ServiceUser
    {
        private ISession session;

        public ServiceUser(IHttpContextAccessor accessor)
        {
            this.session = accessor.HttpContext.Session;
        }

        public void SetUser(User user)
        {
            var jsonUser =  Newtonsoft.Json.JsonConvert.SerializeObject(user);
            session.SetString("User", jsonUser);
        }

        public User GetUser()
        {
            var sess = session.GetString("User");

            if (string.IsNullOrEmpty(sess))
                return null;

            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(sess);
            return obj;
        }

        public void DeleteUser()
        {
            session.SetString("User", string.Empty);
        }

        public void SetTemporaryToken(string token)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(token);
            session.SetString("token", json);
        }

        public string GetTemporaryToken()
        {
            var token = session.GetString("token");

            if (token == null)
                return null;

            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(token);
            return obj;
        }

        public void DeleteTemporaryToken()
        {
            session.SetString("token", string.Empty);
        }

        public void SetManufacturers(long id)
        {
            var sess = session.GetString("manufacturers");
            List<long> obj = new List<long>();

            if (!string.IsNullOrEmpty(sess))
            {
                obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<long>>(sess);
                obj.Add(id);
            }
            else
            {
                obj.Add(id);             
            }

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            session.SetString("manufacturers",json); 
        }

        public void DeleteManufacturesId()
        {
            session.SetString("manufacturers",string.Empty);
        }

        public List<long> GetManufacturers()
        {
            List<long> obj = new List<long>();
            var sess = session.GetString("manufacturers");

            if (!string.IsNullOrEmpty(sess))
                obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<long>>(sess);
            
            return obj;
        }

        public bool IsAllowedToSetManufacturerById(long id)
        {
            var sess = session.GetString("manufacturers");

            if (!string.IsNullOrEmpty(sess))
            {
                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<long>>(sess);

                foreach (var item in obj)
                    if (item == id)
                    {
                        obj.Remove(item);
                        string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                        session.SetString("manufacturers", json);
                        return false;
                    }
            }

            return true;
        }
    }
}
