using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PoddApp.BL.Interface;
using PoddApp.DAL;
using PoddApp.DAL.Interface;
using PoddApp.Models;

namespace PoddApp.BL.Services
{
    public class PoddTjanst : IPoddTjanst
    {

        private readonly IPoddRepository _repo;

        public PoddTjanst(IPoddRepository repo)
        {
            _repo = repo;
        }


        public PoddTjanst() 
        { 
            _repo = new PoddRepository();
        }

        public async Task SparaNyPoddAsync(string visningsNamn, string rssUrl, string kategoriNamn, List<Avsnitt> avsnitt)
        {
            if (string.IsNullOrWhiteSpace(rssUrl))
                throw new ArgumentException("RSS-URL får inte vara tom.");

            bool finnsRedan = await _repo.PoddMedUrlFinnsAsync(rssUrl);
            if(finnsRedan)
            {
                throw new InvalidOperationException("Den här podden finns redan sparad.");
            }

            var podd = new Poddflode
            {
                Namn = visningsNamn,
                RssUrl = rssUrl,
                Kategori = kategoriNamn,
                SkapaDatum = DateTime.Now,
            };

           await _repo.SparaNyPoddAsync(podd, avsnitt);
        }

        public async Task<List<Poddflode>> HamtaAllaPoddarAsync() 
        { 
            return await _repo.HamtaAllaPoddarAsync();
        }

        public async Task<List<Avsnitt>> HamtaAvsnittForPoddAsync(string poddId)
        {
            return await _repo.HamtaAvsnittForPoddAsync(poddId);
        }

        public async Task TaBortPoddAsync(string poddId)
        {
           await _repo.TaBortPoddAsync(poddId);
        }

        public async Task AndraNamnAsync(string poddId, string nyttNamn)
        {
            if (string.IsNullOrWhiteSpace(nyttNamn))
                throw new ArgumentException("Nytt namn får inte vara tomt.");

            await _repo.UppdateraPoddNamnAsync(poddId, nyttNamn.Trim());
        }

        

        public async Task<bool> PoddMedUrlFinnsAsync(string rssUrl)
        {
            if (string.IsNullOrWhiteSpace(rssUrl))
                throw new ArgumentException("RSS-URL får inte vara tom.");

            var allaPoddar = await _repo.HamtaAllaPoddarAsync();

            return allaPoddar.Exists(p =>
                p.RssUrl.Equals(rssUrl, StringComparison.OrdinalIgnoreCase));
        }

       
    }
}
