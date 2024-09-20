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
    }
}
