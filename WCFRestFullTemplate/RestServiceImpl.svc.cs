using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;

namespace WCFRestFullTemplate
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RestServiceImpl" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RestServiceImpl.svc or RestServiceImpl.svc.cs at the Solution Explorer and start debugging.
    public class RestServiceImpl : IRestServiceImpl
    {
        public string XMLData(string id)
        {
            return "You requested product " + id;
        }

        public string DoWork()
        {
//            var product = new Product {Name = "aaa", Address = "bbb"};
//            return JsonConvert.SerializeObject(product);
            return "bcd";
        }
    }
    public class Product
{
  public   string Name { get; set; }
  public string Address { get; set; }
}
}
