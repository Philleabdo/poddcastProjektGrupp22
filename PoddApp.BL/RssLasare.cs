using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PoddApp.Models;

namespace PoddApp.BL
{
    public class RssLasare
    {
        public async Task<List<Avsnitt>> HamtaAvsnittAsync(string rssUrl)
        {
            return new List<Avsnitt>();
        }

        private List<Avsnitt> TolkaRssXml(string rssXml)
        {
            return new List<Avsnitt>();
        }

        public List<Avsnitt> HamtaAvsnitt(string rssUrl)
        {
            return new List<Avsnitt>();
        }
    }
}

