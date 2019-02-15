using System;
using System.Net;
using System.Web.Http;
using TrainingCalendarModel.Model;
using TrainingCalendarRepository.Repository.Abstract;

namespace TrainingCalanderService.Controllers
{
    [RoutePrefix("TrainingCalendar/TrainerDetails")]
    public class TrainerDetailsController : ApiController
    {
        private readonly ITrainerdetails _TrainerdetailsRepository;
        public TrainerDetailsController(ITrainerdetails TrainerdetailsRepository)
        {
            _TrainerdetailsRepository = TrainerdetailsRepository;
        }
        [HttpPost]
        [Route("AddTrainerdetails")]
        public IHttpActionResult AddTrainerdetails(Trainerdetails trainerdetails)
        {
            try
            {
                return Ok(_TrainerdetailsRepository.AddTrainerDetails(trainerdetails));
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Error ");
            }
        }
        [HttpPost]
        [Route("DeleteTrainerdetails")]
        public IHttpActionResult DeleteTrainerdetails(Trainerdetails trainerdetails)
        {
            try
            {
                return Ok(_TrainerdetailsRepository.DeleteTrainerdetails(trainerdetails));
            }
            catch(Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Error ");
            }
        }
        [HttpGet]
        [Route("GetAllTrainerdetails")]
        public IHttpActionResult GetAllTrainersdetail()
        {
            try
            {
                return Ok(_TrainerdetailsRepository.GetAllTrainerdetails());
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Error ");
            }
        }
        [HttpPost]
        [Route("UpdateTrainerdetails")]
        public IHttpActionResult UpdateTrainersdetail(Trainerdetails trainerdetails)
        {
            try
            {
                return Ok(_TrainerdetailsRepository.UpdateTrainerdetails(trainerdetails));
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Error ");
            }
        }


        [HttpPost]
        [Route("GetTrainersByID")]
        public IHttpActionResult GetTrainersdetailById(Trainerdetails trainerdetails)
        {
            try
            {
                return Ok(_TrainerdetailsRepository.GetTrainerById(trainerdetails));
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Error ");
            }
        }
    }
}
