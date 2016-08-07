using AddressAppMVC.Infrastructure.Context;
using AddressAppMVC.Infrastructure.Models;
using AddressAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddressAppMVC.Controllers
{
    public class AddressController : Controller
    {
        AddressContext acontext;
        public AddressController()
        {
            acontext = new AddressContext();
        }
        // GET: Address
        [HttpGet]
        public ActionResult Index()
        {
            var display = acontext.Addresses.Select(a => new AddressVM {id = a.id, address1 =a.address1, address2=a.address2,city=a.city, state=a.state, country=a.country, county=a.county  });
            return View(display);
        }
        [HttpGet]
        public ActionResult Create()
        {
            AddressVM newone = new AddressVM();
            return View(newone);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddressVM addressvm)
        {
            if (ModelState.IsValid)
            {
                Address add = new Address()
                {
                    address1 = addressvm.address1,
                    address2 = addressvm.address2,
                    city = addressvm.city,
                    state = addressvm.state,
                    country = addressvm.country,
                    county = addressvm.county
                };
                acontext.Addresses.Add(add);
                acontext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(addressvm);
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Address address = acontext.Addresses.Where(a => id == a.id).FirstOrDefault();
            AddressVM add = new AddressVM()
            {
                address1 = address.address1,
                address2 = address.address2,
                city = address.city,
                state = address.state,
                country = address.country,
                county = address.county
            };
            return View(add);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AddressVM add)
        {
            
            if (ModelState.IsValid)
            {

                Address address = acontext.Addresses.Where(a => add.id == a.id).FirstOrDefault();

                address.address1 = add.address1;
                address.address2 = add.address2;
                address.city = add.city;
                address.state = add.state;
                address.country = add.country;
                address.county = add.county; 
            
                acontext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(add);
            }

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Address add = acontext.Addresses.Where(a => id == a.id).FirstOrDefault();
            AddressVM address = new AddressVM()
            {
                address1 = add.address1,
                address2 = add.address2,
                city = add.city,
                state = add.state,
                country = add.country,
                county = add.county
            };
            return View(address);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            Address add = acontext.Addresses.Where(a => id == a.id).FirstOrDefault();

            acontext.Addresses.Remove(add);
            acontext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}