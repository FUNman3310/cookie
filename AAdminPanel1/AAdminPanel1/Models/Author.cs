﻿namespace AAdminPanel1.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public List<Book> books { get; set; }
    }
}
