using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RiihiTask_SannaNV.Models;

//@author Sanna Nieminen-Vuorio
//Last modified 2.3.2022
//Controllers for inserting and fetching data from database
namespace Task_SannaNV.Controllers
{
    public class InformationController : Controller
    {
        // GET: Information
        //Get feedbacks from database and select the ones that permission is true to show only them
        public ActionResult ShowFeedback()
        {
            ExercisesEntities db = new ExercisesEntities();

            List<Feedback> feedbackList = db.Feedback.ToList();

            Info info = new Info();

            List<Info> infoList = feedbackList.Select(x => new Info { Name = x.Name, Message = x.Message, Permission = (bool)x.Permission }).ToList();

            List<Info> infoShow = new List<Info>();

            //Show only feedbacks where permission is true (=checkbox is checked)
            foreach (Info i in infoList)
            {
                if (i.Permission == true)
                {
                    infoShow.Add(i);
                }
            }

            return View(infoShow);
        }

        public ActionResult GetFeedback()
        {
            ExercisesEntities db = new ExercisesEntities();
            return View();
        }

        //Get feedback from user and store it in the database
        [HttpPost]
        public ActionResult GetFeedback(Info info)
        {

            try
            {
                ExercisesEntities db = new ExercisesEntities();

                Feedback feedback = new Feedback();

                feedback.Name = info.Name;
                feedback.SurName = info.SurName;
                feedback.Email = info.Email;
                feedback.Message = info.Message;
                feedback.Permission = info.Permission;

                db.Feedback.Add(feedback);
                db.SaveChanges();

                int lastId = feedback.ID;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error " + ex.Message);
            }

            return View(info);

        }

    }
}