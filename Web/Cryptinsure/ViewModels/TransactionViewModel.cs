using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cryptinsure.ViewModels
{
    public class TransactionViewModel
    {

        [DisplayName("Recipient")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please type recipient address")]
        public string Recipient { get; set; }

        [DisplayName("Total Amount")]
        [Required(ErrorMessage = "Please type total transaction amount")]
        public double Amount { get; set; }

        public bool Insure { get; set; }
    }
}