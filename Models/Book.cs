using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class Book
    {
        [Key] // Primary Key for each book
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        [RegularExpression("[0-9]{3}[-][0-9]{10}")] // Require ###-########## format
        public string ISBN { get; set; }
        public string Classification { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
    }
}
