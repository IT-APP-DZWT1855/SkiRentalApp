using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkiRental.Services;
using SkiRental.Models;
using SkiRental.ViewModels;

namespace SkiRental.Controllers
{
    public class ItemCategoriesController : Controller
    {
        private readonly ItemCategoryService _itemCategoryService = new ItemCategoryService();

        [ChildActionOnly]
        public PartialViewResult Menu(int selectedCategoryId)
        {
            var itemCategories = _itemCategoryService.Get();

            return PartialView(AutoMapper.Mapper.Map<List<ItemCategory>, List<ItemCategoryViewModel>>(itemCategories));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _itemCategoryService.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}