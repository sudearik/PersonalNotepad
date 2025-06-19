namespace NotDefteri
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richTextBox1 = new RichTextBox();
            textBox1 = new TextBox();
            btnEkle = new Button();
            textBox2 = new TextBox();
            listView1 = new ListView();
            btnSil = new Button();
            btnKategoriyeGoreAra = new Button();
            textBox3 = new TextBox();
            btnBasligaGoreAra = new Button();
            textBox4 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnGuncelle = new Button();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(17, 83);
            richTextBox1.Margin = new Padding(4, 5, 4, 5);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1127, 459);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(436, 20);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(250, 31);
            textBox1.TabIndex = 4;
            // 
            // btnEkle
            // 
            btnEkle.BackColor = Color.Green;
            btnEkle.ForeColor = SystemColors.ControlText;
            btnEkle.Location = new Point(696, 3);
            btnEkle.Margin = new Padding(4, 5, 4, 5);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(251, 70);
            btnEkle.TabIndex = 5;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = false;
            btnEkle.Click += button1_Click_1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(117, 20);
            textBox2.Margin = new Padding(4, 5, 4, 5);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(208, 31);
            textBox2.TabIndex = 6;
            // 
            // listView1
            // 
            listView1.Location = new Point(19, 552);
            listView1.Margin = new Padding(4, 5, 4, 5);
            listView1.Name = "listView1";
            listView1.Size = new Size(1127, 397);
            listView1.TabIndex = 7;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.Red;
            btnSil.Location = new Point(1154, 860);
            btnSil.Margin = new Padding(4, 5, 4, 5);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(259, 92);
            btnSil.TabIndex = 8;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += button2_Click_1;
            // 
            // btnKategoriyeGoreAra
            // 
            btnKategoriyeGoreAra.Location = new Point(1154, 600);
            btnKategoriyeGoreAra.Margin = new Padding(4, 5, 4, 5);
            btnKategoriyeGoreAra.Name = "btnKategoriyeGoreAra";
            btnKategoriyeGoreAra.Size = new Size(259, 38);
            btnKategoriyeGoreAra.TabIndex = 9;
            btnKategoriyeGoreAra.Text = "Kategoriye Göre Ara";
            btnKategoriyeGoreAra.UseVisualStyleBackColor = true;
            btnKategoriyeGoreAra.Click += button3_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1154, 552);
            textBox3.Margin = new Padding(4, 5, 4, 5);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(257, 31);
            textBox3.TabIndex = 10;
            // 
            // btnBasligaGoreAra
            // 
            btnBasligaGoreAra.Location = new Point(1154, 779);
            btnBasligaGoreAra.Margin = new Padding(4, 5, 4, 5);
            btnBasligaGoreAra.Name = "btnBasligaGoreAra";
            btnBasligaGoreAra.Size = new Size(259, 38);
            btnBasligaGoreAra.TabIndex = 11;
            btnBasligaGoreAra.Text = "Başlığa Göre Ara";
            btnBasligaGoreAra.UseVisualStyleBackColor = true;
            btnBasligaGoreAra.Click += button4_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(1154, 730);
            textBox4.Margin = new Padding(4, 5, 4, 5);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(257, 31);
            textBox4.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 25);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(97, 25);
            label1.TabIndex = 13;
            label1.Text = "Not Başlığı";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(354, 25);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(78, 25);
            label2.TabIndex = 14;
            label2.Text = "Kategori";
            // 
            // btnGuncelle
            // 
            btnGuncelle.BackColor = Color.Green;
            btnGuncelle.ForeColor = SystemColors.ControlText;
            btnGuncelle.Location = new Point(956, 3);
            btnGuncelle.Margin = new Padding(4, 5, 4, 5);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(251, 70);
            btnGuncelle.TabIndex = 15;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = false;
            btnGuncelle.Click += button5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightPink;
            ClientSize = new Size(1423, 964);
            Controls.Add(btnGuncelle);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox4);
            Controls.Add(btnBasligaGoreAra);
            Controls.Add(textBox3);
            Controls.Add(btnKategoriyeGoreAra);
            Controls.Add(btnSil);
            Controls.Add(listView1);
            Controls.Add(textBox2);
            Controls.Add(btnEkle);
            Controls.Add(textBox1);
            Controls.Add(richTextBox1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private TextBox textBox1;
        private Button btnEkle;
        private TextBox textBox2;
        private ListView listView1;
        private Button btnSil;
        private Button btnKategoriyeGoreAra;
        private TextBox textBox3;
        private Button btnBasligaGoreAra;
        private TextBox textBox4;
        private Label label1;
        private Label label2;
        private Button btnGuncelle;
    }
}
