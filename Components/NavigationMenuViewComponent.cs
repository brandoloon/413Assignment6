using Assignment6.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment6.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBookStoreRepository repo;
        public NavigationMenuViewComponent(IBookStoreRepository r)
        {
            repo = r;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.CurrentCategory = RouteData?.Values["category"];

            return View(repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
