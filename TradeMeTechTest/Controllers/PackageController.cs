using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TradeMeTechTest.Models;

namespace TradeMeTechTest.Controllers
{

    public class PackageController : ApiController
    {
        private readonly IPackage _IPackage;

        // dependency injector
        public PackageController(IPackage iPackage)
        {
            _IPackage = iPackage;
        }

        /// <summary>
        ///  Web API
        /// </summary>
        /// <param name="PackageImput">{ int lenght : int breadth : int height : double weight} </param>
        /// <returns>Returns a Json with the appropriate type of packaging and with the lowest cost</returns>
        [System.Web.Http.HttpPost]        
        public string GetPackage(PackageImput PackageImput)
        {
            var result = _IPackage.GetBestPackage(PackageImput.lenght, PackageImput.breadth, PackageImput.height, PackageImput.weight);
            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Serialize(result);
        }
        
    }

}



