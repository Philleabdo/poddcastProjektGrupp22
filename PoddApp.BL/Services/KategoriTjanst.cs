using MongoDB.Driver;
using PoddApp.BL.Interface;
using PoddApp.DAL;
using PoddApp.DAL.Interface;
using PoddApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoddApp.BL.Services
{
    public class KategoriTjanst : IKategoriTjanst
    {
        private readonly IPoddRepository _repo;

        private readonly IMongoCollection<Kategori> _kategorier;

        public KategoriTjanst(IPoddRepository repo)
        {
            _repo = repo;

            var db = new MongoDatabas();
            _kategorier = db.Kategorier;
        }


        public async Task<Kategori> SkapaKategoriAsync(string namn)
        {
            if (string.IsNullOrWhiteSpace(namn))
                throw new ArgumentException("Kategorin måste ha ett namn.");

            var trimNamn = namn.Trim();

            // Kolla om det redan finns en kategori med samma namn
            var filter = Builders<Kategori>.Filter.Eq(k => k.Namn, trimNamn);
            bool finnsRedan = await _kategorier.Find(filter).AnyAsync();

            if (finnsRedan)
                throw new InvalidOperationException("En kategori med detta namn finns redan.");

            var nyKategori = new Kategori
            {
                Id = Guid.NewGuid().ToString(),
                Namn = trimNamn
            };

            await _kategorier.InsertOneAsync(nyKategori);

            return nyKategori;
        }

        public async Task<List<Kategori>> HamtaAllaKategorierAsync()
        {
            // Hämta alla kategorier från databasen
            return await _kategorier.Find(_ => true).ToListAsync();
        }

        public async Task AndraNamnAsync(string kategoriId, string nyttNamn)
        {
            if (string.IsNullOrWhiteSpace(nyttNamn))
                throw new ArgumentException("Nytt namn får inte vara tomt.");

            var trimNyttNamn = nyttNamn.Trim();

            // Finns kategorin?
            var kategori = await _kategorier
                .Find(k => k.Id == kategoriId)
                .FirstOrDefaultAsync();

            if (kategori == null)
                throw new Exception("Kategorin finns inte.");

            // Kolla om någon annan kategori har samma namn
            bool namnUpptaget = await _kategorier
                .Find(k => k.Namn == trimNyttNamn && k.Id != kategoriId)
                .AnyAsync();

            if (namnUpptaget)
                throw new InvalidOperationException("En annan kategori har redan detta namn.");

            var update = Builders<Kategori>.Update.Set(k => k.Namn, trimNyttNamn);

            await _kategorier.UpdateOneAsync(k => k.Id == kategoriId, update);
        }

        public async Task TaBortKategoriAsync(string kategoriId)
        {
            var result = await _kategorier.DeleteOneAsync(k => k.Id == kategoriId);

            if (result.DeletedCount == 0)
                throw new InvalidOperationException("Kategorin finns inte.");
        }

    }

}
