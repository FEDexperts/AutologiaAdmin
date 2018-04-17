using AutologiaDataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AutologiaWebApi.Controllers
{
    public class CarManufactorModel
    {
        public int ID { get; set; }
        public string NAME { get; set; }
    }

    public class ManufactorController : ApiController
    {
        Admin admin = new Admin();

        public List<CarManufactorModel> Get()
        {
            return (from p in admin.GetCarManufactors()
                    select new CarManufactorModel
                    {
                        ID = p.ID,
                        NAME = p.NAME
                    }).ToList();
        }

        public void Delete(int id)
        {
            var i = id;
            //admin.DeleteManufactor(id);
        }
    }
}
