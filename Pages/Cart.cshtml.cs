using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment6.Infrastructure;
using Assignment6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment6.Pages
{
    public class CartModel : PageModel
    {
        // Razor page model
        private IBookStoreRepository repository;
        public CartModel(IBookStoreRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            // get cart method
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(long bookId, string returnUrl)
        {
            // add item to cart post method
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);
            Cart.AddItem(book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            // remove line item from cart post method
            Cart.RemoveLine(Cart.Lines.First(c =>
            c.Book.BookId == bookId).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
