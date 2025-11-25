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

            return _context.Poddfloden.Find(p => true).ToList();

        }

    }
}
