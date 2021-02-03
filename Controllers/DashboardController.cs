using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invest.Models;

namespace Invest.Controllers
{
    public class DashboardController : Controller
    {

        private readonly Model1 _db = new Model1();
        private int _id;
        private readonly List<InvestmentPremium> _iPremiums=new List<InvestmentPremium>();


        // GET: Dashboard
        public ActionResult Dashboard()
        {
            _id = (int)Session["Acc"];
            var data = _db.PREMIUMs.Where(d=>d.AccountID==_id).ToList();
            
            
            foreach (var premium in data)
            {
                var productData = _db.PRODUCTs.Find(premium.ProductID);

                var iprem = new InvestmentPremium
                {
                    Amount = premium.PremiumAmount,
                    DatePaid = premium.PaymentDate.ToString(),
                    InvestPack = productData.ProductNa
                };

                _iPremiums.Add(iprem);

            }

            return View(_iPremiums);
        }
    }
}