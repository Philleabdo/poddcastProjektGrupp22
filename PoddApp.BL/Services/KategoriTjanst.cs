using System;
using System.Collections.Generic;
using System.Text;
using PoddApp.Models;

namespace PoddApp.BL.Services
{
    public class KategoriTjanst
    {
        private List<Kategori> kategorier = new List<Kategori>();


        public void SkapaKategori(string namn)
        {
            if (string.IsNullOrWhiteSpace(namn))
                throw new ArgumentException("Kategorin måste ha ett namn.");



            foreach (var kategori in kategorier)
            {
                if (kategori.Namn.Equals(namn, StringComparison.OrdinalIgnoreCase))
                    throw new Exception("En kategori med detta namn finns redan.");

            }

            var nyKategori = new Kategori
            {
                Id = Guid.NewGuid().ToString(),
                Namn = namn
            };

            kategorier.Add(nyKategori);
        }

        public List<Kategori> HamtaAllaKategorier()
        {
            return kategorier;
        }

        public void AndraNamn(string kategoriId, string nyttNamn)
        {
            if (string.IsNullOrWhiteSpace(nyttNamn))
                throw new ArgumentException("Nytt namn får inte vara tomt.");

            var kategori = kategorier.Find(k => k.Id == kategoriId);


            if (kategori == null)
                throw new Exception("Kategorin finns inte.");

            kategori.Namn = nyttNamn;
        }

        public void TaBortKategori(string kategoriId)
        {
            kategorier.RemoveAll(k => k.Id == kategoriId);
        }

    }

}
