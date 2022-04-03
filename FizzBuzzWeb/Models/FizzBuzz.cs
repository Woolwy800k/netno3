using System.ComponentModel.DataAnnotations;

namespace FizzBuzzWeb.Models
{
    public class FizzBuzz
    {
        [Display(Name = "Podaj imię ")]
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [StringLength(100, MinimumLength = 3)]
        public string? Imie { get; set; }

        [Display(Name = "Podaj rok od 1899 do 2022 ")]
        [Range(1899, 2022, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "{0} może zawierać jedynie liczby całkowite")]
        [Required(ErrorMessage = "Pole jest obowiązkowe")]

        public int? Rok { get; set; }


        public string przestepny(int? year)
        {
            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
            {
                return "";
            }

            return "nie";
        }
    }
}