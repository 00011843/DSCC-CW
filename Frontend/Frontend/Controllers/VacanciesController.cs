using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Frontend.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Text;
using System.Globalization;

namespace Frontend.Controllers
{
    public class VacanciesController : Controller
    {
        Uri baseAddress = new Uri("http://ec2-54-183-238-215.us-west-1.compute.amazonaws.com/api");
        private readonly HttpClient _client;

        public VacanciesController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        // GET: VacanciesController
        public ActionResult Index()
        {
            List<Vacancy> vacanciesList = new List<Vacancy>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/vacancies").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                vacanciesList = JsonConvert.DeserializeObject<List<Vacancy>>(data);
            }
            return View(vacanciesList);
        }

        // GET: VacanciesController/Details/5
        public ActionResult Details(int id)
        {
            HttpResponseMessage response = _client.GetAsync($"vacancies/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                Vacancy vacancy = JsonConvert.DeserializeObject<Vacancy>(data);
                return View(vacancy);
            }
            else
            {
                // Handle errors, e.g., display an error page or message
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: VacanciesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VacanciesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                vacancy.JobOpenedDate = DateTime.ParseExact("2023-11-06T22:11:44.240Z", "dd.MM.yyyy", CultureInfo.InvariantCulture);
                vacancy.JobClosedDate = DateTime.ParseExact("2023-11-06T22:11:44.240Z", "dd.MM.yyyy", CultureInfo.InvariantCulture);
                var content = new StringContent(JsonConvert.SerializeObject(vacancy), Encoding.UTF8, "application/json");
               
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/vacancies", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Handle errors, e.g., display error messages
                    ModelState.AddModelError(string.Empty, "Failed to create the vacancy. Please check your input.");
                }
            }

            return View(vacancy);
        }

        // GET: VacanciesController/Edit/5
        public ActionResult Edit(int id)
        {
            Vacancy vacancy = new Vacancy();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/vacancies/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                vacancy = JsonConvert.DeserializeObject<Vacancy>(data);
            }

            return View(vacancy);
        }

        // POST: VacanciesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(vacancy), Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + $"/vacancies/Edit/{id}", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Handle errors, e.g., display error messages
                    ModelState.AddModelError(string.Empty, "Failed to update the vacancy. Please check your input.");
                }
            }

            return View(vacancy);
        }

        // GET: VacanciesController/Delete/5
        public ActionResult Delete(int id)
        {
            Vacancy vacancy = new Vacancy();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/vacancies/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                vacancy = JsonConvert.DeserializeObject<Vacancy>(data);
            }
            return View(vacancy);
        }

        // POST: VacanciesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Vacancy vacancy)
        {
            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + $"/vacancies/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                // Handle errors, e.g., display an error page or message
                ModelState.AddModelError(string.Empty, "Failed." + ex.Message);
                return View();
            }
            return View();
        }
    }
}
