using PoddApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace PoddApp.DAL.Interface
{
    public interface IPoddRepository
    {
        Task SparaNyPoddAsync(Poddflode podd, List<Avsnitt> avsnitt);
        Task<List<Poddflode>> HamtaAllaPoddarAsync();
        Task<List<Avsnitt>> HamtaAvsnittForPoddAsync(string poddId);
        Task TaBortPoddAsync(string poddId);
        Task<bool> PoddMedUrlFinnsAsync(string rssUrl);
    }
}
