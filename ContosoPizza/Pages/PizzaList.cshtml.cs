using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Pages
{
    public class PizzaListModel : PageModel
    {
        // value of _service can't be changed after it's set in the constructor
        private readonly PizzaService _service;
        // will be initialized later, null saftety checks aren't required
        public IList<Pizza> PizzaList { get; set; } = default!;

        // binds NewPizza to Razor page
        // When HTTP POST request is made, NewPizza property is populated with user input
        [BindProperty]
        public Pizza NewPizza { get; set; } = default!;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Provided by dependency injection</param>
        public PizzaListModel(PizzaService service)
        {
            _service = service;
        }
        /// <summary>
        /// To retrieve the list of pizzas from PizzaService and store in PizzaList property
        /// </summary>
        public void OnGet()
        {
            PizzaList = _service.GetPizzas();
        }
        /// <summary>
        /// Creates a new pizza to be added to the list of pizzas
        /// </summary>
        /// <returns>Page navigation</returns>
        public IActionResult OnPost()
        {
            // Verify if user input is valid
            // validation rules inferred from attributes on Pizza class
            // if user input is invalid, Page method is called to re-render page
            if(!ModelState.IsValid || NewPizza == null)
            {
                return Page();
            }
            // Add new pizza to _service object
            _service.AddPizza(NewPizza);
            // Rerender page with updated list of pizzas
            return RedirectToAction("Get");
        }

        /// <summary>
        /// Deletes pizza from list of pizzas
        /// </summary>
        /// <param name="id">Page navigation</param>
        /// <returns></returns>
        public IActionResult OnPostDelete(int id)
        {
            // call delete method
            _service.DeletePizza(id);
            // render page with updated list of pizzas
            return RedirectToAction("Get");
        }
    }
}
