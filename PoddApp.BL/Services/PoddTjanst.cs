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

        public Task AndraNamnAsync(string poddId, string nyttNamn)
        {
            // Kräver att PoddRepository får stöd för uppdatering.
            // Just nu slänger vi exception så du ser att det inte finns implementation ännu.
            throw new NotImplementedException("ÄndraNamnAsync är inte implementerad ännu.");
        }

        

        public async Task<bool> PoddMedUrlFinnsAsync(string rssUrl)
        {
            if (string.IsNullOrWhiteSpace(rssUrl))
                throw new ArgumentException("RSS-URL får inte vara tom.");

            var allaPoddar = await _repo.HamtaAllaPoddarAsync();

            return allaPoddar.Exists(p =>
                p.RssUrl.Equals(rssUrl, StringComparison.OrdinalIgnoreCase));
        }

        //Tillfälligt register (byter till MongoDB senare)
        //private List<Poddflode> _poddar = new List<Poddflode>();
        //private List<Avsnitt> _avsnitt = new List<Avsnitt>();

        //public void SparaNyPodd(string visningsNamn, string rssUrl, List<Avsnitt> avsnitt)
        //{
        //    //Spara ny podd + dess avsnitt
        //    string nyttId = Guid.NewGuid().ToString();

        //    //Skapa poddobjekt
        //    Poddflode podd = new Poddflode
        //    {
        //        Id = nyttId,
        //        Namn = visningsNamn,
        //        RssUrl = rssUrl,
        //        SkapaDatum = DateTime.Now
        //    };
        //    //Lägg till i listan
        //    _poddar.Add(podd);
        //    //Koppla varje avsnitt till podden och spara dem
        //    foreach (var a in avsnitt)
        //    {
        //        a.PoddflodeId = nyttId;
        //        _avsnitt.Add(a);
        //    }
        //}
        ////Hämta alla sparade poddar (till Form2 vänster lista)
        //public List<Poddflode> HamtaAllaPoddar()
        //{
        //    return _poddar;
        //}
        ////Hämtar alla avsnitt som tillhör en viss podd (så Form 2 kan visa)
        //public List<Avsnitt> HamtaAvsnittForPodd(string poddId)
        //{
        //    List<Avsnitt> resultat = new List<Avsnitt>();

        //    foreach (var a in _avsnitt)
        //    {
        //        if (a.PoddflodeId == poddId)
        //            resultat.Add(a);
        //    }

        //    return resultat;
        //}

        //public void TaBortPodd(string poddId)
        //{
        //    //Ta bort podd
        //    _poddar.RemoveAll(p => p.Id == poddId);
        //    //Ta bort avsnitt
        //    _avsnitt.RemoveAll(a => a.PoddflodeId == poddId);
        //}
    }
}
