using System.Web.Mvc;
using Cryptinsure.Models;
using Cryptinsure.ViewModels;

namespace Cryptinsure.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly TransactionsModel _transaction = new TransactionsModel();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNew(TransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                _transaction.Validate(model);
            }

            return View(model);
        }
    }
}