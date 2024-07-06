using Domain.Domain;
using Domain.Integration;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            string URL = "http://localhost:5054/api/Admin/GetAllCars";

            HttpResponseMessage response = client.GetAsync(URL).Result;
            var data = response.Content.ReadAsAsync<List<Car>>().Result;
            return View(data);
        }
    }
}
