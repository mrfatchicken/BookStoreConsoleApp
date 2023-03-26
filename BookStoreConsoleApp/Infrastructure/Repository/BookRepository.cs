﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Infrastructure.Entities;

namespace WpfApp2.Infrastructure.Repository
{
  public class BookRepository : IBookRepository
  {
    private readonly string _filePath;

    public BookRepository(string filePath)
    {
      _filePath = filePath;
    }

    public List<Book> GetAll()
    {
      List<Book> books = new List<Book>();

      if (File.Exists(_filePath))
      {
        using StreamReader reader = new StreamReader(_filePath);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
          string[] bookInfo = line.Split(';');
          Book book = new Book
          {
            Id = Guid.Parse(bookInfo[0]),
            Title = bookInfo[1],
            Author = bookInfo[2],
            Genre = bookInfo[3],
            PublishedYear = int.Parse(bookInfo[4]),
            IsAvailable = bool.Parse(bookInfo[5])
          };
          books.Add(book);
        }
      }
      return books.OrderBy(b => b.Title).ToList();
    }

    public void SaveAll(List<Book> books)
    {
      using StreamWriter writer = new StreamWriter(_filePath, false);
      foreach (Book book in books)
      {
        string bookLine = $"{book.Id};{book.Title};{book.Author};{book.Genre};{book.PublishedYear};{book.IsAvailable}";
        writer.WriteLine(bookLine);
      }
    }

    public void Add(Book book)
    {
      List<Book> books = GetAll();
      book.Id = Guid.NewGuid();
      books.Add(book);
      SaveAll(books);
    }

    public void Update(Book book)
    {
      List<Book> books = GetAll();
      Book bookToUpdate = books.FirstOrDefault(b => b.Id == book.Id);
      if (bookToUpdate != null)
      {
        bookToUpdate.Title = book.Title;
        bookToUpdate.Author = book.Author;
        bookToUpdate.Genre = book.Genre;
        bookToUpdate.PublishedYear = book.PublishedYear;
        bookToUpdate.IsAvailable = book.IsAvailable;
        SaveAll(books);
      }
    }

    public void Delete(Guid id)
    {
      List<Book> books = GetAll();
      Book bookToRemove = books.FirstOrDefault(b => b.Id == id);
      if (bookToRemove != null)
      {
        books.Remove(bookToRemove);
        SaveAll(books);
      }
    }
  }
}