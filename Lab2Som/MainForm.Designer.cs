namespace Lab2Som
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.обучитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.распознатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перерисоватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelSize = new System.Windows.Forms.Label();
            this.textX = new System.Windows.Forms.TextBox();
            this.textY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обучитьToolStripMenuItem,
            this.распознатьToolStripMenuItem,
            this.перерисоватьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1145, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // обучитьToolStripMenuItem
            // 
            this.обучитьToolStripMenuItem.Name = "обучитьToolStripMenuItem";
            this.обучитьToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.обучитьToolStripMenuItem.Text = "Обучить";
            this.обучитьToolStripMenuItem.Click += new System.EventHandler(this.обучитьToolStripMenuItem_Click);
            // 
            // распознатьToolStripMenuItem
            // 
            this.распознатьToolStripMenuItem.Name = "распознатьToolStripMenuItem";
            this.распознатьToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.распознатьToolStripMenuItem.Text = "Распознать";
            this.распознатьToolStripMenuItem.Click += new System.EventHandler(this.распознатьToolStripMenuItem_Click);
            // 
            // перерисоватьToolStripMenuItem
            // 
            this.перерисоватьToolStripMenuItem.Name = "перерисоватьToolStripMenuItem";
            this.перерисоватьToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.перерисоватьToolStripMenuItem.Text = "Перерисовать";
            this.перерисоватьToolStripMenuItem.Click += new System.EventHandler(this.перерисоватьToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 337);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Инфо:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(21, 375);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(488, 105);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(416, 139);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(93, 22);
            this.textBox3.TabIndex = 37;
            this.textBox3.Text = "15";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(244, 139);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(104, 22);
            this.textBox2.TabIndex = 36;
            this.textBox2.Text = "7000";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(21, 139);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(216, 56);
            this.trackBar1.TabIndex = 35;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(412, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 17);
            this.label7.TabIndex = 34;
            this.label7.Text = "Радиус";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 17);
            this.label6.TabIndex = 33;
            this.label6.Text = "Количество итераций";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 17);
            this.label5.TabIndex = 32;
            this.label5.Text = "Скорость обучения";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 17);
            this.label4.TabIndex = 31;
            this.label4.Text = "Тестовая выборка";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(535, 47);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 601);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "X";
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(104, 47);
            this.labelSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(105, 17);
            this.labelSize.TabIndex = 25;
            this.labelSize.Text = "Размер карты:";
            // 
            // textX
            // 
            this.textX.Location = new System.Drawing.Point(343, 43);
            this.textX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textX.Name = "textX";
            this.textX.Size = new System.Drawing.Size(65, 22);
            this.textX.TabIndex = 24;
            this.textX.Text = "30";
            this.textX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textY
            // 
            this.textY.Location = new System.Drawing.Point(237, 43);
            this.textY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textY.Name = "textY";
            this.textY.Size = new System.Drawing.Size(65, 22);
            this.textY.TabIndex = 23;
            this.textY.Text = "30";
            this.textY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 121);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 17);
            this.label3.TabIndex = 38;
            this.label3.Text = "0.1";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(21, 226);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(488, 24);
            this.comboBox1.TabIndex = 39;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 656);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.textX);
            this.Controls.Add(this.textY);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "SDM2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem обучитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem распознатьToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.TextBox textX;
        private System.Windows.Forms.TextBox textY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem перерисоватьToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

