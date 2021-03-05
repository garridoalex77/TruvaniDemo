using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TruvaniDemo.Models;

namespace TruvaniDemo.Controllers
{
    public class ProductAPIController : ApiController
    {

        int freeshipping = 99;
        int toteBagPrice = 149;
        // GET: api/ProductAPI
        public IEnumerable<Product> Get()
        {
            var filepath = @"C:\Users\Alex\source\repos\TruvaniDemo\TruvaniDemo\Scripts\data.js";

            var data = System.IO.File.ReadAllText(filepath);


            return Newtonsoft.Json.JsonConvert.DeserializeObject<Product[]>(data);
        }

        // GET: api/ProductAPI/5
        public IEnumerable<Product> GetRecommended(int id, double cartTotal)
        {
            IEnumerable<Product> recommended;
            var products = Get();
            var cartItem = products.FirstOrDefault(x => x.id == id);
            recommended = products.Where(p => p.id != cartItem.id && p.categories.Intersect(cartItem.categories).Any() && p.price <= cartItem.price);
            if (cartTotal < freeshipping)
            {
                recommended = products.Where(p => p.id != cartItem.id && p.categories.Intersect(cartItem.categories).Any() && p.price >= (freeshipping - cartTotal));
            }
            else if (cartTotal < toteBagPrice)
            {
                recommended = products.Where(p => p.id != cartItem.id && p.categories.Intersect(cartItem.categories).Any() & p.price >= (toteBagPrice - cartTotal));
            }

            return recommended.OrderByDescending(x => cartItem.categories.Intersect(x.categories).Count());
        }

        // POST: api/ProductAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ProductAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProductAPI/5
        public void Delete(int id)
        {
        }
    }
}
