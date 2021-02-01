using System.Linq;
using System.Web.Mvc;
using Invest.Models;
using System.Security.Cryptography;
using System.Text;

namespace Invest.Controllers
{
    public class AuthenticationController : Controller
    {
        private Model1 _db = new Model1();
        private int ID=0;


        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "UserName,Pwd")] Auth auth)

        {

            var email = auth.UserName;
            var pwd = auth.Pwd;
            if (!ModelState.IsValid) return View();
            var f_password = GetMD5(pwd);
            var data = _db.Auths.Where(s => s.UserName.Equals(email) && s.Pwd.Equals(f_password)).ToList();
            
            if (data.Any())
            {
                var dat = _db.MEMBERs.Where(s => s.AccountID.Equals(data.FirstOrDefault().AccountID)).ToList();
                //add session
                Session["FullName"] = dat.FirstOrDefault().Othernames + " " + dat.FirstOrDefault().Surname;
                Session["Username"] = data.FirstOrDefault().UserName;
                Session["idUser"] = dat.FirstOrDefault().AccountNo;
                return RedirectToAction("Dashboard", "Dashboard");
            }
            else
            {
                ViewBag.error = "Login failed";
                return RedirectToAction("Login");
            }
        }

        public ActionResult SignUp()
        {
            return View();
        }


        //POST: SignUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Auth _user)
        {
            var pass= GetMD5(_user.Pwd);
            if (!ModelState.IsValid) return View();
            _user.Pwd = pass;
            _user.AccountID = ID;
            _db.Configuration.ValidateOnSaveEnabled = false;
            _db.Auths.Add(_user);
            _db.SaveChanges();
            return RedirectToAction("Dashboard","Dashboard");


        }


        public ActionResult Validate()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Validate([Bind(Include = "CellPhone")] MEMBER member)

        {
            var numberPhone = member.CellPhone;
            
            
            var data = _db.MEMBERs.Where(s => s.CellPhone.Equals(numberPhone) ).ToList();
            ID = data.FirstOrDefault().AccountID;


            System.Diagnostics.Debug.WriteLine("MY ID IS" + ID);

            if (data.Any())
            {
               
                //add session


                Session["Acc"] = data.FirstOrDefault().AccountID;
                return RedirectToAction("OTP" );
            }
            else
            {
                ViewBag.error = "Account not found";
                return RedirectToAction("Login");
            }



           
        





        }
        
        public ActionResult OTP()
        {
            return View();
        }



        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}