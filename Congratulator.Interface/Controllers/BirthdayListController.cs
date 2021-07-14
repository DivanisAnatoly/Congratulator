using Congratulator.Domain.Entities;
using Congratulator.Infrastructure.DBAccess;
using Congratulator.Interface.ViewModels;
using Congratulator.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Congratulator.Interface.Controllers
{
    public class BirthdayListController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvirement;
        private readonly IPersonRecordService _recordService;

        public BirthdayListController(IWebHostEnvironment hostEnvirement, IPersonRecordService recordService)
        {
            _hostEnvirement = hostEnvirement;
            _recordService = recordService;
        }


        // GET: BirthdayListController
        public async Task<IActionResult> Index()
        {
            return View(_recordService.GetPeople());
        }


        // GET: BirthdayListController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var person = _recordService.GetPerson(id);

            if (person == null)
                return NotFound();

            var personVM = new PersonViewModel()
            {
                Id = person.Id,
                Name = person.Name,
                Surname = person.Surname,
                BirthDay = person.BirthDay,
                ExsistingAvatar = person.Avatar
            };

            return View(personVM);
        }


        // GET: BirthdayListController/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: BirthdayListController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);

                var person = new Person()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    BirthDay = model.BirthDay,
                    Avatar = uniqueFileName
                };

                _recordService.AddPerson(person);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }


        // GET: BirthdayListController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _recordService.GetPerson(id);
            if (person == null)
            {
                return NotFound();
            }

            var personVM = new PersonViewModel()
            {
                Id = person.Id,
                Name = person.Name,
                Surname = person.Surname,
                BirthDay = person.BirthDay,
                ExsistingAvatar = person.Avatar
            };

            return View(personVM);
        }


        // POST: BirthdayListController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PersonViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var person = _recordService.GetPerson(model.Id);
                person.Name = model.Name;
                person.Surname = model.Surname;
                person.BirthDay = model.BirthDay;

                if (model.ImageFile != null)
                {
                    if (model.ExsistingAvatar != null)
                    {
                        string filePath = Path.Combine(_hostEnvirement.WebRootPath, "img", model.ExsistingAvatar);
                        System.IO.File.Delete(filePath);
                    }
                    person.Avatar = ProcessUploadedFile(model);
                }
                _recordService.UpdatePerson(person);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        // GET: BirthdayListController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _recordService.GetPerson(id);

            if (person == null)
            {
                return NotFound();
            }

            var personVM = new PersonViewModel()
            {
                Id = person.Id,
                Name = person.Name,
                Surname = person.Surname,
                BirthDay = person.BirthDay,
                ExsistingAvatar = person.Avatar
            };

            return View(personVM);
        }


        // POST: BirthdayListController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = _recordService.GetPerson(id);

            if (person.Avatar != null)
            {
                var imagePath = Path.Combine(_hostEnvirement.WebRootPath, "img", person.Avatar);
                if (System.IO.File.Exists(imagePath))
                    System.IO.File.Delete(imagePath);
            }

            _recordService.RemovePerson(person);

            return RedirectToAction(nameof(Index));
        }


        private string ProcessUploadedFile(PersonViewModel model)
        {
            string wwwRootPath = _hostEnvirement.WebRootPath;
            string fileName = null;

            if (model.ImageFile != null)
            {

                string extension = Path.GetExtension(model.ImageFile.FileName);

                fileName = model.Name + model.Surname + DateTime.Now.ToString("yyMMddHHmmssff") + extension;
                string path = Path.Combine(wwwRootPath + "/img", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    model.ImageFile.CopyToAsync(fileStream);
                }
            }

            return fileName;
        }


    }
}