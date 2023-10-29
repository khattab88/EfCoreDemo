using EfCoreDemo.Data;
using EfCoreDemo.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EfCoreDemo.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // GetAllBooks();

            // AddBook(new Book { Title="New Book", ISBN="1234", Publisher_Id=2 });

            // GetBook();

            // GetBooksByTitle("co");

            // UpdateBook(4, new Book { Title = "Chocolate Factory", Price = 15.90m });

            // DeleteBook(4);

            System.Console.ReadKey();
        }

        //static void GetAllBooks() 
        //{
        //    using var context = new ApplicationDbContext();

        //    var books = context.Books.OrderBy(b => b.Title).ToList();
        //    foreach (var book in books)
        //    {
        //        System.Console.WriteLine(book.Title);
        //    }
        //}

        //static void AddBook(Book book)
        //{
        //    using var context = new ApplicationDbContext();

        //    context.Books.Add(book);
        //    context.SaveChanges();

        //    System.Console.WriteLine("Newly created book id: " + book.Id);
        //}

        //static void GetBook() 
        //{
        //    using var context = new ApplicationDbContext();

        //    var book = context.Books.FirstOrDefault(b => b.Id == 1000);

        //    System.Console.WriteLine($"Book {book?.Title ?? "NO NAME"}");
        //}

        //static void GetBooksByTitle(string title)
        //{
        //    using var context = new ApplicationDbContext();

        //    var books = context.Books.Where(b => EF.Functions.Like(b.Title, "Co%"));
            
        //    foreach (var book in books) { System.Console.WriteLine(book.Title); }
        //}

        //static void UpdateBook(int id, Book book)
        //{
        //    using var context = new ApplicationDbContext();

        //    var existing = context.Books.Find(id);

        //    if(!string.IsNullOrEmpty(book.Title)) { existing.Title = book.Title; }
        //    if (!string.IsNullOrEmpty(book.ISBN)) { existing.Title = book.ISBN; }
        //    if (book.Price != 0) { existing.Price = book.Price; }
        //    if (book.Publisher_Id != 0) { existing.Publisher_Id = book.Publisher_Id; }

        //    context.Books.Update(existing);
        //    context.SaveChanges();
        //}

        //static void DeleteBook(int id)
        //{
        //    using var context = new ApplicationDbContext();

        //    var book = context.Books.Find(id);

        //    context.Books.Remove(book);
        //    context.SaveChanges();
        //}
    }
}