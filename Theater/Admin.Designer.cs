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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnExportTickets = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnShowTickets = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTickets)).BeginInit();
            this.tPageEvents.SuspendLayout();
            this.tPageTickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(771, 26);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(126, 23);
            this.btnBack.TabIndex = 21;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dataGridViewTickets
            // 
            this.dataGridViewTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTickets.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewTickets.Name = "dataGridViewTickets";
            this.dataGridViewTickets.Size = new System.Drawing.Size(875, 287);
            this.dataGridViewTickets.TabIndex = 22;
            this.dataGridViewTickets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTickets_CellContentClick);
            this.dataGridViewTickets.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTickets_CellValueChanged);
            this.dataGridViewTickets.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewTickets_UserAddedRow);
            // 
            // tPageEvents
            // 
            this.tPageEvents.Controls.Add(this.tPageTickets);
            this.tPageEvents.Controls.Add(this.tabPage2);
            this.tPageEvents.Location = new System.Drawing.Point(12, 123);
            this.tPageEvents.Name = "tPageEvents";
            this.tPageEvents.SelectedIndex = 0;
            this.tPageEvents.Size = new System.Drawing.Size(895, 428);
            this.tPageEvents.TabIndex = 23;
            // 
            // tPageTickets
            // 
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
            this.tPageTickets.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(887, 402);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Мероприятия";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnExportTickets
            // 
            this.btnExportTickets.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExportTickets.Enabled = false;
            this.btnExportTickets.Location = new System.Drawing.Point(6, 359);
            this.btnExportTickets.Name = "btnExportTickets";
            this.btnExportTickets.Size = new System.Drawing.Size(102, 23);
            this.btnExportTickets.TabIndex = 25;
            this.btnExportTickets.Text = "Экспортировать";
            this.btnExportTickets.UseVisualStyleBackColor = true;
            this.btnExportTickets.Click += new System.EventHandler(this.btnExportTickets_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(6, 330);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(129, 23);
            this.btnUpdate.TabIndex = 24;
            this.btnUpdate.Text = "Обновить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // btnShowTickets
            // 
            this.btnShowTickets.Location = new System.Drawing.Point(6, 301);
            this.btnShowTickets.Name = "btnShowTickets";
            this.btnShowTickets.Size = new System.Drawing.Size(129, 23);
            this.btnShowTickets.TabIndex = 23;
            this.btnShowTickets.Text = "Начать работу";
            this.btnShowTickets.UseVisualStyleBackColor = true;
            this.btnShowTickets.Click += new System.EventHandler(this.btnShowTickets_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(106, 359);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 22);
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 563);
            this.Controls.Add(this.tPageEvents);
            this.Controls.Add(this.btnBack);
            this.Name = "Admin";
            this.Text = "Дом культуры - Администратор";
            this.Load += new System.EventHandler(this.Admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTickets)).EndInit();
            this.tPageEvents.ResumeLayout(false);
            this.tPageTickets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
    }
}