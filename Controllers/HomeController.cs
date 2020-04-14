
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudUsingAspMVCJquery.Models;
using CrudUsingAspMVCJquery.Controllers;
namespace CrudUsingAspMVCJquery.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

    
        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ShowRegistration()
        {

            string DOB = "";
            List<StudentInfo> _StudentInfo = new List<StudentInfo>();
            DataSet dt = BussinessLogicController.GetSetRecord("exec sp_registration @id='', @Name='',@Email='',@Mobile='',@Course='',@age='',@DOB='',@action='select'");
            if (dt.Tables.Count > 0)
            {
                if (dt.Tables[0].Rows.Count > 0)
                {


                    for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                    {

                        _StudentInfo.Add(new StudentInfo()
                        {
                            Name = dt.Tables[0].Rows[i]["Name"].ToString(),
                            id = Convert.ToInt32(dt.Tables[0].Rows[i]["id"]),
                            Email = dt.Tables[0].Rows[i]["Email"].ToString(),
                            Mobile = dt.Tables[0].Rows[i]["Mobile"].ToString(),
                            age = Convert.ToInt32(dt.Tables[0].Rows[0]["age"]),
                            Course = dt.Tables[0].Rows[i]["Course"].ToString(),
                            DOB = Convert.ToDateTime(dt.Tables[0].Rows[i]["DOB"])
                            





                        });

                    }
                }
            }


            




            //  return View(_StudentInfo);
            return Json(_StudentInfo, JsonRequestBehavior.AllowGet);
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Models.StudentInfo collection)
        {
            string message = "";

            if (ModelState.IsValid)
            {

                string Name = collection.Name;
                string Email = collection.Email;
                string Mobile = collection.Mobile;
                string Course = collection.Course;
                int age = collection.age;
                DateTime DOB = Convert.ToDateTime(collection.DOB);


                //  DataSet dt = con.GetRecordWithDataset("DECLARE @ScheduleDateTime DATETIME=getdate();Declare @ExpiryDateTime Datetime = getdate() + 91; exec glivebooks.dbo.[crm_insert_feed_lists] @Website_ID='9',@LoginID='" + ssn + "',@ListingID='" + ListingID + "',@FeedChannelID='" + feedchannelid + "',@ListingCategoryID='" + ListingCategoryID + "',@ListingTitle='" + ListingTitle + "',@ListingHeadline='',@ListingDescription='" + ListingDescription + "',@ScheduleDateTime=@ScheduleDateTime,@Expires=1,@ExpiryDateTime=@ExpiryDateTime,@FeedVisibilityID=3,@ActionButtonID=20,@ListingTopicsIDList='',@VisibilityExceptFriendList='',@VisibilitySpecificFriendList='',@CustomFriendListID='',@ResponseContactFeedChannelID='" + ResponseContactFeedChannelID + "',@FeedID='" + FeedId + "' ");
                DataSet dt = BussinessLogicController.GetSetRecord("exec sp_registration @id='', @Name='" + Name+"',@Email='"+Email+"',@Mobile='"+Mobile+"',@Course='"+Course+"',@age='"+age+"',@DOB='"+DOB+"',@action='insert'");
                if (dt.Tables.Count > 0)
                {
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                         message = dt.Tables[0].Rows[0]["message"].ToString();
                        ViewBag.Message = message;
                    }


                   
                }
                // TODO: Add insert logic here

               
                
            }

            if(message=="")
            {
                return View();
            }

            if(message== "you have successfully registered")
            {
                ModelState.Clear();
            }
           
           
            // return Json("",message, JsonRequestBehavior.AllowGet);
            return View();

        }

     

  

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            BussinessLogicController.GetSetRecord("exec sp_registration @id='"+id+ "', @Name='',@Email='',@Mobile='',@Course='',@age='',@DOB='',@action='delete'");
            return View("Create");
        }
        [HttpPost]
        public ActionResult Update(string id, string Name,string Email,string Mobile,string Course,string age,string DOB)
        {
            string Message="";
        //    int Convertid = Convert.ToInt16(id);
            DataSet updaterecord = BussinessLogicController.GetSetRecord("exec sp_registration @id='" + id + "', @Name='" +Name + "',@Email='" +Email + "',@Mobile='" +Mobile + "',@Course='" +Course + "',@age='" +age + "',@DOB='" +DOB + "',@action='update'");
            if (updaterecord.Tables.Count > 0)
            {
                if (updaterecord.Tables[0].Rows.Count > 0)
                {
                    Message = updaterecord.Tables[0].Rows[0]["message"].ToString();
                    ViewBag.Message = Message;
                }



            }

            return Json(Message, JsonRequestBehavior.AllowGet);
        }


        





       
    }
}
