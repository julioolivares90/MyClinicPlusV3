using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyClinicPlusV3.Data;
using MyClinicPlusV3.Models;
using MyClinicPlusV3.Repositories;

namespace MyClinicPlusV3.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IProductoRepository productoRepository;
        private readonly ITipoProductoRepository tipoProductoRepository;

        public ProductosController(IProductoRepository productoRepository,ITipoProductoRepository tipoProductoRepository)
        {
            this.productoRepository = productoRepository;
            this.tipoProductoRepository = tipoProductoRepository;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var productos = await productoRepository.GetProductosWithTipoAsync();
            return View(productos);
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await productoRepository.GetProductoByIdWithTipoAsync(id.Value);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public async Task<IActionResult> Create()
        {
            var listItems = await tipoProductoRepository.GetAllAsync();
            ViewData["TipoProductoId"] = new SelectList(listItems, "Id", "Descripcion");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,CostoPorUnidad,CostoPublico,Ganancia,Cantidad,TipoProductoId,Id")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                await productoRepository.AddAsync(producto);
                return RedirectToAction(nameof(Index));
            }
            var listItems = await tipoProductoRepository.GetAllAsync();
            ViewData["TipoProductoId"] = new SelectList(listItems, "Id", "Descripcion", producto.TipoProductoId);
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await productoRepository.GetByIDAsync(id.Value);
            if (producto == null)
            {
                return NotFound();
            }
            var listItems = await tipoProductoRepository.GetAllAsync();
            ViewData["TipoProductoId"] = new SelectList(listItems, "Id", "Descripcion", producto.TipoProductoId);
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nombre,CostoPorUnidad,CostoPublico,Ganancia,Cantidad,TipoProductoId,Id")] Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await productoRepository.UpdateAsync(producto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var productoExists = await ProductoExists(producto.Id);
                    if (!productoExists)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var listItems = await tipoProductoRepository.GetAllAsync();
            ViewData["TipoProductoId"] = new SelectList(listItems, "Id", "Descripcion", producto.TipoProductoId);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await productoRepository.GetProductoByIdWithTipoAsync(id.Value);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await productoRepository
                .GetByIDAsync(id);

            await productoRepository
                .DeleteAsync(producto);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProductoExists(int id)
        {
            return await productoRepository.AnyAsync(id);
        }

        [HttpGet]
        public async Task<IActionResult> FindMedicamentoByName([FromQuery]string nameMedicamento)
        {
            var producto = await productoRepository.FindMedicamentoByName(nameMedicamento);

            if (producto != null)
            {
                return Json(producto);
            }
            return NotFound();
        }
    }
}
