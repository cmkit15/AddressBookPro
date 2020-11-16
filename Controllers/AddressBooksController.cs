using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AddressBookPro.Data;
using AddressBookPro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace AddressBookPro.Controllers
{
    public class AddressBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddressBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AddressBooks
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.AddressBook.ToListAsync());
        }

        // GET: AddressBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressBook = await _context.AddressBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addressBook == null)
            {
                return NotFound();
            }

            //if (addressBook.Image != null)
            //{
            //    var binary = Convert.ToBase64String(addressBook.Image);
            //    //var ext = Path.GetExtension(addressBook.FileName);
            //    var ext = addressBook.FileName.Split('.')[1];
            //    string imageDataURL = $"data:image/{ext};base64,{binary}";
            //    ViewData["Image"] = imageDataURL;
            //}

            return View(addressBook);
        }

        // GET: AddressBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddressBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Image,Address1,Address2,City,State,ZipCode,Phone,DateAdded")] AddressBook addressBook, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                // Code for image upload
                //if (image != null)
                //{
                //    addressBook.FileName = image.FileName;
                //    // Entry level code that turns image into binary db
                //    var ms = new MemoryStream();
                //    image.CopyTo(ms);
                //    addressBook.Image = ms.ToArray();
                //    ms.Close();
                //    ms.Dispose();
                //}
                addressBook.DateAdded = DateTimeOffset.Now;
                _context.Add(addressBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addressBook);
        }

        // GET: AddressBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressBook = await _context.AddressBook.FindAsync(id);
            if (addressBook == null)
            {
                return NotFound();
            }
            return View(addressBook);
        }

        // POST: AddressBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Image,Address1,Address2,City,State,ZipCode,Phone,DateAdded")] AddressBook addressBook, IFormFile image, IFormFile newImage)
        {
            if (id != addressBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Code for image upload
                //if (image != null)
                //{
                //    addressBook.FileName = image.FileName;
                //    // Entry level code that turns image into binary db
                //    var ms = new MemoryStream();
                //    image.CopyTo(ms);
                //    addressBook.Image = ms.ToArray();
                //    ms.Close();
                //    ms.Dispose();
                //}
                // Code for image upload
                //if (newImage != null)
                //{
                //    addressBook.FileName = newImage.FileName;
                //    // Entry level code that turns image into binary db
                //    var ms = new MemoryStream();
                //    newImage.CopyTo(ms);
                //    addressBook.Image = ms.ToArray();
                //    ms.Close();
                //    ms.Dispose();
                //}
                try
                {
                    _context.Update(addressBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressBookExists(addressBook.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Details", "AddressBooks", new {addressBook.Id});
            }
            //return View(addressBook);
            return RedirectToAction("Details", "AddressBooks", new { addressBook.Id });
        }

        // GET: AddressBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressBook = await _context.AddressBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addressBook == null)
            {
                return NotFound();
            }

            return View(addressBook);
        }

        // POST: AddressBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addressBook = await _context.AddressBook.FindAsync(id);
            _context.AddressBook.Remove(addressBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressBookExists(int id)
        {
            return _context.AddressBook.Any(e => e.Id == id);
        }
    }
}
