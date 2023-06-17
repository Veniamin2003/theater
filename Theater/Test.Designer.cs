namespace Theater
{
    partial class Test
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtEventName = new System.Windows.Forms.TextBox();
            this.btnEventAdd = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEventStartTime = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEventLength = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEventPrice = new System.Windows.Forms.TextBox();
            this.cmbEventTypes = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEventDesc = new System.Windows.Forms.TextBox();
            this.txtEventDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.panel2.Controls.Add(this.txtEventName);
            this.panel2.Controls.Add(this.btnEventAdd);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtEventStartTime);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtEventLength);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtEventPrice);
            this.panel2.Controls.Add(this.cmbEventTypes);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtEventDesc);
            this.panel2.Controls.Add(this.txtEventDate);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(36, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(729, 339);
            this.panel2.TabIndex = 17;
            // 
            // txtEventName
            // 
            this.txtEventName.Location = new System.Drawing.Point(14, 37);
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.Size = new System.Drawing.Size(194, 20);
            this.txtEventName.TabIndex = 21;
            // 
            // btnEventAdd
            // 
            this.btnEventAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(232)))), ((int)(((byte)(233)))));
            this.btnEventAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEventAdd.Location = new System.Drawing.Point(590, 285);
            this.btnEventAdd.Name = "btnEventAdd";
            this.btnEventAdd.Size = new System.Drawing.Size(125, 36);
            this.btnEventAdd.TabIndex = 7;
            this.btnEventAdd.Text = "Добавить";
            this.btnEventAdd.UseVisualStyleBackColor = false;
            this.btnEventAdd.Click += new System.EventHandler(this.btnEventAdd_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(249, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 16);
            this.label11.TabIndex = 20;
            this.label11.Text = "Время начала";
            // 
            // txtEventStartTime
            // 
            this.txtEventStartTime.Location = new System.Drawing.Point(252, 80);
            this.txtEventStartTime.Name = "txtEventStartTime";
            this.txtEventStartTime.Size = new System.Drawing.Size(207, 20);
            this.txtEventStartTime.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(501, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 16);
            this.label10.TabIndex = 18;
            this.label10.Text = "Длительность";
            // 
            // txtEventLength
            // 
            this.txtEventLength.Location = new System.Drawing.Point(504, 82);
            this.txtEventLength.Name = "txtEventLength";
            this.txtEventLength.Size = new System.Drawing.Size(211, 20);
            this.txtEventLength.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(501, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Стоимость";
            // 
            // txtEventPrice
            // 
            this.txtEventPrice.Location = new System.Drawing.Point(504, 38);
            this.txtEventPrice.Name = "txtEventPrice";
            this.txtEventPrice.Size = new System.Drawing.Size(211, 20);
            this.txtEventPrice.TabIndex = 15;
            // 
            // cmbEventTypes
            // 
            this.cmbEventTypes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEventTypes.FormattingEnabled = true;
            this.cmbEventTypes.Location = new System.Drawing.Point(14, 77);
            this.cmbEventTypes.Name = "cmbEventTypes";
            this.cmbEventTypes.Size = new System.Drawing.Size(194, 21);
            this.cmbEventTypes.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(11, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Вид";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(249, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Дата";
            // 
            // txtEventDesc
            // 
            this.txtEventDesc.Location = new System.Drawing.Point(14, 129);
            this.txtEventDesc.Multiline = true;
            this.txtEventDesc.Name = "txtEventDesc";
            this.txtEventDesc.Size = new System.Drawing.Size(701, 150);
            this.txtEventDesc.TabIndex = 5;
            // 
            // txtEventDate
            // 
            this.txtEventDate.Location = new System.Drawing.Point(252, 38);
            this.txtEventDate.Name = "txtEventDate";
            this.txtEventDate.Size = new System.Drawing.Size(207, 20);
            this.txtEventDate.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(11, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Описание";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(11, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Название";
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Name = "Test";
            this.Text = "Test";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtEventName;
        private System.Windows.Forms.Button btnEventAdd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEventStartTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEventLength;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEventPrice;
        private System.Windows.Forms.ComboBox cmbEventTypes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEventDesc;
        private System.Windows.Forms.TextBox txtEventDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}