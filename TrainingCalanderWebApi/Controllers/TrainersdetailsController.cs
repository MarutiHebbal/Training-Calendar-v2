using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TrainingCalandarModel.Model;
using TrainingCalendarWebAPI.Common;
using TrainingCalendarWebAPI.Models;

namespace TrainingCalendarWebAPI.Controllers
{
    [RoutePrefix("TrainingCalendar/Trainers")]
    public class TrainersdetailsController : ApiController
    {
        private static HttpClient APIclient;
        public TrainersdetailsController()
        {
            if (APIclient == null)
            {
                APIclient = new HttpClient
                {
                    BaseAddress = new Uri(ConfigurationManager.AppSettings["TrainingCalendarUrl"])
                };
                APIclient.DefaultRequestHeaders.Accept.Clear();
            }
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        [Route("CreateTrainers")]
        public IHttpActionResult CreateTrainer(TrainerDetails trainerDetails)
        {
            ServiceManager sm = new ServiceManager();
            string ServResponse = null;
            List<object> TrainerDetails = new List<object>();
            try
            {
                ServResponse = sm.post_Request("TrainerDetails/AddTrainerdetails",trainerDetails);
                if (ServResponse != null)
                {
                    return Ok(ServResponse);
                }
                else
                {
                    return Ok(new HttpError(string.Format("No Records Found")));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        [Route("UpdateTrainers")]
        public IHttpActionResult UpdateTrainer(TrainerDetails trainerDetails)
        {
            ServiceManager sm = new ServiceManager();
            string ServResponse = null;
            List<object> TrainerDetails = new List<object>();
            try
            {
                ServResponse = sm.post_Request("TrainerDetails/UpdateTrainerdetails", trainerDetails);
                if (ServResponse != null)
                {
                    return Ok(ServResponse);
                }
                else
                {
                    return Ok(new HttpError(string.Format("No Records Found")));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("GetAllTrainers")]
        public IHttpActionResult GetAllTrainers()
        {
            ServiceManager sm = new ServiceManager();
            string ServResponse = null;
            try
            {
                ServResponse = sm.GetServer_Response("TrainerDetails/GetAllTrainerdetails");
                if (ServResponse != null)
                {
                    var res = JsonConvert.DeserializeObject(ServResponse);
                    return Ok(res);
                }
                else
                {
                    return Ok(new HttpError(string.Format("No Records Found")));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        [Route("RemoveTrainerdetails")]
        public IHttpActionResult RemoveTrainer(TrainerDetails trainerDetails)
        {
            ServiceManager sm = new ServiceManager();
            string ServResponse = null;
            List<object> TrainerDetails = new List<object>();
            try
            {
                ServResponse = sm.post_Request("TrainerDetails/DeleteTrainerdetails", trainerDetails);
                if (ServResponse != null)
                {
                  
                    return Ok(ServResponse);
                }
                else
                {
                    return Ok(new HttpError(string.Format("No Records Found")));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        [Route("GetTrainerByID")]
        public IHttpActionResult GetTrainersByID(TrainerDetails trainerDetails)
        {
            ServiceManager sm = new ServiceManager();
            string ServResponse = null;
            List<object> TrainerDetails = new List<object>();
            try
            {
                ServResponse = sm.post_Request("TrainerDetails/GetTrainersByID", trainerDetails);
                if (ServResponse != null)
                {
                    var res = JsonConvert.DeserializeObject(ServResponse);
                    return Ok(res);
                }
                else
                {
                    return Ok(new HttpError(string.Format("No Records Found")));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
