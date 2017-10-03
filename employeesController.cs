using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using System.Threading;
using System.Web.Http.Cors;

namespace WebApplication1.Controllers
{
    public class employeesController : ApiController
    {
        
        public HttpResponseMessage Get()
        {
            using (EmployeeDBEntities edb = new EmployeeDBEntities())
            {
                string usrnme = Thread.CurrentPrincipal.Identity.Name;
                switch (usrnme.ToLower())
                {
                    case "male":
                        return Request.CreateResponse(HttpStatusCode.OK, edb.Employees.Where(x => x.Gender.ToLower() == "male").ToList());

                    case "female":
                        return Request.CreateResponse(HttpStatusCode.OK, edb.Employees.Where(x => x.Gender.ToLower() == "female").ToList());

                    default:
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }


        }
    }
}
