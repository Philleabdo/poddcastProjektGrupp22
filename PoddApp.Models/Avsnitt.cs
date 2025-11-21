using System;
using System.Collections.Generic;
using System.Text;

namespace PoddApp.Models
{
    public class Avsnitt
    {
        public string Id { get; set; }
        public string PoddflodeId { get; set; }
        public string Titel{ get; set; }
        public string Lank { get; set; }
        public string Beskrivning { get; set; }
        public DateTime PubliceringsDatum { get; set; }

    }
}
