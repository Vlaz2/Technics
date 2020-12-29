using Microsoft.AspNetCore.Http;
using System.Collections.Generic;


namespace Technics.com.Services
{
    public  class ServiceCart
    {
        private ISession session;

        public ServiceCart(IHttpContextAccessor accessor)
        {
            session = accessor.HttpContext.Session;
        }


        public List<long> GetCartItems()
        {
            List<long> obj = new List<long>();
            var sess = session.GetString("ShopCart");

            if (!string.IsNullOrEmpty(sess))
                obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<long>>(sess);

            return obj;
        }

        public void DeleteProd(long id)
        {
            var sess = session.GetString("ShopCart");

            if (!string.IsNullOrEmpty(sess))
            {
                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<long>>(sess);
                obj.Remove(id);
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                session.SetString("ShopCart", json);
            }
        }

        public void Drop()
        {
            session.SetString("ShopCart", string.Empty);
        }

        public void SetProduct(long id)
        {
            var sess = session.GetString("ShopCart");
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
            session.SetString("ShopCart", json);
        }
    }
}
