using System.ComponentModel.DataAnnotations;

namespace LAHJA.Data.UI.Components.Payment.CreditCard
{




    public class CardDetails
    {
        [Required]
        public string CardNumber { get; set; } = "";
   

        [Required]
        public string HolderName { get; set; } = "";
      
        [Required]
        public string CardType { get; set; } = "";

        [Required]
        public string ExpirationDate { get; set; } = "";

        public bool IsSelected { get; set; } = false;

        [Required]
        public string CVC { get; set; } = "";
    }




}


