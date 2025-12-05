using PoddApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoddApp.BL.Interface
{
    public interface IPoddTjanst
    {
        Task<List<Poddflode>> HamtaAllaPoddarAsync();
        Task<List<Avsnitt>> HamtaAvsnittForPoddAsync(string poddId);

        Task SparaNyPoddAsync(string visningsnamn, string rssUrl, string kategoriId, List<Avsnitt> avsnitt);
        Task AndraNamnAsync(string poddId, string nyttNamn);
        Task TaBortPoddAsync(string poddId);
        Task<bool> PoddMedUrlFinnsAsync(string rssUrl);
        Task UppdateraKategoriNamnForPoddarAsync(string gammaltNamn, string nyttNamn);
    }

}
