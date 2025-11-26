using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using PoddApp.Models;

namespace PoddApp.DAL
{
    public class PoddRepository
    {
        private readonly MongoDatabas _context;


        public PoddRepository() 
        {
            _context = new MongoDatabas();
        }


        public void SparaNyPodd(Poddflode podd, List<Avsnitt> avsnitt) 
        {

            _context.Poddfloden.InsertOne(podd);

            foreach(var a in avsnitt) 
            { 
                a.PoddflodeId = podd.Id;
            }

            if(avsnitt.Count > 0) 
            { 
                _context.Avsnitt.InsertMany(avsnitt);
            }

        }


        public List<Poddflode> HamtaAllaPoddar() 
        {

            return _context.Poddfloden.Find(p => true).ToList();//

        }



        public List<Avsnitt> HamtaAvsnittForPodd(string poddId) 
        { 
        
            var filter = Builders<Avsnitt>.Filter.Eq(a=> a.PoddflodeId, poddId);

            return _context.Avsnitt.Find(filter).ToList();


        }


        public void TaBortPodd(string poddId) 
        { 
            var poddFilter = Builders<Poddflode>.Filter.Eq(p => p.Id, poddId);
            _context.Poddfloden.DeleteOne(poddFilter);

            var avsnittFilter = Builders<Avsnitt>.Filter.Eq(a => a.PoddflodeId, poddId);
            _context.Avsnitt.DeleteMany(avsnittFilter);
        }


    }
}
