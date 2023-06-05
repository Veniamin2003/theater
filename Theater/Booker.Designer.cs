namespace Theater
{
    partial class Booker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Booker));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpTickets = new System.Windows.Forms.TabPage();
            this.tbEvent = new System.Windows.Forms.TabPage();
            this.tbEmployers = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hallType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Place = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnShow2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExportHistory = new System.Windows.Forms.Button();
            this.labelRole = new System.Windows.Forms.Label();
            this.labelLName = new System.Windows.Forms.Label();
            this.labelFName = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tpTickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpTickets);
            this.tabControl1.Controls.Add(this.tbEvent);
            this.tabControl1.Controls.Add(this.tbEmployers);
            this.tabControl1.Location = new System.Drawing.Point(12, 86);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(849, 384);
            this.tabControl1.TabIndex = 0;
            // 
            // tpTickets
            // 
            this.tpTickets.Controls.Add(this.pictureBox1);
            this.tpTickets.Controls.Add(this.btnExportHistory);
            this.tpTickets.Controls.Add(this.btnShow2);
            this.tpTickets.Controls.Add(this.dataGridView1);
            this.tpTickets.Location = new System.Drawing.Point(4, 22);
            this.tpTickets.Name = "tpTickets";
            this.tpTickets.Padding = new System.Windows.Forms.Padding(3);
            this.tpTickets.Size = new System.Drawing.Size(841, 358);
            this.tpTickets.TabIndex = 0;
            this.tpTickets.Text = "Билеты";
            this.tpTickets.UseVisualStyleBackColor = true;
            // 
            // tbEvent
            // 
            this.tbEvent.Location = new System.Drawing.Point(4, 22);
            this.tbEvent.Name = "tbEvent";
            this.tbEvent.Padding = new System.Windows.Forms.Padding(3);
            this.tbEvent.Size = new System.Drawing.Size(841, 326);
            this.tbEvent.TabIndex = 1;
            this.tbEvent.Text = "Мероприятия";
            this.tbEvent.UseVisualStyleBackColor = true;
            // 
            // tbEmployers
            // 
            this.tbEmployers.Location = new System.Drawing.Point(4, 22);
            this.tbEmployers.Name = "tbEmployers";
            this.tbEmployers.Padding = new System.Windows.Forms.Padding(3);
            this.tbEmployers.Size = new System.Drawing.Size(841, 326);
            this.tbEmployers.TabIndex = 2;
            this.tbEmployers.Text = "Сотрудники";
            this.tbEmployers.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.dateBy,
            this.hallType,
            this.row,
            this.Place,
            this.Employer,
            this.Event});
            this.dataGridView1.Location = new System.Drawing.Point(6, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(829, 297);
            this.dataGridView1.TabIndex = 1;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // dateBy
            // 
            this.dateBy.HeaderText = "Дата покупки";
            this.dateBy.Name = "dateBy";
            // 
            // hallType
            // 
            this.hallType.HeaderText = "Зал";
            this.hallType.Name = "hallType";
            // 
            // row
            // 
            this.row.HeaderText = "Ряд";
            this.row.Name = "row";
            // 
            // Place
            // 
            this.Place.HeaderText = "Место";
            this.Place.Name = "Place";
            // 
            // Employer
            // 
            this.Employer.HeaderText = "Сотрудник";
            this.Employer.Name = "Employer";
            // 
            // Event
            // 
            this.Event.HeaderText = "Мероприятие";
            this.Event.Name = "Event";
            // 
            // btnShow2
            // 
            this.btnShow2.Location = new System.Drawing.Point(6, 26);
            this.btnShow2.Name = "btnShow2";
            this.btnShow2.Size = new System.Drawing.Size(157, 23);
            this.btnShow2.TabIndex = 3;
            this.btnShow2.Text = "Показать";
            this.btnShow2.UseVisualStyleBackColor = true;
            this.btnShow2.Click += new System.EventHandler(this.btnShow2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(307, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 23);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // btnExportHistory
            // 
            this.btnExportHistory.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExportHistory.Enabled = false;
            this.btnExportHistory.Location = new System.Drawing.Point(169, 26);
            this.btnExportHistory.Name = "btnExportHistory";
            this.btnExportHistory.Size = new System.Drawing.Size(132, 23);
            this.btnExportHistory.TabIndex = 10;
            this.btnExportHistory.Text = "Экспортировать";
            this.btnExportHistory.UseVisualStyleBackColor = true;
            this.btnExportHistory.Click += new System.EventHandler(this.btnExportHistory_Click);
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Location = new System.Drawing.Point(13, 47);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(65, 13);
            this.labelRole.TabIndex = 5;
            this.labelRole.Text = "Должность";
            // 
            // labelLName
            // 
            this.labelLName.AutoSize = true;
            this.labelLName.Location = new System.Drawing.Point(13, 34);
            this.labelLName.Name = "labelLName";
            this.labelLName.Size = new System.Drawing.Size(56, 13);
            this.labelLName.TabIndex = 4;
            this.labelLName.Text = "Фамилия";
            // 
            // labelFName
            // 
            this.labelFName.AutoSize = true;
            this.labelFName.Location = new System.Drawing.Point(13, 21);
            this.labelFName.Name = "labelFName";
            this.labelFName.Size = new System.Drawing.Size(29, 13);
            this.labelFName.TabIndex = 3;
            this.labelFName.Text = "Имя";
            // 
            // Booker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 482);
            this.Controls.Add(this.labelRole);
            this.Controls.Add(this.labelLName);
            this.Controls.Add(this.labelFName);
            this.Controls.Add(this.tabControl1);
            this.Name = "Booker";
            this.Text = "Booker";
            this.Load += new System.EventHandler(this.Booker_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpTickets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpTickets;
        private System.Windows.Forms.TabPage tbEvent;
        private System.Windows.Forms.TabPage tbEmployers;
        private System.Windows.Forms.Button btnShow2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn hallType;
        private System.Windows.Forms.DataGridViewTextBoxColumn row;
        private System.Windows.Forms.DataGridViewTextBoxColumn Place;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExportHistory;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.Label labelLName;
        private System.Windows.Forms.Label labelFName;
    }
}