using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Frontend.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Text;

namespace Frontend.Controllers
{
    public class CompaniesController : Controller
    {
        Uri baseAddress = new Uri("http://ec2-54-183-238-215.us-west-1.compute.amazonaws.com/api");
        private readonly HttpClient _client;

        public CompaniesController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        // GET: CompaniesController
        public ActionResult Index()
        {
            List<Company> companiesList = new List<Company>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/companies").Result;
               
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                companiesList = JsonConvert.DeserializeObject<List<Company>>(data);
            }
            return View(companiesList);
        }

        // GET: CompaniesController/Details/5
        public ActionResult Details(int id)
        {
            HttpResponseMessage response = _client.GetAsync($"companies/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                Company company = JsonConvert.DeserializeObject<Company>(data);
                return View(company);
            }
            else
            {
                // Handle errors, e.g., display an error page or message
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: CompaniesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompaniesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(company), Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/companies", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Handle errors, e.g., display error messages
                    ModelState.AddModelError(string.Empty, "Failed to create the company. Please check your input.");
                }
            }

            return View(company);
        }

        // GET: CompaniesController/Edit/5
        public ActionResult Edit(int id)
        {
            Company company = new Company();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/companies/{id}").Result;
            
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                company = JsonConvert.DeserializeObject<Company>(data);
            }

            return View(company);
        }

        // POST: CompaniesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Company company)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(company), Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + $"/companies/{id}", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Handle errors, e.g., display error messages
                    ModelState.AddModelError(string.Empty, "Failed to update the company. Please check your input.");
                }
            }

            return View(company);
        }

        // GET: CompaniesController/Delete/5
        public ActionResult Delete(int id)
        {
            Company company = new Company();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/companies/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                company = JsonConvert.DeserializeObject<Company>(data);
            }
            return View(company);
        }

        // POST: CompaniesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Company company)
        {
            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + $"/companies/{id}").Result;

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
