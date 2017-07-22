using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cryptinsure.ViewModels
{
    public class ClaimViewModel
    {

        [DisplayName("Transaction ID was made")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please type a valid transaction ID")]
        public string TransactionWasMade { get; set; }

        [DisplayName("Intended Address")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please type a valid address")]
        public string IntendedAddress { get; set; }


    }
}