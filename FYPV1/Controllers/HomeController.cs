using FYPV1.Models;
using FYPV1.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace FYPV1.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db = new Model1();
        public bool IsEmailExists(string eMail)
        {
            var IsCheck = db.Student_SignUp.Where(email => email.Email == eMail).FirstOrDefault();
            return IsCheck != null;
        }
        public bool TIsEmailExists(string eMail)
        {
            var IsCheck = db.Teacher_SignUp.Where(email => email.TEmail == eMail).FirstOrDefault();
            return IsCheck != null;
        }
        public void SendEmailToUser(string emailId, string activationCode)
        {
            var GenarateUserVerificationLink = "/Home/UserVerification/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, GenarateUserVerificationLink);

            var fromMail = new MailAddress("ahtasham067@gmail.com", "Ahtasham"); // set your email  
            var fromEmailpassword = "99009988067"; // Set your password   
            var toEmail = new MailAddress(emailId);

            var smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(fromMail.Address, fromEmailpassword);

            var Message = new MailMessage(fromMail, toEmail);
            Message.Subject = "Registration Completed-Demo";
            Message.Body = "<br/> Your registration completed succesfully." +
                           "<br/> please click on the below link for account verification" +
                           "<br/><br/><a href=" + link + ">" + link + "</a>";
            Message.IsBodyHtml = true;
            smtp.Send(Message);
        }
        public void TSendEmailToUser(string emailId, string activationCode)
        {
            var GenarateUserVerificationLink = "/Home/TUserVerification/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, GenarateUserVerificationLink);

            var fromMail = new MailAddress("ahtasham067@gmail.com", "Ahtasham"); // set your email  
            var fromEmailpassword = "99009988067"; // Set your password   
            var toEmail = new MailAddress(emailId);

            var smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(fromMail.Address, fromEmailpassword);

            var Message = new MailMessage(fromMail, toEmail);
            Message.Subject = "Registration Completed-Demo";
            Message.Body = "<br/> Your registration completed succesfully." +
                           "<br/> please click on the below link for account verification" +
                           "<br/><br/><a href=" + link + ">" + link + "</a>";
            Message.IsBodyHtml = true;
            smtp.Send(Message);
        }
        
        public ActionResult SignUp()
        {
            var getitemlist = db.Campus.ToList();
            SelectList list = new SelectList(getitemlist, "CampusId", "CampusName");
            ViewBag.campuslist = list;

            var getitemlist1 = db.Batches.ToList();
            SelectList list1 = new SelectList(getitemlist1, "BatchId", "BatchName");
            ViewBag.batchlist = list1;

            var getitemlist2 = db.Programs.ToList();
            SelectList list2 = new SelectList(getitemlist2, "ProgramId", "ProgramName");
            ViewBag.programlist = list2;


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(SignUpVM objUsr)
        {
            if (objUsr.Email != null)
            {
                // email not verified on registration time  
                objUsr.EmailVerification = false;

                var IsExists = IsEmailExists(objUsr.Email);
                if (IsExists)
                {
                    ModelState.AddModelError("EmailExists", "Email already Exists");
                    return View("SignUp");
                }
                //it generate unique code     
                objUsr.ActivetionCode = Guid.NewGuid();
                //password convert  
                objUsr.Password = FYPV1.Models.encryptPassword.textToEncrypt(objUsr.Password);
                //insert data
                string mainconn = ConfigurationManager.ConnectionStrings["Model19"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                string sqlquery1 = "insert into [dbo].[Student_SignUp] (FullName,Campus,Batch,Program,RegNo,Password,Email,ActivetionCode) values (@FullName,@Campus,@Batch,@Program,@RegNo,@Password,@Email,@ActivetionCode)";
                SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
                sqlconn.Open();
                sqlcomm.Parameters.AddWithValue("@FullName", objUsr.FullName);
                sqlcomm.Parameters.AddWithValue("@Campus", objUsr.Campus);
                sqlcomm.Parameters.AddWithValue("@Batch", objUsr.Batch);
                sqlcomm.Parameters.AddWithValue("@Program", objUsr.Program);
                sqlcomm.Parameters.AddWithValue("@RegNo", objUsr.RegNo);
                sqlcomm.Parameters.AddWithValue("@Password", objUsr.Password);
                sqlcomm.Parameters.AddWithValue("@Email", objUsr.Email);
                sqlcomm.Parameters.AddWithValue("@ActivetionCode", objUsr.ActivetionCode);
                sqlcomm.ExecuteNonQuery();
                sqlconn.Close();
                //email sent
                SendEmailToUser(objUsr.Email, objUsr.ActivetionCode.ToString());
                var Message = "Registration complete please check email";
                ViewBag.Message = Message;

            }
            else
            {
                if (objUsr.TEmail != null)
                {
                    // email not verified on registration time  
                    objUsr.EmailVerification = false;

                    var IsExists = TIsEmailExists(objUsr.TEmail);
                    if (IsExists)
                    {
                        ModelState.AddModelError("EmailExists", "Email already Exists");
                        return View("SignUp");
                    }
                    //it generate unique code     
                    objUsr.TActivetionCode = Guid.NewGuid();
                    //password convert  
                    objUsr.TPassword = FYPV1.Models.encryptPassword.textToEncrypt(objUsr.TPassword);
                    //insert data
                    string mainconn = ConfigurationManager.ConnectionStrings["Model19"].ConnectionString;
                    SqlConnection sqlconn = new SqlConnection(mainconn);
                    string sqlquery1 = "insert into [dbo].[Teacher_SignUp] (TFullName,TeacherId,TPassword,TEmail,TActivetionCode) values (@TFullName,@TeacherId,@TPassword,@TEmail,@TActivetionCode)";
                    SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
                    sqlconn.Open();
                    sqlcomm.Parameters.AddWithValue("@TFullName", objUsr.TFullName);
                    sqlcomm.Parameters.AddWithValue("@TeacherId", objUsr.TeacherId);
                    sqlcomm.Parameters.AddWithValue("@TPassword", objUsr.TPassword);
                    sqlcomm.Parameters.AddWithValue("@TEmail", objUsr.TEmail);
                    sqlcomm.Parameters.AddWithValue("@TActivetionCode", objUsr.TActivetionCode);
                    sqlcomm.ExecuteNonQuery();
                    sqlconn.Close();
                    //email sent
                    TSendEmailToUser(objUsr.TEmail, objUsr.TActivetionCode.ToString());
                    var Message = "Registration complete please check email";
                    ViewBag.Message = Message;

                }
            }

            return RedirectToAction("SignUp");
        }
        public ActionResult UserVerification(string id)
        {
            bool Status = false;

            db.Configuration.ValidateOnSaveEnabled = false; // Ignor to password confirmation   
            var IsVerify = db.Student_SignUp.Where(u => u.ActivetionCode == new Guid(id)).FirstOrDefault();

            if (IsVerify != null)
            {
                IsVerify.EmailVerification = true;
                db.SaveChanges();
                ViewBag.Message = "Email Verification completed";
                Status = true;
            }
            else
            {
                ViewBag.Message = "Invalid Request...Email not verify";
                ViewBag.Status = false;
            }

            return View("SignUp");
        }
        public ActionResult TUserVerification(string id)
        {
            bool Status = false;

            db.Configuration.ValidateOnSaveEnabled = false; // Ignor to password confirmation   
            var IsVerify = db.Teacher_SignUp.Where(u => u.TActivetionCode == new Guid(id)).FirstOrDefault();

            if (IsVerify != null)
            {
                IsVerify.TEmailVerification = true;
                db.SaveChanges();
                ViewBag.Message = "Email Verification completed";
                Status = true;
            }
            else
            {
                ViewBag.Message = "Invalid Request...Email not verify";
                ViewBag.Status = false;
            }

            return View("SignUp");
        }

        [HttpGet]
        public ActionResult Login()
        {
            var getitemlist = db.Campus.ToList();
            SelectList list = new SelectList(getitemlist, "CampusId", "CampusName");
            ViewBag.campuslist = list;

            var getitemlist1 = db.Batches.ToList();
            SelectList list1 = new SelectList(getitemlist1, "BatchId", "BatchName");
            ViewBag.batchlist = list1;

            var getitemlist2 = db.Programs.ToList();
            SelectList list2 = new SelectList(getitemlist2, "ProgramId", "ProgramName");
            ViewBag.programlist = list2;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogInVM LgnUsr)
        {
            if (LgnUsr.Password != null && LgnUsr.RegNo != null && LgnUsr.Campus != 0 && LgnUsr.Program != 0 && LgnUsr.Batch != 0)
            {
                var _passWord = FYPV1.Models.encryptPassword.textToEncrypt(LgnUsr.Password);
                bool Isvalid = db.Student_SignUp.Any(x => x.Campus == LgnUsr.Campus && x.Batch == LgnUsr.Batch && x.Program == LgnUsr.Program && x.RegNo == LgnUsr.RegNo && x.EmailVerification == true &&
                x.Password == _passWord);
                if (Isvalid)
                {
                    return RedirectToAction("AddSemester");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Information... Please try again!");
                    return RedirectToAction("LogIn");
                }

            }
            else
            {
                if (LgnUsr.TPassword != null && LgnUsr.TeacherId != null)
                {
                    var _passWord = FYPV1.Models.encryptPassword.textToEncrypt(LgnUsr.TPassword);
                    bool Isvalid = db.Teacher_SignUp.Any(x => x.TeacherId == LgnUsr.TeacherId && x.TEmailVerification == true &&
                    x.TPassword == _passWord);
                    if (Isvalid)
                    {
                        return RedirectToAction("AddSemester");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Information... Please try again!");

                    }

                }
            }
            return RedirectToAction("AddSemester");
        }
        [HttpGet]
        public ActionResult StudentDashBoard()
        {
            var getitemlist = db.Semesters.ToList();
            SelectList list = new SelectList(getitemlist, "SemesterId", "SemesterNumber");
            ViewBag.semesterlist = list;

            var getitemlist1 = db.Supervisors.ToList();
            SelectList list1 = new SelectList(getitemlist1, "SupervisorId", "SupervisorName");
            ViewBag.semesterlist1 = list1;


            var getitemlist2 = db.Co_Supervisor.ToList();
            SelectList list2 = new SelectList(getitemlist2, "CoSupervisorId", "CoSupervisorName");
            ViewBag.semesterlist2 = list2;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentDashBoard(StudentDashBoardVM obj, HttpPostedFileBase ProposalFile, HttpPostedFileBase SrsFile, HttpPostedFileBase SreFile, HttpPostedFileBase Code, HttpPostedFileBase Prototype, HttpPostedFileBase FinalReport)
        {
            if (ProposalFile != null)
            {
                var supportedTypes = new[] { "zip", "rar" };
                var fileExt = System.IO.Path.GetExtension(ProposalFile.FileName).Substring(1);
                if (supportedTypes.Contains(fileExt))
                {
                    string filename = Path.GetFileName(ProposalFile.FileName);
                    ProposalFile.SaveAs(Server.MapPath("/ProposalFiles/" + filename));
                    string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
                    SqlConnection sqlconn = new SqlConnection(mainconn);
                    string sqlquery1 = "insert into [dbo].[Project] (Title,Supervisor,CoSupervisor,Summary,Objective,Scope,ToolsAndTechnologies,ProposalFileType,ProposalFilePath,ProposalFileName) values (@Title,@Supervisor,@CoSupervisor,@Summary,@Objective,@Scope,@ToolsAndTechnologies,@ProposalFileType,@ProposalFilePath,@ProposalFileName);SELECT SCOPE_IDENTITY();";

                    SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
                    byte[] bytes;
                    using (BinaryReader br = new BinaryReader(ProposalFile.InputStream))
                    {
                        bytes = br.ReadBytes(ProposalFile.ContentLength);

                    }
                    sqlconn.Open();
                    sqlcomm.Parameters.AddWithValue("@ProposalFileName", filename);
                    sqlcomm.Parameters.AddWithValue("@Title", obj.Title);
                    sqlcomm.Parameters.AddWithValue("@Supervisor", obj.Supervisor);
                    sqlcomm.Parameters.AddWithValue("@CoSupervisor", obj.CoSupervisor);
                    sqlcomm.Parameters.AddWithValue("@Summary", obj.Summary);
                    sqlcomm.Parameters.AddWithValue("@Objective", obj.Objective);
                    sqlcomm.Parameters.AddWithValue("@Scope", obj.Scope);
                    sqlcomm.Parameters.AddWithValue("@ToolsAndTechnologies", obj.ToolsAndTechnologies);
                    sqlcomm.Parameters.AddWithValue("@ProposalFileType", ProposalFile.ContentType);
                    sqlcomm.Parameters.AddWithValue("@ProposalFilePath", @"/ProposalFiles/" + filename);
                    var insertedId = sqlcomm.ExecuteScalar();
                    if (obj.RegNo1 != null && obj.StudentName1 != null && obj.Semester1 != 0 && obj.Email1 != null && obj.ContactNo1 != 0)
                    {
                        string sqlquery2 = "insert into [dbo].[Project_Student] (Semester,Email,ContactNo,StudentName,RegNo,ProjectId) VALUES (@Semester,@Email,@ContactNo,@StudentName,@RegNo,@ProjectId)";
                        SqlCommand sqlcomm1 = new SqlCommand(sqlquery2, sqlconn);
                        sqlcomm1.Parameters.AddWithValue("@Semester", obj.Semester1);
                        sqlcomm1.Parameters.AddWithValue("@Email", obj.Email1);
                        sqlcomm1.Parameters.AddWithValue("@ContactNo", obj.ContactNo1);
                        sqlcomm1.Parameters.AddWithValue("@StudentName", obj.StudentName1);
                        sqlcomm1.Parameters.AddWithValue("@RegNo", obj.RegNo1);
                        sqlcomm1.Parameters.AddWithValue("@ProjectId", insertedId);
                        sqlcomm1.ExecuteScalar();

                    }
                    if (obj.RegNo2 != null && obj.StudentName2 != null && obj.Semester2 != 0 && obj.Email2 != null && obj.ContactNo2 != 0)
                    {
                        string sqlquery3 = "insert into [dbo].[Project_Student] (Semester,Email,ContactNo,StudentName,RegNo,ProjectId) VALUES (@Semester,@Email,@ContactNo,@StudentName,@RegNo,@ProjectId)";
                        SqlCommand sqlcomm1 = new SqlCommand(sqlquery3, sqlconn);
                        sqlcomm1.Parameters.AddWithValue("@Semester", obj.Semester2);
                        sqlcomm1.Parameters.AddWithValue("@Email", obj.Email2);
                        sqlcomm1.Parameters.AddWithValue("@ContactNo", obj.ContactNo2);
                        sqlcomm1.Parameters.AddWithValue("@StudentName", obj.StudentName2);
                        sqlcomm1.Parameters.AddWithValue("@RegNo", obj.RegNo2);
                        sqlcomm1.Parameters.AddWithValue("@ProjectId", insertedId);
                        sqlcomm1.ExecuteScalar();
                    }

                }
            }
            else
            {
                if (SrsFile != null)
                {
                    var supportedTypes = new[] { "zip", "rar" };
                    var fileExt = System.IO.Path.GetExtension(SrsFile.FileName).Substring(1);
                    if (supportedTypes.Contains(fileExt))
                    {
                        string filename = Path.GetFileName(SrsFile.FileName);
                        SrsFile.SaveAs(Server.MapPath("/SrsFiles/" + filename));
                        string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
                        SqlConnection sqlconn = new SqlConnection(mainconn);
                        string sqlquery1 = "UPDATE [dbo].[Project] SET SrsFileType=@SrsFileType,SrsFilePath=@SrsFilePath,SrsFileName=@SrsFileName WHERE ProjectId=@ProjectId";
                        SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
                        byte[] bytes;
                        using (BinaryReader br = new BinaryReader(SrsFile.InputStream))
                        {
                            bytes = br.ReadBytes(SrsFile.ContentLength);

                        }
                        sqlconn.Open();
                        sqlcomm.Parameters.AddWithValue("@SrsFileName", filename);
                        sqlcomm.Parameters.AddWithValue("@SrsFileType", SrsFile.ContentType);
                        sqlcomm.Parameters.AddWithValue("@ProjectId", 1);
                        sqlcomm.Parameters.AddWithValue("@SrsFilePath", @"/SrsFiles/" + filename);
                        sqlcomm.ExecuteNonQuery();
                        sqlconn.Close();
                    }
                }
                else
                {
                    if (SreFile != null)
                    {
                        var supportedTypes = new[] { "zip", "rar" };
                        var fileExt = System.IO.Path.GetExtension(SreFile.FileName).Substring(1);
                        if (supportedTypes.Contains(fileExt))
                        {
                            string filename = Path.GetFileName(SreFile.FileName);
                            SreFile.SaveAs(Server.MapPath("/SreFiles/" + filename));
                            string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
                            SqlConnection sqlconn = new SqlConnection(mainconn);
                            string sqlquery1 = "UPDATE [dbo].[Project] SET SreFileType=@SreFileType,SreFilePath=@SreFilePath,SreFileName=@SreFileName WHERE ProjectId=@ProjectId";
                            SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
                            byte[] bytes;
                            using (BinaryReader br = new BinaryReader(SreFile.InputStream))
                            {
                                bytes = br.ReadBytes(SreFile.ContentLength);

                            }
                            sqlconn.Open();
                            sqlcomm.Parameters.AddWithValue("@SreFileName", filename);
                            sqlcomm.Parameters.AddWithValue("@SreFileType", SreFile.ContentType);
                            sqlcomm.Parameters.AddWithValue("@ProjectId", 1);
                            sqlcomm.Parameters.AddWithValue("@SreFilePath", @"/SreFiles/" + filename);
                            sqlcomm.ExecuteNonQuery();
                            sqlconn.Close();
                        }
                    }
                    else
                    {
                        if (Code != null)
                        {
                            var supportedTypes = new[] { "zip", "rar" };
                            var fileExt = System.IO.Path.GetExtension(Code.FileName).Substring(1);
                            if (supportedTypes.Contains(fileExt))
                            {
                                string filename = Path.GetFileName(Code.FileName);
                                Code.SaveAs(Server.MapPath("/CodeFiles/" + filename));
                                string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
                                SqlConnection sqlconn = new SqlConnection(mainconn);
                                string sqlquery1 = "UPDATE [dbo].[Project] SET CodeFileType=@CodeFileType,CodeFilePath=@CodeFilePath,CodeFileName=@CodeFileName WHERE ProjectId=@ProjectId";
                                SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
                                byte[] bytes;
                                using (BinaryReader br = new BinaryReader(Code.InputStream))
                                {
                                    bytes = br.ReadBytes(Code.ContentLength);

                                }
                                sqlconn.Open();
                                sqlcomm.Parameters.AddWithValue("@CodeFileName", filename);
                                sqlcomm.Parameters.AddWithValue("@CodeFileType", Code.ContentType);
                                sqlcomm.Parameters.AddWithValue("@ProjectId", 1);
                                sqlcomm.Parameters.AddWithValue("@CodeFilePath", @"/CodeFiles/" + filename);
                                sqlcomm.ExecuteNonQuery();
                                sqlconn.Close();
                            }
                        }
                        else
                        {
                            if (Prototype != null)
                            {
                                var supportedTypes = new[] { "zip", "rar" };
                                var fileExt = System.IO.Path.GetExtension(Prototype.FileName).Substring(1);
                                if (supportedTypes.Contains(fileExt))
                                {
                                    string filename = Path.GetFileName(Prototype.FileName);
                                    Prototype.SaveAs(Server.MapPath("/PrototypeFiles/" + filename));
                                    string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
                                    SqlConnection sqlconn = new SqlConnection(mainconn);
                                    string sqlquery1 = "UPDATE [dbo].[Project] SET PrototypeFileType=@PrototypeFileType,PrototypeFilePath=@PrototypeFilePath,PrototypeFileName=@PrototypeFileName WHERE ProjectId=@ProjectId";
                                    SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
                                    byte[] bytes;
                                    using (BinaryReader br = new BinaryReader(Prototype.InputStream))
                                    {
                                        bytes = br.ReadBytes(Prototype.ContentLength);

                                    }
                                    sqlconn.Open();
                                    sqlcomm.Parameters.AddWithValue("@PrototypeFileName", filename);
                                    sqlcomm.Parameters.AddWithValue("@PrototypeFileType", Prototype.ContentType);
                                    sqlcomm.Parameters.AddWithValue("@ProjectId", 1);
                                    sqlcomm.Parameters.AddWithValue("@PrototypeFilePath", @"/PrototypeFiles/" + filename);
                                    sqlcomm.ExecuteNonQuery();
                                    sqlconn.Close();
                                }
                            }
                            else
                            {
                                if (FinalReport != null)
                                {
                                    var supportedTypes = new[] { "zip", "rar" };
                                    var fileExt = System.IO.Path.GetExtension(FinalReport.FileName).Substring(1);
                                    if (supportedTypes.Contains(fileExt))
                                    {
                                        string filename = Path.GetFileName(FinalReport.FileName);
                                        FinalReport.SaveAs(Server.MapPath("/FinalReportFiles/" + filename));
                                        string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
                                        SqlConnection sqlconn = new SqlConnection(mainconn);
                                        string sqlquery1 = "UPDATE [dbo].[Project] SET FinalReportFileType=@FinalReportFileType,FinalReportFilePath=@FinalReportFilePath,FinalReportFileName=@FinalReportFileName WHERE ProjectId=@ProjectId";
                                        SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
                                        byte[] bytes;
                                        using (BinaryReader br = new BinaryReader(FinalReport.InputStream))
                                        {
                                            bytes = br.ReadBytes(FinalReport.ContentLength);

                                        }
                                        sqlconn.Open();
                                        sqlcomm.Parameters.AddWithValue("@FinalReportFileName", filename);
                                        sqlcomm.Parameters.AddWithValue("@FinalReportFileType", FinalReport.ContentType);
                                        sqlcomm.Parameters.AddWithValue("@ProjectId", 1);
                                        sqlcomm.Parameters.AddWithValue("@FinalReportFilePath", @"/FinalReportFiles/" + filename);
                                        sqlcomm.ExecuteNonQuery();
                                        sqlconn.Close();
                                    }
                                }
                            }
                        }
                    }
                }

            }


            return RedirectToAction("StudentDashBoard");
        }
        public ActionResult TeacherDashBoard()
        {

            return View();
        }
        [HttpGet]
        public ActionResult AdminDashBoard()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
            public ActionResult AdminDashBoard(AdminDashBoardVM obj)
        {
            //Domain
            //string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
            //SqlConnection sqlconn = new SqlConnection(mainconn);
            //string sqlquery1 = "insert into [dbo].[Domain] (DomainName) values (@name)";
            //SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
            //sqlconn.Open();
            //sqlcomm.Parameters.AddWithValue("@name", obj.DomainName);
            //sqlcomm.ExecuteNonQuery();
            //sqlconn.Close();
            //Allied Fields
            //string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
            //SqlConnection sqlconn = new SqlConnection(mainconn);
            //string sqlquery1 = "insert into [dbo].[AlliedField] (AlliedFieldName) values (@name)";
            //SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
            //sqlconn.Open();
            //sqlcomm.Parameters.AddWithValue("@name", obj.AlliedFieldName);
            //sqlcomm.ExecuteNonQuery();
            //sqlconn.Close();
            //Supervisor
            //string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
            //SqlConnection sqlconn = new SqlConnection(mainconn);
            //string sqlquery1 = "insert into [dbo].[Supervisor] (SupervisorName) values (@name)";
            //SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
            //sqlconn.Open();
            //sqlcomm.Parameters.AddWithValue("@name", obj.SupervisorName);
            //sqlcomm.ExecuteNonQuery();
            //sqlconn.Close();
            //Co-Supervisor
            //string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
            //SqlConnection sqlconn = new SqlConnection(mainconn);
            //string sqlquery1 = "insert into [dbo].[Co_Supervisor] (CoSupervisorName) values (@name)";
            //SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
            //sqlconn.Open();
            //sqlcomm.Parameters.AddWithValue("@name", obj.CoSupervisorName);
            //sqlcomm.ExecuteNonQuery();
            //sqlconn.Close();
            //Batch
            //string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
            //SqlConnection sqlconn = new SqlConnection(mainconn);
            //string sqlquery1 = "insert into [dbo].[Batch] (BatchName) values (@name)";
            //SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
            //sqlconn.Open();
            //sqlcomm.Parameters.AddWithValue("@name", obj.BatchName);
            //sqlcomm.ExecuteNonQuery();
            //sqlconn.Close();
            //Campus
            //string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
            //SqlConnection sqlconn = new SqlConnection(mainconn);
            //string sqlquery1 = "insert into [dbo].[Campus] (CampusName) values (@name)";
            //SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
            //sqlconn.Open();
            //sqlcomm.Parameters.AddWithValue("@name", obj.CampusName);
            //sqlcomm.ExecuteNonQuery();
            //sqlconn.Close();
            //program
            //string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
            //SqlConnection sqlconn = new SqlConnection(mainconn);
            //string sqlquery1 = "insert into [dbo].[Program] (ProgramName) values (@name)";
            //SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
            //sqlconn.Open();
            //sqlcomm.Parameters.AddWithValue("@name", obj.ProgramName);
            //sqlcomm.ExecuteNonQuery();
            //sqlconn.Close();
            //Semester
            string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery1 = "insert into [dbo].[Semester] (SemesterNumber) values (@name)";
            SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
            sqlconn.Open();
            sqlcomm.Parameters.AddWithValue("@name", obj.SemesterNumber);
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();
            return RedirectToAction("AdminDashBoard");
        }
    }
}