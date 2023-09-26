using MVC_webapi1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC_webapi1.Controllers
{
    public class clientController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:56832/api/Customer");
        private readonly HttpClient _client;



        public clientController()
        {
            _client = new System.Net.Http.HttpClient();
            _client.BaseAddress = baseAddress;
        }
            public ActionResult Index()
        {
            List<customer> customerlist = new List<customer>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                customerlist = JsonConvert.DeserializeObject<List<customer>>(data);
            }
            return View(customerlist);
        }

        // GET: client/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: client/Create
        public ActionResult Create(customer model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }



            return View();
        }

        // POST: client/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: client/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: client/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
