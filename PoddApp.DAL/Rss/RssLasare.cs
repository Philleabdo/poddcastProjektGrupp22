using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PoddApp.Models;
using System.Net.Http;
using System.Xml.Linq;

namespace PoddApp.DAL.Rss
{
    public class RssLasare
    {
        public async Task<List<Avsnitt>> HamtaAvsnittAsync(string rssUrl)
        {
            //Hämtar RSS som en rå XML-text
            using (var client = new HttpClient())
            {
                string rssXml = await client.GetStringAsync(rssUrl);

                //Tolkar XML och bygger lista med Avsnitt
                return TolkaRssXml(rssXml);
            }
        }

        private List<Avsnitt> TolkaRssXml(string rssXml)
        {
            //Lista som vi fyller med avsnitt
            var resultat = new List<Avsnitt>();

                //Laddar in en XML-sträng som ett dokument 
                var doc = XDocument.Parse(rssXml);

            //Hittar alla items noder i RSS
                var items = doc.Descendants("item");

                foreach (var item in items)
                {
                    string titel = item.Element("title")?.Value ?? "(saknar titel)";
                    string link = item.Element("link")?.Value ?? "";
                    string beskrivning = item.Element("description")?.Value ?? "";

                    DateTime pubDate = DateTime.MinValue;
                    var pubDateText = item.Element("pubDate")?.Value;
                    if (!string.IsNullOrWhiteSpace(pubDateText))
                    {
                        DateTime.TryParse(pubDateText, out pubDate);
                    }

                    var avsnitt = new Avsnitt
                    {
                        Id = Guid.NewGuid().ToString(),
                        Titel = titel,
                        Lank = link,
                        Beskrivning = beskrivning,
                        PubliceringsDatum = pubDate
                    };
                //Lägger till i listan
                    resultat.Add(avsnitt);
                }
              return resultat;
        }

        public List<Avsnitt> HamtaAvsnitt(string rssUrl)
        {
            return new List<Avsnitt>();
        }
    }
}

