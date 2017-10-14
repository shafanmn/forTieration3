namespace Supplier
{
    partial class updateSupplier
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sname = new System.Windows.Forms.TextBox();
            this.phone = new System.Windows.Forms.TextBox();
            this.fax = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nic = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button8 = new System.Windows.Forms.Button();
            this.sid = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Phone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fax";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 360);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "e-mail";
            // 
            // sname
            // 
            this.sname.Location = new System.Drawing.Point(224, 148);
            this.sname.Name = "sname";
            this.sname.Size = new System.Drawing.Size(240, 26);
            this.sname.TabIndex = 4;
            this.sname.TextChanged += new System.EventHandler(this.sname_TextChanged);
            this.sname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sname_KeyPress);
            // 
            // phone
            // 
            this.phone.Location = new System.Drawing.Point(224, 252);
            this.phone.MaxLength = 10;
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(240, 26);
            this.phone.TabIndex = 5;
            this.phone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phone_KeyPress);
            // 
            // fax
            // 
            this.fax.Location = new System.Drawing.Point(222, 305);
            this.fax.MaxLength = 10;
            this.fax.Name = "fax";
            this.fax.Size = new System.Drawing.Size(240, 26);
            this.fax.TabIndex = 6;
            this.fax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fax_KeyPress);
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(222, 363);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(240, 26);
            this.email.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 29);
            this.label5.TabIndex = 9;
            this.label5.Text = "Supplier NIC";
            // 
            // nic
            // 
            this.nic.Location = new System.Drawing.Point(224, 200);
            this.nic.Name = "nic";
            this.nic.Size = new System.Drawing.Size(238, 26);
            this.nic.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(492, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(800, 542);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.LightBlue;
            this.button8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button8.Location = new System.Drawing.Point(322, 435);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(142, 80);
            this.button8.TabIndex = 17;
            this.button8.Text = "Update";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // sid
            // 
            this.sid.Location = new System.Drawing.Point(222, 89);
            this.sid.Name = "sid";
            this.sid.Size = new System.Drawing.Size(240, 26);
            this.sid.TabIndex = 18;
            this.sid.Visible = false;
            // 
            // updateSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1304, 725);
            this.Controls.Add(this.sid);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.nic);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.email);
            this.Controls.Add(this.fax);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.sname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "updateSupplier";
            this.Text = "update";
            this.Load += new System.EventHandler(this.updateSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sname;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.TextBox fax;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nic;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox sid;
    }
}