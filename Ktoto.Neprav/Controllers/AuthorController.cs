using System.Linq;
using System.Web.Mvc;
using Ktoto.Neprav.DAL;
using Ktoto.Neprav.Domain;

namespace Ktoto.Neprav.Controllers
{
    public class AuthorController: Controller
    {
        private readonly IDal _dal;

        public AuthorController(IDal dal)
        {
            _dal = dal;
        }

        public ActionResult Page(string name)
        {
            var person = _dal.Query<Author>().Single(_ => _.Name == name);
            return View(person);
        }
    }
}