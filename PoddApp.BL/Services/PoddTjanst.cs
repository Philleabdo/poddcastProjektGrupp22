using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using PoddApp.Models;

namespace PoddApp.BL.Services
{
    public class PoddTjanst
    {
        //Tillfälligt register (byter till MongoDB senare)
        private List<Poddflode> _poddar = new List<Poddflode>();
        private List<Avsnitt> _avsnitt = new List<Avsnitt>();

        public void SparaNyPodd(string visningsNamn, string rssUrl, List<Avsnitt> avsnitt)
        {
            //Spara ny podd + dess avsnitt
            string nyttId = Guid.NewGuid().ToString();

            //Skapa poddobjekt
            Poddflode podd = new Poddflode
            {
                Id = nyttId,
                Namn = visningsNamn,
                RssUrl = rssUrl,
                SkapaDatum = DateTime.Now
            };
            //Lägg till i listan
            _poddar.Add(podd);
            //Koppla varje avsnitt till podden och spara dem
            foreach (var a in avsnitt)
            {
                a.PoddflodeId = nyttId;
                _avsnitt.Add(a);
            }
        }
        //Hämta alla sparade poddar (till Form2 vänster lista)
        public List<Poddflode> HamtaAllaPoddar()
        {
            return _poddar;
        }
        //Hämtar alla avsnitt som tillhör en viss podd (så Form 2 kan visa)
        public List<Avsnitt> HamtaAvsnittForPodd(string poddId)
        {
            List<Avsnitt> resultat = new List<Avsnitt>();

            foreach (var a in _avsnitt)
            {
                if (a.PoddflodeId == poddId)
                    resultat.Add(a);
            }

            return resultat;
        }

        public void TaBortPodd(string poddId)
        {
            //Ta bort podd
            _poddar.RemoveAll(p => p.Id == poddId);
            //Ta bort avsnitt
            _avsnitt.RemoveAll(a => a.PoddflodeId == poddId);
        }
    }
}
