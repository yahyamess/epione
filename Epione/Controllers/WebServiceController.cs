using Domain;
using ServiceEpione;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Epione.Controllers
{
    public class WebServiceController : ApiController
    {
        RDVService rs = new RDVService();
        MedecinService ms = new MedecinService();
        [System.Web.Http.HttpGet]
        public IEnumerable<RDV> GetAllRDV()
        {
            return rs.GetAll();

        }
    }
}