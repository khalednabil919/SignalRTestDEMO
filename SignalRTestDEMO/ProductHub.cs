using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRTestDEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRTestDEMO
{
    [HubName("product")]
    public class ProductHub : Hub
    {

        public void create(string name, double price)
        {
            Context db = new Context();
            var id  = Guid.NewGuid();
            var product = new Product { Id = id, Name = name, Price = price };
            db.Products.Add(product);
            db.SaveChanges();
            Clients.All.createProduct(id, name, price);
            return;
        }
    }
}