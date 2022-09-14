using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalApp.Models.EntityModels;
using PersonalApp.Models.PersonalInfos;
using PersonalApp.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalApp.Controllers
{
    public class PersonalInfoController : Controller
    {
        IPersonalInfoService _personalInfoService;
        IMapper _mapper;
        public PersonalInfoController(IPersonalInfoService personalInfoService,IMapper mapper)
        {
            _personalInfoService = personalInfoService;
            _mapper = mapper;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PersonalCreate personalCreate)
        {
            //Models.EntityModels.PersonalInfo info = new Models.EntityModels.PersonalInfo();
            //info.Name = personalCreate.Name;
            //info.Email = personalCreate.Email;
            //info.MobileNo = personalCreate.MobileNo;
            if (ModelState.IsValid)
            {
                var info = _mapper.Map<PersonalInfo>(personalCreate);
                var isAdded = _personalInfoService.Add(info);
                if (isAdded)
                {
                    return RedirectToAction("List");
                }
            }
            
            return View();
        }
        public IActionResult List()
        {
            var PersonList = _personalInfoService.GetAll();
            var personalInfoListVm = new PersonalInfoListVM()
            {
                Title = "All Information",
                PerList = PersonList.ToList()
            };
            return View(personalInfoListVm);
        }
        public IActionResult Edit(int? id)
        {
            if (id==null)
            {
                return RedirectToAction("List");
            }
            var personalInfo = _personalInfoService.GetById((int)id);
            if (personalInfo==null)
            {
                return RedirectToAction("List");
            }
            //var personEditVm = new PersonalInfoEditVM()
            //{
            //    Id = personalInfo.Id,
            //    Name = personalInfo.Name,
            //    Email = personalInfo.Email,
            //    MobileNo = personalInfo.MobileNo

            //};
            var personEditVm = _mapper.Map<PersonalInfoEditVM>(personalInfo);
            return View(personEditVm);
        }
        [HttpPost]
        public IActionResult Edit(PersonalInfoEditVM infoEditVM)
        {
            if (ModelState.IsValid)
            {
                //var person = new PersonalInfo()
                //{
                //    Id = infoEditVM.Id,
                //    Name = infoEditVM.Name,
                //    Email = infoEditVM.Email,
                //    MobileNo = infoEditVM.MobileNo
                //};
                var person = _mapper.Map<PersonalInfo>(infoEditVM);
                var isEdit = _personalInfoService.Update(person);
                if (isEdit)
                {
                    return RedirectToAction("List");
                }
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List");
            }
            var deleteInfo = _personalInfoService.GetById((int)id);
            if (deleteInfo==null)
            {
                return RedirectToAction("List");
            }
            var isDelete = _personalInfoService.Remove(deleteInfo);
            if (isDelete)
            {
                return RedirectToAction("List");
            }
            return View();
        }
    }
}
