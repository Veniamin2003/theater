namespace Theater
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.btnBack = new System.Windows.Forms.Button();
            this.dataGridViewTickets = new System.Windows.Forms.DataGridView();
            this.tPageEvents = new System.Windows.Forms.TabControl();
            this.tPageTickets = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnExportTickets = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnShowTickets = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExportEvents = new System.Windows.Forms.Button();
            this.btnUpdateEvents = new System.Windows.Forms.Button();
            this.btnShowEvents = new System.Windows.Forms.Button();
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.tbpEmployers = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnExportEmployers = new System.Windows.Forms.Button();
            this.btnUpdateEmployers = new System.Windows.Forms.Button();
            this.btnShowEmployers = new System.Windows.Forms.Button();
            this.dgvEmployers = new System.Windows.Forms.DataGridView();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.labelRole = new System.Windows.Forms.Label();
            this.labelLName = new System.Windows.Forms.Label();
            this.labelFName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTickets)).BeginInit();
            this.tPageEvents.SuspendLayout();
            this.tPageTickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.tbpEmployers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(203)))), ((int)(((byte)(217)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(753, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(126, 33);
            this.btnBack.TabIndex = 21;
            this.btnBack.Text = "Выйти";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dataGridViewTickets
            // 
            this.dataGridViewTickets.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.dataGridViewTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTickets.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewTickets.Name = "dataGridViewTickets";
            this.dataGridViewTickets.Size = new System.Drawing.Size(881, 329);
            this.dataGridViewTickets.TabIndex = 22;
            this.dataGridViewTickets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTickets_CellContentClick);
            this.dataGridViewTickets.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTickets_CellValueChanged);
            this.dataGridViewTickets.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewTickets_UserAddedRow);
            // 
            // tPageEvents
            // 
            this.tPageEvents.Controls.Add(this.tPageTickets);
            this.tPageEvents.Controls.Add(this.tabPage2);
            this.tPageEvents.Controls.Add(this.tbpEmployers);
            this.tPageEvents.Location = new System.Drawing.Point(12, 123);
            this.tPageEvents.Name = "tPageEvents";
            this.tPageEvents.SelectedIndex = 0;
            this.tPageEvents.Size = new System.Drawing.Size(895, 428);
            this.tPageEvents.TabIndex = 23;
            // 
            // tPageTickets
            // 
            this.tPageTickets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(228)))), ((int)(((byte)(239)))));
            this.tPageTickets.Controls.Add(this.pictureBox2);
            this.tPageTickets.Controls.Add(this.btnExportTickets);
            this.tPageTickets.Controls.Add(this.btnUpdate);
            this.tPageTickets.Controls.Add(this.btnShowTickets);
            this.tPageTickets.Controls.Add(this.dataGridViewTickets);
            this.tPageTickets.Location = new System.Drawing.Point(4, 22);
            this.tPageTickets.Name = "tPageTickets";
            this.tPageTickets.Padding = new System.Windows.Forms.Padding(3);
            this.tPageTickets.Size = new System.Drawing.Size(887, 402);
            this.tPageTickets.TabIndex = 0;
            this.tPageTickets.Text = "Билеты";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(409, 338);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 22);
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // btnExportTickets
            // 
            this.btnExportTickets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(219)))), ((int)(((byte)(203)))));
            this.btnExportTickets.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExportTickets.Enabled = false;
            this.btnExportTickets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportTickets.Location = new System.Drawing.Point(274, 338);
            this.btnExportTickets.Name = "btnExportTickets";
            this.btnExportTickets.Size = new System.Drawing.Size(129, 47);
            this.btnExportTickets.TabIndex = 25;
            this.btnExportTickets.Text = "Экспортировать";
            this.btnExportTickets.UseVisualStyleBackColor = false;
            this.btnExportTickets.Click += new System.EventHandler(this.btnExportTickets_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(203)))), ((int)(((byte)(233)))));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(139, 338);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(129, 47);
            this.btnUpdate.TabIndex = 24;
            this.btnUpdate.Text = "Обновить";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // btnShowTickets
            // 
            this.btnShowTickets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(232)))), ((int)(((byte)(233)))));
            this.btnShowTickets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowTickets.Location = new System.Drawing.Point(4, 338);
            this.btnShowTickets.Name = "btnShowTickets";
            this.btnShowTickets.Size = new System.Drawing.Size(129, 47);
            this.btnShowTickets.TabIndex = 23;
            this.btnShowTickets.Text = "Начать работу";
            this.btnShowTickets.UseVisualStyleBackColor = false;
            this.btnShowTickets.Click += new System.EventHandler(this.btnShowTickets_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(228)))), ((int)(((byte)(239)))));
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.btnExportEvents);
            this.tabPage2.Controls.Add(this.btnUpdateEvents);
            this.tabPage2.Controls.Add(this.btnShowEvents);
            this.tabPage2.Controls.Add(this.dgvEvents);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(887, 402);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Мероприятия";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(409, 337);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 22);
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // btnExportEvents
            // 
            this.btnExportEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(219)))), ((int)(((byte)(203)))));
            this.btnExportEvents.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExportEvents.Enabled = false;
            this.btnExportEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportEvents.Location = new System.Drawing.Point(274, 337);
            this.btnExportEvents.Name = "btnExportEvents";
            this.btnExportEvents.Size = new System.Drawing.Size(129, 48);
            this.btnExportEvents.TabIndex = 30;
            this.btnExportEvents.Text = "Экспортировать";
            this.btnExportEvents.UseVisualStyleBackColor = false;
            this.btnExportEvents.Click += new System.EventHandler(this.btnExportEvents_Click);
            // 
            // btnUpdateEvents
            // 
            this.btnUpdateEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(203)))), ((int)(((byte)(233)))));
            this.btnUpdateEvents.Enabled = false;
            this.btnUpdateEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateEvents.Location = new System.Drawing.Point(139, 337);
            this.btnUpdateEvents.Name = "btnUpdateEvents";
            this.btnUpdateEvents.Size = new System.Drawing.Size(129, 48);
            this.btnUpdateEvents.TabIndex = 29;
            this.btnUpdateEvents.Text = "Обновить";
            this.btnUpdateEvents.UseVisualStyleBackColor = false;
            this.btnUpdateEvents.Click += new System.EventHandler(this.btnUpdateEvents_Click);
            // 
            // btnShowEvents
            // 
            this.btnShowEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(232)))), ((int)(((byte)(233)))));
            this.btnShowEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowEvents.Location = new System.Drawing.Point(4, 337);
            this.btnShowEvents.Name = "btnShowEvents";
            this.btnShowEvents.Size = new System.Drawing.Size(129, 48);
            this.btnShowEvents.TabIndex = 28;
            this.btnShowEvents.Text = "Начать работу";
            this.btnShowEvents.UseVisualStyleBackColor = false;
            this.btnShowEvents.Click += new System.EventHandler(this.btnShowEvents_Click);
            // 
            // dgvEvents
            // 
            this.dgvEvents.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvents.Location = new System.Drawing.Point(3, 3);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.Size = new System.Drawing.Size(875, 328);
            this.dgvEvents.TabIndex = 27;
            this.dgvEvents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEvents_CellContentClick);
            this.dgvEvents.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEvents_CellValueChanged);
            this.dgvEvents.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvEvents_UserAddedRow);
            // 
            // tbpEmployers
            // 
            this.tbpEmployers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(228)))), ((int)(((byte)(239)))));
            this.tbpEmployers.Controls.Add(this.pictureBox3);
            this.tbpEmployers.Controls.Add(this.btnExportEmployers);
            this.tbpEmployers.Controls.Add(this.btnUpdateEmployers);
            this.tbpEmployers.Controls.Add(this.btnShowEmployers);
            this.tbpEmployers.Controls.Add(this.dgvEmployers);
            this.tbpEmployers.Location = new System.Drawing.Point(4, 22);
            this.tbpEmployers.Name = "tbpEmployers";
            this.tbpEmployers.Padding = new System.Windows.Forms.Padding(3);
            this.tbpEmployers.Size = new System.Drawing.Size(887, 402);
            this.tbpEmployers.TabIndex = 2;
            this.tbpEmployers.Text = "Сотрудники";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(409, 333);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 22);
            this.pictureBox3.TabIndex = 36;
            this.pictureBox3.TabStop = false;
            // 
            // btnExportEmployers
            // 
            this.btnExportEmployers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(219)))), ((int)(((byte)(203)))));
            this.btnExportEmployers.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExportEmployers.Enabled = false;
            this.btnExportEmployers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportEmployers.Location = new System.Drawing.Point(274, 333);
            this.btnExportEmployers.Name = "btnExportEmployers";
            this.btnExportEmployers.Size = new System.Drawing.Size(129, 47);
            this.btnExportEmployers.TabIndex = 35;
            this.btnExportEmployers.Text = "Экспортировать";
            this.btnExportEmployers.UseVisualStyleBackColor = false;
            this.btnExportEmployers.Click += new System.EventHandler(this.btnExportEmployers_Click);
            // 
            // btnUpdateEmployers
            // 
            this.btnUpdateEmployers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(203)))), ((int)(((byte)(233)))));
            this.btnUpdateEmployers.Enabled = false;
            this.btnUpdateEmployers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateEmployers.Location = new System.Drawing.Point(140, 333);
            this.btnUpdateEmployers.Name = "btnUpdateEmployers";
            this.btnUpdateEmployers.Size = new System.Drawing.Size(129, 47);
            this.btnUpdateEmployers.TabIndex = 34;
            this.btnUpdateEmployers.Text = "Обновить";
            this.btnUpdateEmployers.UseVisualStyleBackColor = false;
            this.btnUpdateEmployers.Click += new System.EventHandler(this.btnUpdateEmployers_Click);
            // 
            // btnShowEmployers
            // 
            this.btnShowEmployers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(232)))), ((int)(((byte)(233)))));
            this.btnShowEmployers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowEmployers.Location = new System.Drawing.Point(5, 333);
            this.btnShowEmployers.Name = "btnShowEmployers";
            this.btnShowEmployers.Size = new System.Drawing.Size(129, 47);
            this.btnShowEmployers.TabIndex = 33;
            this.btnShowEmployers.Text = "Начать работу";
            this.btnShowEmployers.UseVisualStyleBackColor = false;
            this.btnShowEmployers.Click += new System.EventHandler(this.btnShowEmployers_Click);
            // 
            // dgvEmployers
            // 
            this.dgvEmployers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.dgvEmployers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployers.Location = new System.Drawing.Point(3, 3);
            this.dgvEmployers.Name = "dgvEmployers";
            this.dgvEmployers.Size = new System.Drawing.Size(881, 324);
            this.dgvEmployers.TabIndex = 32;
            this.dgvEmployers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployers_CellContentClick);
            this.dgvEmployers.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployers_CellValueChanged);
            this.dgvEmployers.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvEmployers_UserAddedRow);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(4, 10);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(67, 78);
            this.pictureBox4.TabIndex = 27;
            this.pictureBox4.TabStop = false;
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelRole.Location = new System.Drawing.Point(77, 57);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(104, 20);
            this.labelRole.TabIndex = 26;
            this.labelRole.Text = "Должность";
            // 
            // labelLName
            // 
            this.labelLName.AutoSize = true;
            this.labelLName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelLName.Location = new System.Drawing.Point(77, 37);
            this.labelLName.Name = "labelLName";
            this.labelLName.Size = new System.Drawing.Size(88, 20);
            this.labelLName.TabIndex = 25;
            this.labelLName.Text = "Фамилия";
            // 
            // labelFName
            // 
            this.labelFName.AutoSize = true;
            this.labelFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFName.Location = new System.Drawing.Point(77, 17);
            this.labelFName.Name = "labelFName";
            this.labelFName.Size = new System.Drawing.Size(43, 20);
            this.labelFName.TabIndex = 24;
            this.labelFName.Text = "Имя";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(246)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.labelLName);
            this.panel1.Controls.Add(this.labelRole);
            this.panel1.Controls.Add(this.labelFName);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(891, 96);
            this.panel1.TabIndex = 28;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox5.Location = new System.Drawing.Point(369, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(129, 93);
            this.pictureBox5.TabIndex = 28;
            this.pictureBox5.TabStop = false;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(919, 563);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tPageEvents);
            this.Name = "Admin";
            this.Text = "Дом культуры - Администратор";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Admin_FormClosed);
            this.Load += new System.EventHandler(this.Admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTickets)).EndInit();
            this.tPageEvents.ResumeLayout(false);
            this.tPageTickets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.tbpEmployers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dataGridViewTickets;
        private System.Windows.Forms.TabControl tPageEvents;
        private System.Windows.Forms.TabPage tPageTickets;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnExportTickets;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnShowTickets;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExportEvents;
        private System.Windows.Forms.Button btnUpdateEvents;
        private System.Windows.Forms.Button btnShowEvents;
        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.TabPage tbpEmployers;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnExportEmployers;
        private System.Windows.Forms.Button btnUpdateEmployers;
        private System.Windows.Forms.Button btnShowEmployers;
        private System.Windows.Forms.DataGridView dgvEmployers;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.Label labelLName;
        private System.Windows.Forms.Label labelFName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}