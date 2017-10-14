namespace Supplier
{
    partial class payment_history
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
            this.paymentHis = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.paymentHis)).BeginInit();
            this.SuspendLayout();
            // 
            // paymentHis
            // 
            this.paymentHis.BackgroundColor = System.Drawing.Color.LightBlue;
            this.paymentHis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paymentHis.Location = new System.Drawing.Point(38, 73);
            this.paymentHis.Name = "paymentHis";
            this.paymentHis.RowTemplate.Height = 28;
            this.paymentHis.Size = new System.Drawing.Size(885, 396);
            this.paymentHis.TabIndex = 0;
            this.paymentHis.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // payment_history
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(965, 627);
            this.Controls.Add(this.paymentHis);
            this.Name = "payment_history";
            this.Text = "payment_history";
            this.Load += new System.EventHandler(this.payment_history_Load);
            ((System.ComponentModel.ISupportInitialize)(this.paymentHis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView paymentHis;
    }
}