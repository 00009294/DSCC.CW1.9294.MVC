using Microsoft.AspNetCore.Mvc;
using MVC_Front_end.Models;
using Newtonsoft.Json;
using System.Text;

namespace MVC_Front_end.Controllers
{
    public class OwnerController : Controller
    {
        private Uri baseAddress = new Uri("https://localhost:44342/api");
        private readonly HttpClient httpClient;

        public OwnerController()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            IList<OwnerViewModel> ownerList = new List<OwnerViewModel>();
            HttpResponseMessage response = this.httpClient.GetAsync(this.httpClient.BaseAddress + "/owners/GetAll").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ownerList = JsonConvert.DeserializeObject<List<OwnerViewModel>>(data);
            }

            return View(ownerList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OwnerViewModel ownerViewModel)
        {
            try
            {
                var data = JsonConvert.SerializeObject(ownerViewModel);
                StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = this.httpClient.PostAsync(
                    this.httpClient.BaseAddress + "/owners/Post", stringContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "owner created";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            OwnerViewModel owner = new OwnerViewModel();
            HttpResponseMessage response = this.httpClient.GetAsync(
                this.httpClient.BaseAddress + "/owners/Get/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                owner = JsonConvert.DeserializeObject<OwnerViewModel>(data);
            }
            return View(owner);
        }

        [HttpPost]
        public IActionResult Edit(OwnerViewModel ownerViewModel)
        {
            try
            {
                var data = JsonConvert.SerializeObject(ownerViewModel);
                StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = this.httpClient.PutAsync(
                    this.httpClient.BaseAddress + "/owners/Put", stringContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "owner updated";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                OwnerViewModel owner = new OwnerViewModel();
                HttpResponseMessage response = this.httpClient.GetAsync(
                    this.httpClient.BaseAddress + "/owners/Get/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    owner = JsonConvert.DeserializeObject<OwnerViewModel>(data);
                }
                return View(owner);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;

                return View();
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = this.httpClient.DeleteAsync(
                    this.httpClient.BaseAddress + "/owners/Delete/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "owner deleted";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
    }
}