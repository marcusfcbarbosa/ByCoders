using System.ComponentModel.DataAnnotations;

namespace ByCoders.Web.Models
{
    public class AddTituloModel
    {
        [Required(ErrorMessage = "The field {0} is mandatory")]
        public string File { get; set; }
    }
}
