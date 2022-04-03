using FizzBuzzWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzBuzzWeb.Pages

{
    public class SavedInSessionModel : PageModel
    {
        public FizzBuzz FizzBuzz { get; set; }

        public List<string[]> Lista;
        

        public void OnGet()
        {
            
            var Data = HttpContext.Session.GetString("CheckedList");
            if (Data != null)
                Lista = JsonConvert.DeserializeObject<List<string[]>>(Data);
        }
    }
}