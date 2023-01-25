using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UTB.Eshop.Domain.Abstraction;
using UTB.Eshop.Web.Models.Database;
using UTB.Eshop.Web.Models.Entities;
using UTB.Eshop.Web.Models.Identity;
using UTB.Eshop.Web.Models.ViewModels;


namespace UTB.Eshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class ProductsController : Controller
    {
        private readonly EshopDbContext _context;
        IFileUpload fileUpload;
        ICheckFileContent checkFileContent;
        ICheckFileLength checkFileLength;

        public ProductsController(EshopDbContext context, IFileUpload fileUpload, ICheckFileContent checkFileContent, ICheckFileLength checkFileLength)
        {
            _context = context;
            this.fileUpload = fileUpload;
            this.checkFileContent = checkFileContent;
            this.checkFileLength = checkFileLength;

        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductItemImageRequired product)
        {
            ModelState.Remove(nameof(product.ImageSrc));
            if (ModelState.IsValid)
            {
                if (checkFileLength.CheckFileLength(product.Image, 5_000_000) && checkFileContent.CheckFileContent(product.Image, "image"))
                {
                    fileUpload.ContentType = "image";
                    fileUpload.FileLength = 5_000_000; // 5MB
                    product.ImageSrc = await fileUpload.FileUploadAsync(product.Image, Path.Combine("img", "products"));

                    if (TryValidateModel(product))
                    {
                        _context.Add(product);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }

                }
            }

            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductItemImageRequired product)
        {

            var newProduct = _context.Products.FirstOrDefault(x => x.ID == product.ID);
           


            if (newProduct != null)
            {

               ModelState.Remove(nameof(Product.ImageSrc));
                if (ModelState.IsValid)
                {
                    if (product.Image != null)
                    {
                        if (checkFileLength.CheckFileLength(product.Image, 5_000_000) && checkFileContent.CheckFileContent(product.Image, "image"))
                        {
                            fileUpload.ContentType = "image";
                            fileUpload.FileLength = 5_000_000;
                            product.ImageSrc = await fileUpload.FileUploadAsync(product.Image, Path.Combine("img", "products"));

                            ModelState.Clear();
                            if (TryValidateModel(product))
                            {
                                var oldImage = newProduct.ImageSrc;
                                newProduct.ImageSrc = product.ImageSrc;
                                var pom = _context.Products.Where(x => x.ImageSrc == oldImage && x.ID != product.ID);
                                if(!pom.Any())
                                {
                                    var base_path = Directory.GetCurrentDirectory() + "\\wwwroot\\" + oldImage;
                                    System.IO.File.Delete(base_path);

                                }
                            }
                            else
                                return View(product);
                        }
                        else
                            return View(product);
                    }

                    newProduct.Name = product.Name;
                    newProduct.Price = product.Price;
                    newProduct.ImageAlt = product.ImageAlt;

                    _context.Update(newProduct);
                    await _context.SaveChangesAsync();


                    return RedirectToAction(nameof(Index));
                }
                else
                    return View(product);
            }

            return NotFound();


        }


        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           
            var product = await _context.Products.FindAsync(id);
            var picture = product.ImageSrc;

            // do pom se uloží produkty se stejnym img ale jinym id
            var pom = _context.Products.Where(x => x.ImageSrc == picture && x.ID != id); 
            var base_path = Directory.GetCurrentDirectory() + "\\wwwroot\\" + picture;
            
            // pokud je nesmazu obrazek
            if (!pom.Any())
            {
                System.IO.File.Delete(base_path);
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
    }
}
