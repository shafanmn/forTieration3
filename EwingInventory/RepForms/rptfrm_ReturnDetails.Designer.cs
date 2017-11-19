namespace EwingInventory.RepForms
{
    partial class rptfrm_ReturnDetails
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
            this.crvRetDet = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvRetDet
            // 
            this.crvRetDet.ActiveViewIndex = -1;
            this.crvRetDet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvRetDet.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvRetDet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvRetDet.Location = new System.Drawing.Point(0, 0);
            this.crvRetDet.Name = "crvRetDet";
            this.crvRetDet.Size = new System.Drawing.Size(927, 510);
            this.crvRetDet.TabIndex = 0;
            this.crvRetDet.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // rptfrm_ReturnDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 510);
            this.Controls.Add(this.crvRetDet);
            this.Name = "rptfrm_ReturnDetails";
            this.Text = "rptfrm_ReturnDetails";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptfrm_ReturnDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvRetDet;
    }
}