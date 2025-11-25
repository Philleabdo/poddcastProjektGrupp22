using PoddApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoddApp.BL.Interfaces
{
    internal interface IPoddFlodeService
    {
        Task Spara();
        Task<List<Poddflode>> HamtaAllaAsync();
        Task<Poddflode> HamtaMedIdAsync(string id);
        Task SkapaAsync(string rssUrl, string namn, string kategori);
        Task UppdateraKategoriAsync(string id, string nyKategori);
        Task RaderaAsync(string id);
    }
}
