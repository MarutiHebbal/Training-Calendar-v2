using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCalendarModel.Model;
using TrainingCalendarRepository.Model;
using TrainingCalendarRepository.Repository.Abstract;

namespace TrainingCalendarRepository.Repository
{
   public class TrainerdetailsRepository: ITrainerdetails
    {
        private readonly Training_CalendarEntities _db;
        public TrainerdetailsRepository()
        {
            _db = new Training_CalendarEntities();
        }

        public bool AddTrainerDetails(Trainerdetails trainerDetail)
        {
            
            try
            {
                
                var CreateTrainerDetails = new TrainerDetail
                {
                    Description = trainerDetail.Description,
                    User_ID = trainerDetail.User_ID, 
                    Trainer_Type = trainerDetail.Trainer_Type,
                    Trainer_Name = trainerDetail.Trainer_Name,
                    Created_By = "Admin",
                    Created_On = DateTime.Now
                };
                _db.TrainerDetails.Add(CreateTrainerDetails);
                _db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteTrainerdetails(Trainerdetails trainerdetails)
        {
            try
            {
                var result = (from u in _db.TrainerDetails
                              where u.Trainer_ID == trainerdetails.Trainer_ID
                              select u).FirstOrDefault();
                _db.TrainerDetails.Remove(result);
                _db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable GetAllTrainerdetails()
        {
            try
            {

                return (from u in _db.TrainerDetails
                        select new Trainerdetails
                        {
                            Trainer_ID = u.Trainer_ID,
                            Description = u.Description,
                            User_ID = u.User_ID,
                            Trainer_Type = u.Trainer_Type,
                            Trainer_Name = u.Trainer_Name,
                            Created_By = u.Created_By,
                            Created_On = u.Created_On,
                            Updated_On = u.Updated_On
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateTrainerdetails(Trainerdetails trainerDetails)
        {
            try
            {
              //TrainerDetail e = _db.TrainerDetails.FirstOrDefault(u => u.Trainer_ID == trainerDetails.Trainer_ID);

              //  var result = from u in _db.TrainerDetails
              //               where u.Trainer_ID == trainerDetails.Trainer_ID
              //               select u;
              //  foreach(TrainerDetail u in result)
              //  {
              //      u.Description = trainerDetails.Description;
              //      u.Trainer_Type = trainerDetails.Trainer_Type;
              //      u.Trainer_Name = trainerDetails.Trainer_Name;
              //      //u.Created_By = "Admin";
              //      u.Updated_On = DateTime.Now;
              //  };
              //  _db.SaveChanges();
              //  return true;
                var result = _db.TrainerDetails.FirstOrDefault(r => r.Trainer_ID == trainerDetails.Trainer_ID);
                if (result != null)
                {
                    result.Trainer_ID = trainerDetails.Trainer_ID;
                    result.Trainer_Name=trainerDetails.Trainer_Name;
                    result.Trainer_Type = trainerDetails.Trainer_Type;
                    result.Updated_On = DateTime.Now;
                    result.Description = trainerDetails.Description;
                }
                _db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable GetTrainerById(Trainerdetails trainerDetails)
        {
            try
            {
                var result = from u in _db.TrainerDetails
                             where u.Trainer_ID == trainerDetails.Trainer_ID
                             select new Trainerdetails

                             {
                                 Trainer_ID = u.Trainer_ID,
                                 Description = u.Description,
                                  User_ID = u.User_ID,
                                 Trainer_Type = u.Trainer_Type,
                                 Trainer_Name = u.Trainer_Name,
                                 Created_By = u.Created_By,
                                 Created_On = u.Created_On,
                                 Updated_On = u.Updated_On
                             };
            if (result.Count() > 0)
            {
                return result;
            }
            else
            {
                return result = null;
            }
        }
            catch (Exception ex)
            {
                throw ex;
            }
}
    }
}
