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

        //spara ny podd + avsnitt 
        public async Task SparaNyPoddAsync(Poddflode podd, List<Avsnitt> avsnitt) 
        {

           await _context.Poddfloden.InsertOneAsync(podd);

            foreach(var a in avsnitt) 
            { 
                a.PoddflodeId = podd.Id;
            }

            if(avsnitt.Count > 0) 
            { 
               await _context.Avsnitt.InsertManyAsync(avsnitt);
            }

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
            var poddFilter = Builders<Poddflode>.Filter.Eq(p => p.Id, poddId);
            await _context.Poddfloden.DeleteOneAsync(poddFilter);

            var avsnittFilter = Builders<Avsnitt>.Filter.Eq(a => a.PoddflodeId, poddId);
            _context.Avsnitt.DeleteManyAsync(avsnittFilter);
        }

        public async Task <bool> PoddMedUrlFinnsAsync(string rssUrl)
        {
            var allaPoddar = await HamtaAllaPoddarAsync ();
            return allaPoddar.Exists(p =>
                p.RssUrl.Equals(rssUrl, StringComparison.OrdinalIgnoreCase));
        }


    }
}
