using System;
using System.Windows.Forms;
using PoddApp.DAL.Rss;
using PoddApp.Models;
using PoddApp.BL.Services;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PoddApp.BL.Interface;
using PoddApp.DAL;
using System.Linq;



namespace poddcastProjektGrupp22
{
    public partial class Form1 : Form
    {
        private RssLasare _rssLasare;
        private List<Avsnitt> _senasteAvsnitt;
        private List<Avsnitt> _aktuellaAvsnitt;
        private PoddTjanst _poddTjanst;
        private List<Poddflode> _sparadePoddar;
        private readonly IKategoriTjanst _kategoriTjanst;
        private bool _sparaJustNu = false;


        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;

            _rssLasare = new RssLasare();
            _senasteAvsnitt = new List<Avsnitt>();
            _poddTjanst = new PoddTjanst();
            _sparadePoddar = new List<Poddflode>();

            _kategoriTjanst = new KategoriTjanst(new PoddRepository());

            buttonVisning.Click += buttonVisning_Click;
            radera_kategori.Click += radera_kategori_Click;
            buttonNyhetsskalla.Click += buttonNyhetsskalla_Click;
            buttonSpara.Click += buttonSpara_Click;
            buttonVisa.Click += buttonVisa_Click;
            buttonVisaSparadePoddar.Click += buttonVisaSparadePoddar_Click;
            buttonRadera.Click += buttonRadera_Click;

            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;

            comboBoxFilterKategori.SelectedIndexChanged += comboBoxFilterKategori_SelectedIndexChanged;

            buttonAndraKategoriNamn.Click += buttonAndraKategoriNamn_Click;
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

        private async void buttonSpara_Click(object sender, EventArgs e)
        {
            if (_sparaJustNu)
                return;

            _sparaJustNu = true;
            buttonSpara.Enabled = false;

            try
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

                string visningNamn = addName.Text?.Trim();
                if (string.IsNullOrWhiteSpace(visningNamn))
                {
                    visningNamn = url; // visa url om man inte skrivit något
                }

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
                    var allaKategorier = await _kategoriTjanst.HamtaAllaKategorierAsync();
                    var befintlig = allaKategorier
                        .Find(k => k.Namn.Equals(kategoriText, StringComparison.OrdinalIgnoreCase));

                    if (befintlig == null)
                    {
                        befintlig = await _kategoriTjanst.SkapaKategoriAsync(kategoriText);
                        comboBoxKategori.Items.Add(befintlig.Namn);
                    }


                    kategoriNamn = befintlig.Namn;
                }

                await _poddTjanst.SparaNyPoddAsync(visningNamn, url, kategoriNamn, _senasteAvsnitt);
                MessageBox.Show("Källan har sparats i registret.");

                await LaddaFilterKategorierAsync();

            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "OBS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ett fel uppstod vid sparning: " + ex.Message,
                                "Fel",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                _sparaJustNu = false;
                buttonSpara.Enabled = true;
            }
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
                return;
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
                // 🟢 Visa poddnamn i listBox1 (fallback till URL om Namn är tomt)
                var namnAttVisa = string.IsNullOrWhiteSpace(podd.Namn)
                    ? podd.RssUrl
                    : podd.Namn;

                listBox1.Items.Add(namnAttVisa);

                // Info-ruta: namn + datum
                listBox2.Items.Add(namnAttVisa + " - " + podd.SkapaDatum.ToString("yyyy-MM-dd"));

                string kategoriNamn = string.IsNullOrWhiteSpace(podd.Kategori)
                    ? "(Ingen kategori)"
                    : podd.Kategori;

                listBox3.Items.Add(kategoriNamn);
            }
        }

        private async void buttonRadera_Click(object sender, EventArgs e)
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
                await _poddTjanst.TaBortPoddAsync(valdPodd.Id);

                //Ladda om listan med sparade poddar
                await LaddaSparadePoddar();

                //Töm avsnittslistorna
                listBox2.Items.Clear();
                listBox3.Items.Clear();
            }
        }

        private async void buttonVisaSparadePoddar_Click(object sender, EventArgs e)
        {
            await LaddaSparadePoddar();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            comboBoxKategori.Items.Clear();

            await LaddaFilterKategorierAsync();

            // Hämta kategorier från databasen
            var kategorier = await _kategoriTjanst.HamtaAllaKategorierAsync();

            // Om databasen är tom första gången, lägg in standardkategorier
            if (kategorier.Count == 0)
            {
                await _kategoriTjanst.SkapaKategoriAsync("Nyheter");
                await _kategoriTjanst.SkapaKategoriAsync("Teknik");
                await _kategoriTjanst.SkapaKategoriAsync("Sport");
                await _kategoriTjanst.SkapaKategoriAsync("Underhållning");

                kategorier = await _kategoriTjanst.HamtaAllaKategorierAsync();
            }

            foreach (var k in kategorier)
            {
                comboBoxKategori.Items.Add(k.Namn);
            }

            // Om du vill kunna skriva egna kategorier direkt i comboboxen:
            comboBoxKategori.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private async void radera_kategori_Click(object sender, EventArgs e)
        {
            string valdKategori = comboBoxKategori.Text?.Trim();

            if (string.IsNullOrWhiteSpace(valdKategori))
            {
                MessageBox.Show("Välj en kategori att radera.");
                return;
            }

            if (valdKategori == "(Ingen kategori)")
            {
                MessageBox.Show("Denna kategori kan inte tas bort.");
                return;
            }

            // Hämta kategorin från databasen
            var kategorier = await _kategoriTjanst.HamtaAllaKategorierAsync();
            var kategori = kategorier.Find(k =>
                k.Namn.Equals(valdKategori, StringComparison.OrdinalIgnoreCase));

            if (kategori == null)
            {
                MessageBox.Show("Kategorin hittades inte i databasen.");
                return;
            }

            var svar = MessageBox.Show(
                $"Vill du verkligen ta bort kategorin '{kategori.Namn}'?",
                "Bekräfta borttagningen",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (svar != DialogResult.Yes)
                return;

            try
            {
                await _kategoriTjanst.TaBortKategoriAsync(kategori.Id);

                // Ta bort den från comboboxen
                comboBoxKategori.Items.Remove(valdKategori);
                comboBoxKategori.Text = string.Empty;

                MessageBox.Show("Kategorin har raderats.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ett fel uppstod vid borttagning: " + ex.Message,
                                "Fel",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private async Task LaddaFilterKategorierAsync()
        {
            var poddar = await _poddTjanst.HamtaAllaPoddarAsync();

            var kategorier = poddar
                .Select(p => p.Kategori)
                .Where(k => !string.IsNullOrWhiteSpace(k))
                .Distinct()
                .OrderBy(k => k)
                .ToList();

            comboBoxFilterKategori.DataSource = kategorier;
        }

        private async void buttonAndraKategoriNamn_Click(object sender, EventArgs e)
        {
            // 1. Nytt namn från textboxen
            string nyttNamn = textBoxKategoriNamn.Text?.Trim();

            if (string.IsNullOrWhiteSpace(nyttNamn))
            {
                MessageBox.Show("Skriv ett nytt kategorinamn.", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kolla att något är markerat i listBox3
            int index = listBox3.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("Markera en kategori i listan (listBox3).", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Gamla namnet = texten i listBox3
            string gammaltNamn = listBox3.Items[index]?.ToString();

            if (string.IsNullOrWhiteSpace(gammaltNamn))
            {
                MessageBox.Show("Kunde inte läsa det gamla kategorinamnet.", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.Equals(gammaltNamn, nyttNamn, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Det nya namnet är samma som det gamla.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // 4. Försök hitta kategorin i Kategorier-collectionen
                var allaKategorier = await _kategoriTjanst.HamtaAllaKategorierAsync();

                var kategori = allaKategorier
                    .FirstOrDefault(k => k.Namn.Equals(gammaltNamn, StringComparison.OrdinalIgnoreCase));

                if (kategori != null)
                {
                    // 5a. Om den finns: uppdatera namnet i Kategorier-kollektionen
                    await _kategoriTjanst.AndraKategoriNamnAsync(kategori.Id, nyttNamn);
                }
                else
                {
                    // 5b. Om den inte finns: skapa kategori med det nya namnet (frivilligt)
                    //    så att comboboxen får med det nya namnet också.
                    await _kategoriTjanst.SkapaKategoriAsync(nyttNamn);
                }

                // 6. Uppdatera ALLA poddar som hade det gamla kategorinamnet
                await _poddTjanst.UppdateraKategoriNamnForPoddarAsync(gammaltNamn, nyttNamn);

                // 7. Uppdatera comboboxen där man väljer kategori när man sparar
                comboBoxKategori.Items.Clear();
                var uppdateradeKategorier = await _kategoriTjanst.HamtaAllaKategorierAsync();
                foreach (var k in uppdateradeKategorier)
                {
                    comboBoxKategori.Items.Add(k.Namn);
                }

                // 8. Uppdatera filter-comboboxen (bygger på poddarnas kategorier)
                await LaddaFilterKategorierAsync();

                // 9. Ladda om poddlistan så listBox1/2/3 visar nya kategorinamnet
                textBoxKategoriNamn.Clear();
                await LaddaSparadePoddar();

                MessageBox.Show("Kategorinamnet har ändrats.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ett fel uppstod vid ändring: " + ex.Message,
                                "Fel",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }




        private async void comboBoxFilterKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            var valdKategori = comboBoxFilterKategori.SelectedItem as string;
            if (string.IsNullOrEmpty(valdKategori))
                return;

            // Hämta alla poddar
            var allaPoddar = await _poddTjanst.HamtaAllaPoddarAsync();

            // Filtrera på vald kategori
            var filtreradePoddar = allaPoddar
                .Where(p => p.Kategori == valdKategori)
                .ToList();

            // Uppdatera fältet som används av Visa/Radera-knapparna
            _sparadePoddar = filtreradePoddar;

            // Töm listboxarna 
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            // Fyll listboxarna på samma sätt som i LaddaSparadePoddar
            foreach (var podd in _sparadePoddar)
            {
                // Länken
                listBox1.Items.Add(podd.RssUrl);

                // Info
                listBox2.Items.Add(podd.Namn + " - " + podd.SkapaDatum.ToString("yyyy-MM-dd"));

                string kategoriNamn = string.IsNullOrWhiteSpace(podd.Kategori)
                    ? "(Ingen kategori)"
                    : podd.Kategori;

                // Kategori
                listBox3.Items.Add(kategoriNamn);
            }
        }


        private async void buttonVisning_Click(object sender, EventArgs e)
        {
            int idx = listBox1.SelectedIndex;

            if (idx < 0 || idx >= _sparadePoddar.Count)
            {
                MessageBox.Show("Välj en podd i listan först.");
                return;
            }

            string nyttNamn = textBox1.Text?.Trim();

            if (string.IsNullOrWhiteSpace(nyttNamn))
            {
                MessageBox.Show("Skriv in ett namn för podden i textfältet.");
                return;
            }

            var valdPodd = _sparadePoddar[idx];

            try
            {
                // Spara i databasen via tjänsten
                await _poddTjanst.AndraNamnAsync(valdPodd.Id, nyttNamn);

                // Ladda om listan med poddar så att listBox1 uppdateras
                await LaddaSparadePoddar();

                // Försök markera samma podd igen
                int nyIndex = _sparadePoddar.FindIndex(p => p.Id == valdPodd.Id);
                if (nyIndex >= 0)
                {
                    listBox1.SelectedIndex = nyIndex;
                }

                MessageBox.Show("Poddens namn har uppdaterats.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ett fel uppstod när namnet skulle uppdateras: " + ex.Message,
                                "Fel",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void addName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


