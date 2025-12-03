using System;
using System.Windows.Forms;
using PoddApp.DAL.Rss;
using PoddApp.Models;
using PoddApp.BL.Services;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace poddcastProjektGrupp22
{
    public partial class Form1 : Form
    {
        private RssLasare _rssLasare;
        private List<Avsnitt> _senasteAvsnitt;
        private List<Avsnitt> _aktuellaAvsnitt;
        private PoddTjanst _poddTjanst;
        private List<Poddflode> _sparadePoddar;
        private readonly KategoriTjanst _kategoriTjanst = new KategoriTjanst();


        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;

            _rssLasare = new RssLasare();
            _senasteAvsnitt = new List<Avsnitt>();
            _poddTjanst = new PoddTjanst();
            _sparadePoddar = new List<Poddflode>();

            buttonNyhetsskalla.Click += buttonNyhetsskalla_Click;
            buttonSpara.Click += buttonSpara_Click;
            buttonVisa.Click += buttonVisa_Click;
            buttonVisaSparadePoddar.Click += buttonVisaSparadePoddar_Click;
            buttonRadera.Click += buttonRadera_Click;

            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
        }

        private async void buttonNyhetsskalla_Click(object sender, EventArgs e)
        {
            if (!ValideraUrlFalt())
            {
                return;
            }

            string url = textBoxURL.Text.Trim();
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Du måste ange en URL.", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _senasteAvsnitt = await _rssLasare.HamtaAvsnittAsync(url);

                listBoxInformation.Items.Clear();
                listBoxLankar.Items.Clear();

                if (_senasteAvsnitt == null || _senasteAvsnitt.Count == 0)
                {
                    MessageBox.Show("Inga avsnitt hittades för den här URL:en");
                    return;
                }

                foreach (var avsnitt in _senasteAvsnitt)
                {
                    listBoxInformation.Items.Add(avsnitt.Titel);

                    string infoRad = $"{avsnitt.PubliceringsDatum:yyyy-MM-dd} - {avsnitt.Lank}";
                    listBoxLankar.Items.Add(infoRad);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ett fel uppstod när RSS-flödet skulle hämtas.\n" + ex.Message);
            }
        }

        private void buttonSpara_Click(object sender, EventArgs e)
        {
            string url = textBoxURL.Text.Trim();

            //Kontrollerar att URL finns
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Du måste ange en URL innan du sparar.", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Kontroll att vi faktiskt har hämtaat avsnitt 
            if (_senasteAvsnitt == null || _senasteAvsnitt.Count == 0)
            {
                MessageBox.Show("Det finns inga avsnitt att spara. Hämta först.", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Här kan man välja ett snyggare namn senare, från RSS-titel
            string visningNamn = url;

            //Hämtar valda kategorier
            string kategoriText = comboBoxKategori.Text.Trim();

            if (string.IsNullOrWhiteSpace(kategoriText))
            {
                kategoriText = "(Ingen kategori)";
            }

            string kategoriNamn;
            if (kategoriText == "(Ingen kategori)")
            {
                kategoriNamn = kategoriText;
            }
            else
            {
                var befintlig = _kategoriTjanst
                    .HamtaAllaKategorier()
                    .Find(k => k.Namn.Equals(kategoriText, StringComparison.OrdinalIgnoreCase));
                if (befintlig == null)
                {
                    befintlig = _kategoriTjanst.SkapaKategori(kategoriText);
                    comboBoxKategori.Items.Add(befintlig.Namn);
                }
                kategoriNamn = befintlig.Namn;
            }

            _poddTjanst.SparaNyPodd(visningNamn, url, kategoriNamn, _senasteAvsnitt);
            MessageBox.Show("Källan har sparats i registret.");
        }

        private bool ValideraUrlFalt()
        {
            string url = textBoxURL.Text.Trim();

            //Kolla om tomt
            if (string.IsNullOrEmpty(url))
            {
                errorProvider1.SetError(textBoxURL, "URL-fältet får inte vara tomt.");
                return false;
            }

            //Kollar om det ser ut som ett giltligt URL
            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) ||
            (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps))
            {
                errorProvider1.SetError(textBoxURL, "Ogiltligt URL. Ange en riktig länk (http/https).");
                return false;
            }
            //Ifall allt är okej så tar det bort felet
            errorProvider1.SetError(textBoxURL, "");
            return true;
        }

        private async void buttonVisa_Click(object sender, EventArgs e)
        {
            int idx = listBox1.SelectedIndex;
            //Kolla att en källa är vald i listBox1
            if (idx < 0 || idx >= _sparadePoddar.Count)
            {
                MessageBox.Show("Välj en källa i listan först.");
                return ;
            }
            //Hämta valda podd utifrån index
            var valdPodd = _sparadePoddar[idx];
            //Hämta avsnitt för vald podd
            var avsnitt = await _poddTjanst.HamtaAvsnittForPoddAsync(valdPodd.Id);

            //Sparar i fältet så att vi kan slå ihop info när man klickar på listBox2
            _aktuellaAvsnitt = avsnitt;

            //Töm listor på page 2
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            //Fyll med titlar + datum + länk
            foreach (var a in avsnitt)
            {
                listBox2.Items.Add(a.Titel);

                string infoRad = $"{a.PubliceringsDatum:yyyy-MM-dd} - {a.Lank}";
                listBox3.Items.Add(infoRad);
            }
        }

        private async Task LaddaSparadePoddar()
        {
            var allaPoddar = await _poddTjanst.HamtaAllaPoddarAsync();

            _sparadePoddar = allaPoddar;

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            foreach (var podd in _sparadePoddar)
            {
                //Länken
                listBox1.Items.Add(podd.RssUrl);

                //Info
                listBox2.Items.Add(podd.Namn + " - " + podd.SkapaDatum.ToString("yyyy-MM-dd"));

                string kategoriNamn = string.IsNullOrWhiteSpace(podd.Kategori)
                    ? "(Ingen kategori)"
                    : podd.Kategori;
                //Kategori
                listBox3.Items.Add(kategoriNamn);
            }
        }

        private void buttonRadera_Click(object sender, EventArgs e)
        {
            int idx = listBox1.SelectedIndex;

            if (idx < 0 || idx >= _sparadePoddar.Count)
            {
                MessageBox.Show("Välj en källa att radera.");
                return;
            }

            var valdPodd = _sparadePoddar[idx];

            var svar = MessageBox.Show(
                $"Vill du verkligen ta bort '{valdPodd.Namn}'?",
                "Bekräfta borttagningen",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (svar == DialogResult.Yes)
            {
                _poddTjanst.TaBortPoddAsync(valdPodd.Id);

                //Ladda om listan med sparade poddar
                LaddaSparadePoddar();

                //Töm avsnittslistorna
                listBox2.Items.Clear();
                listBox3.Items.Clear();
            }
        }

        private void buttonVisaSparadePoddar_Click(object sender, EventArgs e)
        {
            LaddaSparadePoddar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _kategoriTjanst.SkapaKategori("Nyheter");
            _kategoriTjanst.SkapaKategori("Teknik");
            _kategoriTjanst.SkapaKategori("Sport");
            _kategoriTjanst.SkapaKategori("Underhållning");

            comboBoxKategori.Items.Clear();

            var kategorier = _kategoriTjanst.HamtaAllaKategorier();

            foreach (var k in kategorier)
            {
                comboBoxKategori.Items.Add(k.Namn);
            }

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox2.SelectedIndex;
            if (index < 0 || _aktuellaAvsnitt == null || index >= _aktuellaAvsnitt.Count)
                return;

            var valtAvsnitt = _aktuellaAvsnitt[index];

            listBox3.Items.Clear();

            listBox3.Items.Add("Titel: " + valtAvsnitt.Titel);
            listBox3.Items.Add("Datum: " + valtAvsnitt.PubliceringsDatum.ToString("yyyy-MM-dd"));

            //Delar upp info och rensar Html med vår metod nedan 
            string renInfo = RensaHtml(valtAvsnitt.Beskrivning);

            listBox3.Items.Add("Info:");

            //försöker dela på radbrytningarnar om det finns
            var rader = renInfo.Split(
                new[] { "\r\n", "\n" },
                StringSplitOptions.RemoveEmptyEntries);

            if (rader.Length == 0)
            {
                //Om inga nedbrytningar så lägger vi den som en hel rad
                listBox3.Items.Add(" " + renInfo);
            }
            else
            {
                //Lägger till varje rad under info
                foreach (var rad in rader)
                {
                    listBox3.Items.Add(" " + rad);
                }
            }
            //Länk 
            listBox3.Items.Add("Länk: " + valtAvsnitt.Lank);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private string RensaHtml(string html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return html;

            //Gör <br> till radbrytningar först
            html = html.Replace("<br>", "\n")
                       .Replace("<br/>", "\n")
                       .Replace("<br />", "\n");

            //Tar bort alla taggar andra taggar som <p>...</p>
            html = Regex.Replace(html, "<.*?>", string.Empty);

            return html.Trim();
        }
    }
}


