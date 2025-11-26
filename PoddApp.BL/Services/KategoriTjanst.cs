using System;
using System.Collections.Generic;
using System.Text;
using PoddApp.Models;

namespace PoddApp.BL.Services
{
    public class KategoriTjanst
    {
        private readonly List<Kategori> kategorier = new List<Kategori>();


        public Kategori SkapaKategori(string namn)
        {
            // 1. Validering
            if (string.IsNullOrWhiteSpace(namn))
                throw new ArgumentException("Kategorin måste ha ett namn.");

            // 2. Kolla om kategorin redan finns (case insensitive)
            bool finnsRedan = kategorier
                .Exists(k => k.Namn.Equals(namn, StringComparison.OrdinalIgnoreCase));

            if (finnsRedan)
                throw new InvalidOperationException("En kategori med detta namn finns redan.");


            // 3. Skapa kategorin
            var nyKategori = new Kategori
            {
                Id = Guid.NewGuid().ToString(),
                Namn = namn.Trim()
            };

           // 4. Lägg till
            kategorier.Add(nyKategori);

            return nyKategori;
        }

        public List<Kategori> HamtaAllaKategorier()
        {
            // Returnera kopia så Ui inte kan råka ändra listan direkt
            return new List<Kategori>(kategorier);
        }

        public void AndraNamn(string kategoriId, string nyttNamn)
        {
            if (string.IsNullOrWhiteSpace(nyttNamn))
                throw new ArgumentException("Nytt namn får inte vara tomt.");

            var kategori = kategorier.Find(k => k.Id == kategoriId);


            if (kategori == null)
                throw new Exception("Kategorin finns inte.");

            // Kolla om någon annan kategori har samma namn
            if (kategorier.Exists(k =>
            k.Namn.Equals(nyttNamn, StringComparison.OrdinalIgnoreCase) &&
            k.Id != kategoriId))
            {
                throw new InvalidOperationException("En annan kategori har redan detta namn.");
            }

            kategori.Namn = nyttNamn.Trim();
        }

        public void TaBortKategori(string kategoriId)
        {
            int antalBorttagna = kategorier.RemoveAll(k => k.Id == kategoriId);

            if (antalBorttagna == 0)
                throw new InvalidOperationException("Kategorin finns inte.");
        }

    }

}
