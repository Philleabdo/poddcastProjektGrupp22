using PoddApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoddApp.BL.Interface
{
    public interface IKategoriTjanst
    {
        Task<Kategori> SkapaKategoriAsync(string namn);
        Task<List<Kategori>> HamtaAllaKategorierAsync();
        Task AndraNamnAsync(string kategoriId, string nyttNamn);
        Task TaBortKategoriAsync(string kategoriId);

        Task<Kategori> AndraKategoriNamnAsync(string kategoriId, string nyttNamn);
    }
}
