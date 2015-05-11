using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.CSharp.Core.ApplicationServices;

namespace TemplateSourceCode.Controllers
{
    public class CSharpController : Controller
    {
        private ICollectionTmp _collectionTmp;
        private ICSharpAdvance cSharpAdvance;

        public CSharpController(ICollectionTmp collectionTmp,ICSharpAdvance cSharpAdvance)
        {
            this._collectionTmp = collectionTmp;
            this.cSharpAdvance = cSharpAdvance;
        }

        //
        // GET: /CSharp/
        public ActionResult Index()
        {
            return View();
        }
      
        [HttpPost]
        public string GetData()
        {
            try
            {
                return _collectionTmp.MoveNext();
            }
            catch (Exception)
            {
                //dfs
                return "avc";
            }
            
        }
	}

}