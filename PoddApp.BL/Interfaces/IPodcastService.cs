using PoddApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoddApp.BL.Interfaces
{
    public interface IPodcastService
    {
        Task<List<Poddflode>> HamtaAllaAsync();
        Task<Poddflode> HamtaMedIdAsync();
        Task SkapaPodcastAsync(string rssUrl, string namn, string kategori);
        Task UppdateraPodcastNamnAsync(string id, string nyttNamn);
        Task UppdateraKategoriAsync(string id, string nyKategori);
        Task TaBortPoddAsync(string id);
    }
}
