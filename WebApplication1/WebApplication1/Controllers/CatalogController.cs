using Microsoft.AspNetCore.Mvc;
using WebApplication1.Exceptions;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICutleryService _cutleryService;

        public CatalogController(ICutleryService cutleryService)
        {
            _cutleryService = cutleryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCutlerys()
        {
            List<Cutlery> cutlerys = null;
            
            try
            {
                cutlerys = await _cutleryService.GetCutlerys();
            }
            catch (BusinessException ex)
            {
                return NotFound(new { ex.Message });
            }

            return View(cutlerys);
        }

        public async Task<IActionResult> GetCutleryById(Guid id)
        {
            Cutlery cutlery = null;

            try
            {
                cutlery = await _cutleryService.GetCutleryById(id);
            }
            catch (BusinessException ex)
            {
                return NotFound(new { ex.Message });
            }

            return View(cutlery);
        }

        public IActionResult AddCutlery()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCutlery(CutleryViewModel cutleryFromBody)
        {
            await _cutleryService.AddCutlery(cutleryFromBody);

            return RedirectToAction("GetCutlerys");
        }

        [HttpGet]
        public async Task<IActionResult> EditCutleryById(Guid id)
        {
            Cutlery cutlery = null;
            
            try
            {
                cutlery = await _cutleryService.GetCutleryById(id);
            }
            catch (BusinessException ex)
            {
                return NotFound(new { ex.Message });
            }

            return View(cutlery);
        }

        [HttpPost]
        public async Task<IActionResult> EditCutleryById(Cutlery cutlery)
        {
            var cutleryFromView = new CutleryViewModel
            {
                Price = cutlery.Price,
                Material = cutlery.Material,
                Type = cutlery.Type
            };

            try
            {
                await _cutleryService.EditCutleryById(cutlery.Id, cutleryFromView);
            }
            catch (BusinessException ex)
            {
                return NotFound(new { ex.Message });
            }

            return RedirectToAction("GetCutlerys");
        }

        public async Task<IActionResult> DeleteCutleryById(Guid id)
        {
            try
            {
                await _cutleryService.DeleteCutleryById(id);
            }
            catch (BusinessException ex)
            {
                return NotFound(new { ex.Message });
            }

            return RedirectToAction("GetCutlerys");
        }
    }
}
