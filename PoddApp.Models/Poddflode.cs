using System;
using System.Collections.Generic;
using System.Text;

namespace PoddApp.Models
{
    public class PoddFlode
    {
        public string Id { get; set; }
        public string Namn { get; set; }
        public string RssUrl { get; set; }
        public string Kategori { get; set; }
        public DateTime SkapaDatum { get; set; }
    }
}
