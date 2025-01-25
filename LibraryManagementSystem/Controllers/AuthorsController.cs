using LibraryManagementSystem.Data;
using LibraryManagementSystem.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers;

public class AuthorsController(LibraryContext context) : Controller
{
    public IActionResult Authors()
    {
        // DO NOT MODIFY ABOVE THIS LINE
        
        var authors = context.Authors
            .Include(a => a.Books)
            .ToList();
        return View(authors);
        // Refer to similar listing for Members
        // throw new NotImplementedException("AuthorsController.Authors is not implemented");
        // DO NOT MODIFY BELOW THIS LINE

    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Author author)
    {
        // DO NOT MODIFY ABOVE THIS LINE
        if (ModelState.IsValid)
        {
            context.Authors.Add(author);
            context.SaveChanges();
            return RedirectToAction("Authors");
        }
        return View(author);
        

        // throw new NotImplementedException("AuthorsController.Add is not implemented");
        // DO NOT MODIFY BELOW THIS LINE
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        // DO NOT MODIFY ABOVE THIS LINE
        var author = context.Authors.Find(id);
        if (author == null)
        {
            return NotFound();
        }

        context.Authors.Remove(author);
        context.SaveChanges();
        return RedirectToAction("Authors");
        }

    [HttpGet]
    public IActionResult Update(int id)
    {
        // DO NOT MODIFY ABOVE THIS LINE
        var author = context.Authors.Find(id);
        if(author == null)
        {
            return NotFound();
        }
        return View(author);
        // throw new NotImplementedException("AuthorsController.Update is not implemented");
        // DO NOT MODIFY BELOW THIS LINE
    }

    [HttpPost]
    public IActionResult Update(Author author)
    {
        // DO NOT MODIFY ABOVE THIS LINE
        // throw new NotImplementedException("AuthorsController.Update is not implemented");
        // DO NOT MODIFY BELOW THIS LINE
        if (ModelState.IsValid)
        {
            context.Authors.Update(author);
            context.SaveChanges();
            return RedirectToAction("Authors");
        }
        return View(author);
    }
}