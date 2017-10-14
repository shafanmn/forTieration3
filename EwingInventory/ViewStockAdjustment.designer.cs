namespace StockManagement
{
    partial class ViewStockAdjustment
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
            this.ViewSadjustment = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ViewSadjustment)).BeginInit();
            this.SuspendLayout();
            // 
            // ViewSadjustment
            // 
            this.ViewSadjustment.AllowUserToAddRows = false;
            this.ViewSadjustment.AllowUserToDeleteRows = false;
            this.ViewSadjustment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ViewSadjustment.Location = new System.Drawing.Point(-2, 0);
            this.ViewSadjustment.Name = "ViewSadjustment";
            this.ViewSadjustment.ReadOnly = true;
            this.ViewSadjustment.Size = new System.Drawing.Size(646, 432);
            this.ViewSadjustment.TabIndex = 1;
            // 
            // ViewStockAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 454);
            this.Controls.Add(this.ViewSadjustment);
            this.Name = "ViewStockAdjustment";
            this.Text = "ViewStockAdjustment";
            this.Load += new System.EventHandler(this.ViewStockAdjustment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ViewSadjustment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ViewSadjustment;
    }
}