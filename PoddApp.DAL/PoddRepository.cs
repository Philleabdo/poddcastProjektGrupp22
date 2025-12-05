using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using PoddApp.DAL.Interface;
using PoddApp.Models;

namespace PoddApp.DAL
{
    public class PoddRepository : IPoddRepository
    {
        private readonly MongoDatabas _context;

         public PoddRepository() 
        {
            _context = new MongoDatabas();
        }

        public async Task ExecuteTransactionAsync (Func<IClientSessionHandle, Task> action)
        {
            using var session = await _context.Client.StartSessionAsync();

            session.StartTransaction();
            try
            {
                await action(session);
                await session.CommitTransactionAsync();
            }
            catch
            {
                await session.AbortTransactionAsync();
                throw;
            }
        }
        //spara ny podd + avsnitt 
        public async Task SparaNyPoddAsync(Poddflode podd, List<Avsnitt> avsnitt) 
        {
            await ExecuteTransactionAsync(async session =>
            {

                await _context.Poddfloden.InsertOneAsync(session, podd);

                foreach (var a in avsnitt)
                {
                    a.PoddflodeId = podd.Id;
                }

                if (avsnitt.Count > 0)
                {
                    await _context.Avsnitt.InsertManyAsync(session, avsnitt);
                }

            });

        }


        public async Task<List<Poddflode>> HamtaAllaPoddarAsync() 
        {

            return await _context.Poddfloden.Find(p => true).ToListAsync();//

        }



        public async Task<List<Avsnitt>> HamtaAvsnittForPoddAsync(string poddId) 
        { 
        
            var filter = Builders<Avsnitt>.Filter.Eq(a=> a.PoddflodeId, poddId);

            return await _context.Avsnitt.Find(filter).ToListAsync();


        }


        public async Task TaBortPoddAsync(string poddId) 
        {
            await ExecuteTransactionAsync(async session =>
            {

                var poddFilter = Builders<Poddflode>.Filter.Eq(p => p.Id, poddId);
                await _context.Poddfloden.DeleteOneAsync(session, poddFilter);

                var avsnittFilter = Builders<Avsnitt>.Filter.Eq(a => a.PoddflodeId, poddId);
                await _context.Avsnitt.DeleteManyAsync(session, avsnittFilter);
            });
        }

        public async Task UppdateraPoddNamnAsync(string poddId, string nyttNamn)
        {
            await ExecuteTransactionAsync(async session =>
            {
                var filter = Builders<Poddflode>.Filter.Eq(p => p.Id, poddId);
                var update = Builders<Poddflode>.Update.Set(p => p.Namn, nyttNamn);

                await _context.Poddfloden.UpdateOneAsync(session, filter, update);
            });
        }

        public async Task <bool> PoddMedUrlFinnsAsync(string rssUrl)
        {
            var allaPoddar = await HamtaAllaPoddarAsync ();
            return allaPoddar.Exists(p =>
                p.RssUrl.Equals(rssUrl, StringComparison.OrdinalIgnoreCase));
        }


    }
}
