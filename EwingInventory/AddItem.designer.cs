namespace EwingInventory
{
    partial class AddItem
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
            this.txtitems = new System.Windows.Forms.TextBox();
            this.lblItems = new System.Windows.Forms.Label();
            this.txtqtys = new System.Windows.Forms.TextBox();
            this.lblqty = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtitems
            // 
            this.txtitems.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtitems.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtitems.Location = new System.Drawing.Point(119, 30);
            this.txtitems.Name = "txtitems";
            this.txtitems.Size = new System.Drawing.Size(130, 26);
            this.txtitems.TabIndex = 73;
            this.txtitems.TextChanged += new System.EventHandler(this.txtitems_TextChanged);
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Font = new System.Drawing.Font("Cambria", 11F);
            this.lblItems.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblItems.Location = new System.Drawing.Point(33, 30);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(68, 17);
            this.lblItems.TabIndex = 72;
            this.lblItems.Text = "ItemCode";
            // 
            // txtqtys
            // 
            this.txtqtys.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtqtys.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtqtys.Location = new System.Drawing.Point(119, 79);
            this.txtqtys.Name = "txtqtys";
            this.txtqtys.Size = new System.Drawing.Size(130, 26);
            this.txtqtys.TabIndex = 75;
            this.txtqtys.TextChanged += new System.EventHandler(this.txtqtys_TextChanged);
            // 
            // lblqty
            // 
            this.lblqty.AutoSize = true;
            this.lblqty.Font = new System.Drawing.Font("Cambria", 11F);
            this.lblqty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblqty.Location = new System.Drawing.Point(33, 79);
            this.lblqty.Name = "lblqty";
            this.lblqty.Size = new System.Drawing.Size(31, 17);
            this.lblqty.TabIndex = 74;
            this.lblqty.Text = "Qty";
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnAddItem.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAddItem.Location = new System.Drawing.Point(36, 153);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(85, 45);
            this.btnAddItem.TabIndex = 94;
            this.btnAddItem.Text = "Save";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btncancel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btncancel.Location = new System.Drawing.Point(164, 153);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(85, 45);
            this.btncancel.TabIndex = 95;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // AddItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.txtqtys);
            this.Controls.Add(this.lblqty);
            this.Controls.Add(this.txtitems);
            this.Controls.Add(this.lblItems);
            this.Location = new System.Drawing.Point(300, 300);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddItem";
            this.Text = "AddItem";
            this.Load += new System.EventHandler(this.AddItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Label lblqty;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btncancel;
        public System.Windows.Forms.TextBox txtitems;
        public System.Windows.Forms.TextBox txtqtys;
    }
}