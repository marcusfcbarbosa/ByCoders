using ByCoders.Core.Communications;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ByCoders.Web.Controllers
{
    public class MainController : Controller
    {
        protected bool ResponseHasErrors(ResponseResult resposta)
        {
            if (resposta != null && resposta.errors.Messages.Any())
            {
                resposta.errors.Messages.ForEach(x => ModelState.AddModelError(key: string.Empty, errorMessage: x));
                return true;
            }
            return false;
        }
    }
}
