using NotDefteri.Models;
using NotDefteri.Services;

namespace NotDefteri
{
    public partial class Form1 : Form
    {
        private NotServices notService;

        public Form1()
        {
            InitializeComponent();
            notService = new NotServices();

            SetupListView();
            LoadListView();
        }
        private void SetupListView()
        {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Kategori", 120);
            listView1.Columns.Add("Ba�l�k", 150);
            listView1.Columns.Add("��erik", 250);
            listView1.Columns.Add("Olu�turulma", 140);
            listView1.Columns.Add("G�ncellenme", 140);
        }

        private void LoadListView()
        {
            listView1.Items.Clear();


            foreach (var kategori in notService.GetAllCategories())
            {
                foreach (var not in kategori.Notlar)
                {
                    var item = new ListViewItem(kategori.KategoriAdi);
                    item.SubItems.Add(not.Baslik);
                    item.SubItems.Add(not.�cerik);
                    item.SubItems.Add(not.OlusturulmaTarihi.ToString("yyyy-MM-dd HH:mm"));
                    item.SubItems.Add(not.GuncellenmeTarihi.ToString("yyyy-MM-dd HH:mm"));
                    listView1.Items.Add(item);
                }
            }
        }
        private string _originalHeader;
        private string _originalCategory;

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            var item = listView1.SelectedItems[0];
            _originalCategory = item.SubItems[0].Text;
            _originalHeader = item.SubItems[1].Text;

            textBox1.Text = _originalCategory;
            textBox2.Text = _originalHeader;
            richTextBox1.Text = item.SubItems[2].Text;
        }

        // Ekleme Butonu
        private void button1_Click_1(object sender, EventArgs e)
        {
            var not = new Not
            {
                Baslik = textBox2.Text.Trim(),
                �cerik = richTextBox1.Text,
                OlusturulmaTarihi = DateTime.Now,
                GuncellenmeTarihi = DateTime.Now
            };
            var kategoriName = textBox1.Text.Trim();

            try
            {
                notService.YeniNotOlustur(not, kategoriName);

                LoadListView();
                MessageBox.Show($"\"{not.Baslik}\" ba�l�kl� not eklendi.",
                                "Ba�ar�l�",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Hata",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        // Kategoriye g�re ara
        private void button3_Click(object sender, EventArgs e)
        {
            var kategoriName = textBox3.Text.Trim();
            if (string.IsNullOrWhiteSpace(kategoriName))
            {
                LoadListView();
                return;
            }

            try
            {
                var notes = notService.Ara(kategoriName);

                listView1.Items.Clear();
                foreach (var not in notes)
                {
                    var item = new ListViewItem(kategoriName);
                    item.SubItems.Add(not.Baslik);
                    item.SubItems.Add(not.�cerik);
                    item.SubItems.Add(not.OlusturulmaTarihi.ToString("yyyy-MM-dd HH:mm"));
                    item.SubItems.Add(not.GuncellenmeTarihi.ToString("yyyy-MM-dd HH:mm"));
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"\"{kategoriName}\" kategorisi bulunamad�.\nDetay: {ex.Message}",
                    "Uyar�",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
        //Basli�a g�re ara
        private void button4_Click(object sender, EventArgs e)
        {
            var headerName = textBox4.Text.Trim();
            if (string.IsNullOrWhiteSpace(headerName))
            {
                LoadListView();
                return;
            }

            try
            {
                var notes = notService.BasligaGoreAra(headerName);

                listView1.Items.Clear();
                foreach (var not in notes)
                {
                    var item = new ListViewItem(headerName);
                    item.SubItems.Add(not.Baslik);
                    item.SubItems.Add(not.�cerik);
                    item.SubItems.Add(not.OlusturulmaTarihi.ToString("yyyy-MM-dd HH:mm"));
                    item.SubItems.Add(not.GuncellenmeTarihi.ToString("yyyy-MM-dd HH:mm"));
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"\"{headerName}\" kategorisi bulunamad�.\nDetay: {ex.Message}",
                    "Uyar�",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        //Sil 
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Silmek i�in bir not se�melisiniz.", "Uyar�",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var item = listView1.SelectedItems[0];
            var kategoriName = item.Text;
            var notHeader = item.SubItems[1].Text;

            try
            {
                notService.NotSil(notHeader, kategoriName);
                MessageBox.Show($"\"{notHeader}\" ba�l�kl� not silindi.",
                                "Ba�ar�l�", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme s�ras�nda bir hata olu�tu:\n{ex.Message}",
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Guncelle
        private void button5_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("L�tfen �nce bir not se�in.", "Uyar�",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newCategory = textBox1.Text.Trim();
            var newHeader = textBox2.Text.Trim();
            var newContent = richTextBox1.Text;

            try
            {
                notService.GuncelleNot(
                    kategoriName: _originalCategory,
                    originalHeader: _originalHeader,
                    newHeader: newHeader,
                    newContent: newContent
                );

                LoadListView();
                MessageBox.Show("Not ba�ar�yla g�ncellendi.", "Ba�ar�l�",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                _originalCategory = null;
                _originalHeader = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"G�ncelleme s�ras�nda hata olu�tu:\n{ex.Message}", "Hata",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
