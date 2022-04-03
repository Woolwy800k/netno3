using FizzBuzzWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        public string Result;

        public string Alert;

        public string[] wiersz;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            DefaultName();
        }

        public void DefaultName()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {

                wiersz = new string[3];
                wiersz[0] = FizzBuzz.Imie;
                wiersz[1] = FizzBuzz.Rok.ToString();
                wiersz[2] = FizzBuzz.przestepny(FizzBuzz.Rok);


                List<string[]> Lista;

                var Data = HttpContext.Session.GetString("CheckedList");
                if (Data != null)
                    Lista = JsonConvert.DeserializeObject<List<string[]>>(Data);
                else
                    Lista = new List<string[]>();
                Lista.Add(wiersz);
                HttpContext.Session.SetString("CheckedList", JsonConvert.SerializeObject(Lista));
            }
            return Page();
           
        }
    }
}