using AspNetCoreGeneratedDocument;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMVC.WebUI.Controllers
{
    public class CategoryController(ICategoryServices categoryServices) : Controller
    {
        private readonly ICategoryServices _categoryServices = categoryServices;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _categoryServices.GetCategoriesAsync();
            return View(result);
        }
        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0) return NotFound();            
            
            var category = await _categoryServices.GetByIdAsync(id);            
            
            if (category == null) return NotFound();            
            return View(category);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return NotFound();
            var categoryDTO = await _categoryServices.GetByIdAsync(id);
            if (categoryDTO == null) return NotFound();
            return View(categoryDTO);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0) return NotFound();
            var categoryDTO = await _categoryServices.GetByIdAsync(id);
            if (categoryDTO == null) return NotFound();
            return View(categoryDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                await _categoryServices.AddAsync(categoryDto);
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDto);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(CategoryDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryServices.UpdateAsync(categoryDto);
                }
                catch (Exception)
                {
                    throw;
                }             
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDto);
        }

        [HttpPost()]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {   
            try
            {
                await _categoryServices.RemoveAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));            
        }
    }
}
