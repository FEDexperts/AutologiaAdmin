using AutoMapper;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AutologiaDataAccess
{
    public class Car
    {
        public int ID { get; set; }
        public string MANUFACTOR { get; set; }
        public string MAIN_TYPE { get; set; }
        public string SUB_TYPE { get; set; }
        public string MODEL { get; set; }
        public string SUB_MODEL { get; set; }
        public string YEAR { get; set; }
        public string FUEL_TYPE { get; set; }
        public string GEER { get; set; }
        public string SEATS { get; set; }
        public string MULTI_DRIVER { get; set; }
        public string SIZE { get; set; }
        public string TRUNK { get; set; }
        public string MAINTANANCE { get; set; }
        public string FUEL_CONSUME { get; set; }
        public string SECURE { get; set; }
    }

    public class NameValuePair
    {
        public string NAME { get; set; }
        public int VALUE { get; set; }
    }

    public class Admin
    {
        public List<LookupDetails> GetLookupDetails(int mainLookup)
        {
            using (var ctx = new autologiaEntities())
            {
                return ctx.LookupDetails.Where(p => p.MAIN_LOOKUP_ID == mainLookup).ToList();
            }
        }

        public List<CarManufactors> GetCarManufactors()
        {
            using (var ctx = new autologiaEntities())
            {
                return ctx.CarManufactors.ToList();
            }
        }

        public void AddManufactor(string name)
        {
            using (var ctx = new autologiaEntities())
            {
                CarManufactors carManufactor = new CarManufactors();
                carManufactor.NAME = name;
                ctx.CarManufactors.Add(carManufactor);
                ctx.SaveChanges();
            }
        }

        public void UpdateManufactor(int id, string name)
        {
            using (var ctx = new autologiaEntities())
            {
                CarManufactors carManufactor = ctx.CarManufactors.Single(x => x.ID == id);
                carManufactor.NAME = name;
                ctx.SaveChanges();
            }
        }

        public void DeleteManufactor(int id)
        {
            using (var ctx = new autologiaEntities())
            {
                CarManufactors carManufactor = ctx.CarManufactors.Single(x => x.ID == id);
                ctx.CarManufactors.Remove(carManufactor);
                ctx.SaveChanges();
            }
        }

        public List<CarModel> GetCarModels()
        {
            using (var ctx = new autologiaEntities())
            {
                return ctx.CarModel.ToList();
            }
        }

        public List<CarModel> GetCarModels(int manufactor)
        {
            using (var ctx = new autologiaEntities())
            {
                return ctx.CarModel.Where(p => p.MANUFACTOR_ID == manufactor).ToList();
            }
        }

        public void AddCarModel(int manufactor, string name)
        {
            using (var ctx = new autologiaEntities())
            {
                CarModel carModel = new CarModel();
                carModel.MANUFACTOR_ID = manufactor;
                carModel.NAME = name;
                ctx.CarModel.Add(carModel);
                ctx.SaveChanges();
            }
        }

        public void UpdateCarModel(int id, string name)
        {
            using (var ctx = new autologiaEntities())
            {
                CarModel carModel = ctx.CarModel.Single(x => x.ID == id);
                carModel.NAME = name;
                ctx.SaveChanges();
            }
        }

        public void DeleteCarModel(int id)
        {
            using (var ctx = new autologiaEntities())
            {
                CarModel carModel = ctx.CarModel.Single(x => x.ID == id);
                ctx.CarModel.Remove(carModel);
                ctx.SaveChanges();
            }
        }

        public List<CarSubModel> GetCarSubModels()
        {
            using (var ctx = new autologiaEntities())
            {
                return ctx.CarSubModel.ToList();
            }
        }

        public List<CarSubModel> GetCarSubModels(int manufactor, int model)
        {
            using (var ctx = new autologiaEntities())
            {
                return ctx.CarSubModel.Where(p => p.MANUFACTOR_ID == manufactor && p.MODEL_ID == model).ToList();
            }
        }

        public void AddCarSubModel(int manufactor, int model, string name)
        {
            using (var ctx = new autologiaEntities())
            {
                CarSubModel carSubModel = new CarSubModel();
                carSubModel.MANUFACTOR_ID = manufactor;
                carSubModel.MODEL_ID = model;
                carSubModel.NAME = name;
                ctx.CarSubModel.Add(carSubModel);
                ctx.SaveChanges();
            }
        }

        public void UpdateCarSubModel(int id, string name)
        {
            using (var ctx = new autologiaEntities())
            {
                CarSubModel carSubModel = ctx.CarSubModel.Single(x => x.ID == id);
                carSubModel.NAME = name;
                ctx.SaveChanges();
            }
        }

        public void UpdateCarSubModelPrice(int id, int price)
        {
            using (var ctx = new autologiaEntities())
            {
                CarSubModel carSubModel = ctx.CarSubModel.Single(x => x.ID == id);
                carSubModel.PRICE = price;
                ctx.SaveChanges();
            }
        }

        public void DeleteCarSubModel(int id)
        {
            using (var ctx = new autologiaEntities())
            {
                CarSubModel carSubModel = ctx.CarSubModel.Single(x => x.ID == id);
                ctx.CarSubModel.Remove(carSubModel);
                ctx.SaveChanges();
            }
        }

        public List<Car> GetCars()
        {
            using (var ctx = new autologiaEntities())
            {
                List<Car> cars = ctx.Database.SqlQuery<Car>("spGetAllCars").OrderByDescending(p => p.ID).ToList();
                return cars;
            }
        }

        public Cars GetCar(int id)
        {
            using (var ctx = new autologiaEntities())
            {
                Cars car = ctx.Cars.SingleOrDefault(p => p.ID == id);
                return car;
            }
        }

        public List<int> GetCarMultiAnswer(int carId, int questionId)
        {
            using(var ctx = new autologiaEntities())
            {
                List<int> answers = ctx.CarMultiAnswer.Where(p => p.CAR_ID == carId && p.QUESTION_ID == questionId).SelectMany(p => new int[] { p.ANSWER_ID.Value }).ToList();
                return answers;
            }
        }

        public void DeleteCar(int id)
        {
            using(var ctx = new autologiaEntities())
            {
                Cars car = ctx.Cars.Single(p => p.ID == id);
                ctx.Cars.Remove(car);

                IQueryable<CarMultiAnswer> carMA = ctx.CarMultiAnswer.Where(p => p.CAR_ID == id);
                ctx.CarMultiAnswer.RemoveRange(carMA);

                ctx.SaveChanges();
            }
        }

        public void AddCar(int manufactor,
            int model,
            int year,
            int counry,
            int mainType,
            int subType,
            int seats,
            int? dors,
            int fuelType,
            int geer,
            int? size,
            int trunk,
            int? surface,
            int accessory,
            int? response,
            List<int> perception,
            List<int> driver,
            int maintanance,
            int fuelConsume,
            int secure,
            string description,
            int? multiDriver,
            int subModel,
            string forOppinon,
            string againstOppinon,
            string uniqueIdentifier,
            int price)
        {
            using(var ctx = new autologiaEntities())
            {
                Cars car = new Cars()
                {
                    MAIN_TYPE = mainType,
                    SUB_TYPE = subType,
                    MANUFACTOR = manufactor,
                    MODEL = model,
                    SUB_MODEL = subModel,
                    YEAR = year,
                    COUNTRY = counry,
                    SEATS = seats,
                    DORS = dors,
                    FUEL_TYPE = fuelType,
                    GEER = geer,
                    SIZE = size,
                    TRUNK = trunk,
                    ACCESSORY = accessory,
                    MAINTANANCE = maintanance,
                    FUEL_CONSUME = fuelConsume,
                    SECURE = secure,
                    MULTI_DRIVER = multiDriver,
                    OPPINION_FOR = forOppinon,
                    OPPINION_AGAINST = againstOppinon,
                    DESCRIPTION = description,
                    AVIRUT_SHETAH = surface,
                    UNIQUE_IDENTIFIER = uniqueIdentifier
                };
                ctx.Cars.Add(car);
                ctx.SaveChanges();

                var id = car.ID;

                perception.ForEach(p =>
                {
                    CarMultiAnswer carMA = new CarMultiAnswer()
                    {
                        CAR_ID = id,
                        QUESTION_ID = 10,
                        ANSWER_ID = p
                    };
                    ctx.CarMultiAnswer.Add(carMA);
                });
                driver.ForEach(p =>
                {
                    CarMultiAnswer carMA = new CarMultiAnswer()
                    {
                        CAR_ID = id,
                        QUESTION_ID = 7,
                        ANSWER_ID = p
                    };
                    ctx.CarMultiAnswer.Add(carMA);
                });
                ctx.SaveChanges();
            }
        }

        public void UpdateCar(Cars car)
        {
            using (var ctx = new autologiaEntities())
            {
                Cars carUpdate = ctx.Cars.SingleOrDefault(p => p.ID == car.ID);

                var carFields = TypeDescriptor.GetProperties(car).Cast<PropertyDescriptor>();
                var carUpdateFields = TypeDescriptor.GetProperties(carUpdate).Cast<PropertyDescriptor>();
                foreach (var field in carFields)
                {
                    var property = carUpdateFields.FirstOrDefault(prop => prop.Name == field.Name && prop.PropertyType.BaseType.Name != "Object");
                    if (property != null)
                    {
                        property.SetValue(carUpdate, field.GetValue(car));
                    }
                }

                ctx.SaveChanges();
            }
        }

        public List<Answers> GetMainTypes()
        {
            using (var ctx = new autologiaEntities())
            {
                return (from a in ctx.Answers
                        join b in ctx.QuestionsAnswers on a.ID equals b.ANSWER_ID
                        where b.QUESTION_ID == 1 && b.TYPE_ID == 0
                        select a).ToList();
            }
        }

        public List<Answers> GetSubTypes(int type)
        {
            using (var ctx = new autologiaEntities())
            {
                return (from a in ctx.Answers
                        join b in ctx.QuestionsAnswers on a.ID equals b.ANSWER_ID
                        where b.QUESTION_ID == 2 && b.TYPE_ID == type
                        select a).ToList();
            }
        }

        public List<Answers> GetAnswer(int type)
        {
            using (var ctx = new autologiaEntities())
            {
                return (from a in ctx.Answers
                        join b in ctx.QuestionsAnswers on a.ID equals b.ANSWER_ID
                        where b.QUESTION_ID == 2 && b.TYPE_ID == type
                        select a).ToList();
            }
        }

        public List<Answers> GetAnswer(int type, int questionId)
        {
            using (var ctx = new autologiaEntities())
            {
                return (from a in ctx.Answers
                        join b in ctx.QuestionsAnswers on a.ID equals b.ANSWER_ID
                        where b.QUESTION_ID == questionId && b.TYPE_ID == type
                        select a).ToList();
            }
        }

        public List<NameValuePair> GetYears(int start, int years)
        {
            List<NameValuePair> yearsList = new List<NameValuePair>();
            var startId = 541;
            for (var year = start; year <= start + years; year++)
            {
                yearsList.Add(new NameValuePair() { NAME = year.ToString(), VALUE = startId });
                startId++;
            }
            return yearsList;
        }
    }
}
