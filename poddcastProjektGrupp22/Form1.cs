using System;
using System.Windows.Forms;
using PoddApp.DAL.Rss;
using PoddApp.Models;
using PoddApp.BL.Services;
using System.Collections.Generic;


namespace poddcastProjektGrupp22
{
    public partial class Form1 : Form
    {
        private RssLasare _rssLasare;
        private List<Avsnitt> _senasteAvsnitt;
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

        private void buttonVisa_Click(object sender, EventArgs e)
        {
            int idx = listBox1.SelectedIndex;
            //Kolla att en källa är vald i listBox1
            if (idx < 0 || idx >= _sparadePoddar.Count)
            {
                MessageBox.Show("Välj en källa i listan först.");
                return;
            }
            //Hämta valda podd utifrån index
            var valdPodd = _sparadePoddar[idx];
            //Hämta avsnitt för vald podd
            var avsnitt = _poddTjanst.HamtaAvsnittForPodd(valdPodd.Id);

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

        private void LaddaSparadePoddar()
        {
            var allaPoddar = _poddTjanst.HamtaAllaPoddar();

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
                _poddTjanst.TaBortPodd(valdPodd.Id);

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

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}


