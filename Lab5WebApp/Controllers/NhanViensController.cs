using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab5API.AppDBContext;
using Lab5API.Model;
using Newtonsoft.Json;
using System.Text;

namespace Lab5WebApp.Controllers
{
    public class NhanViensController : Controller
    {
       

        public NhanViensController()
        {
            
        }
        [HttpGet]
        // GET: NhanViens
        public async Task<IActionResult> Index()
        {
            List<NhanVien> ltsStudents = new List<NhanVien>();
            using (var httpClient = new HttpClient())
            {
                using (var reponse = await httpClient.GetAsync("https://localhost:7034/api/NhanViens"))
                {
                    string apiReponse = await reponse.Content.ReadAsStringAsync();
                    ltsStudents = JsonConvert.DeserializeObject<List<NhanVien>>(apiReponse);
                }
            }
            return View(ltsStudents);
        }
        [HttpGet("id")]
        // GET: NhanViens/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            NhanVien nhanVien = new NhanVien();
            using (var httpClient = new HttpClient())
            {
                using (var reponse = await httpClient.GetAsync("https://localhost:7034/api/NhanViens/" + id))
                {
                    if (reponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReponse = await reponse.Content.ReadAsStringAsync();
                        nhanVien = JsonConvert.DeserializeObject<NhanVien>(apiReponse);
                    }
                }
            }
            return View(nhanVien);
        }

        // GET: NhanViens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Ten,Tuoi,NamLamViec,Role,Luong,Email,TrangThai,ChucVu")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(nhanVien), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("https://localhost:7034/api/NhanViens/", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            nhanVien = JsonConvert.DeserializeObject<NhanVien>(apiResponse);
                            // Optionally, you can redirect to a different action if creation was successful.
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            // Handle error response
                            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        }
                    }
                }
            }

            return View(nhanVien);
        }


        // GET: NhanViens/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NhanVien nhanVien = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:7034/api/NhanViens/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        nhanVien = JsonConvert.DeserializeObject<NhanVien>(apiResponse);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }

            return View(nhanVien);
        }

        // POST: NhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,Ten,Tuoi,NamLamViec,Role,Luong,Email,TrangThai,ChucVu")] NhanVien nhanVien)
        {
            if (id != nhanVien.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(nhanVien), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync($"https://localhost:7034/api/NhanViens/{id}", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        }
                    }
                }
            }

            return View(nhanVien);
        }


        // GET: NhanViens/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NhanVien nhanVien = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:7034/api/NhanViens/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        nhanVien = JsonConvert.DeserializeObject<NhanVien>(apiResponse);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }

            return View(nhanVien);
        }


        // POST: NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync($"https://localhost:7034/api/NhanViens/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }



        private async Task<bool> NhanVienExists(Guid id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:7034/api/NhanViens/{id}"))
                {
                    return response.IsSuccessStatusCode;
                }
            }
        }

    }
}
