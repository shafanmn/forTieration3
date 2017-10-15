namespace EwingInventory
{
    partial class returnmgt
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_quantity = new System.Windows.Forms.TextBox();
            this.txt_price = new System.Windows.Forms.TextBox();
            this.txt_itemname = new System.Windows.Forms.TextBox();
            this.txt_itemcode = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_subtotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_docnum = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_remark = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnclose = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_apply = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtcid = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_cal = new System.Windows.Forms.Button();
            this.txt_spclprice = new System.Windows.Forms.TextBox();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.txt_wsamount = new System.Windows.Forms.TextBox();
            this.txt_purchamount = new System.Windows.Forms.TextBox();
            this.txt_rtnqnt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lable12 = new System.Windows.Forms.Label();
            this.lable11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_qnt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btn_close2 = new System.Windows.Forms.Button();
            this.btn_clear2 = new System.Windows.Forms.Button();
            this.btn_apply2 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(844, 449);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightCyan;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.lbl_subtotal);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.lbl_docnum);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txt_remark);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.btnclose);
            this.tabPage1.Controls.Add(this.btn_clear);
            this.tabPage1.Controls.Add(this.btn_apply);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtname);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtcid);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(836, 419);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Customer Return";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txt_quantity);
            this.groupBox1.Controls.Add(this.txt_price);
            this.groupBox1.Controls.Add(this.txt_itemname);
            this.groupBox1.Controls.Add(this.txt_itemcode);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(33, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(757, 257);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Deatails";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txt_quantity
            // 
            this.txt_quantity.BackColor = System.Drawing.Color.AliceBlue;
            this.txt_quantity.Enabled = false;
            this.txt_quantity.Location = new System.Drawing.Point(493, 222);
            this.txt_quantity.Name = "txt_quantity";
            this.txt_quantity.Size = new System.Drawing.Size(44, 25);
            this.txt_quantity.TabIndex = 39;
            this.txt_quantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_quantity_KeyDown);
            // 
            // txt_price
            // 
            this.txt_price.BackColor = System.Drawing.Color.AliceBlue;
            this.txt_price.Enabled = false;
            this.txt_price.Location = new System.Drawing.Point(412, 222);
            this.txt_price.Name = "txt_price";
            this.txt_price.Size = new System.Drawing.Size(74, 25);
            this.txt_price.TabIndex = 38;
            // 
            // txt_itemname
            // 
            this.txt_itemname.BackColor = System.Drawing.Color.AliceBlue;
            this.txt_itemname.Enabled = false;
            this.txt_itemname.Location = new System.Drawing.Point(163, 222);
            this.txt_itemname.Name = "txt_itemname";
            this.txt_itemname.Size = new System.Drawing.Size(243, 25);
            this.txt_itemname.TabIndex = 37;
            // 
            // txt_itemcode
            // 
            this.txt_itemcode.BackColor = System.Drawing.Color.AliceBlue;
            this.txt_itemcode.Enabled = false;
            this.txt_itemcode.Location = new System.Drawing.Point(62, 222);
            this.txt_itemcode.Name = "txt_itemcode";
            this.txt_itemcode.Size = new System.Drawing.Size(95, 25);
            this.txt_itemcode.TabIndex = 36;
            this.txt_itemcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_itemcode_KeyDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(15, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(727, 192);
            this.dataGridView1.TabIndex = 30;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ItemCode";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Description";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Price";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Qty";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Total";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // lbl_subtotal
            // 
            this.lbl_subtotal.AutoSize = true;
            this.lbl_subtotal.Location = new System.Drawing.Point(680, 386);
            this.lbl_subtotal.Name = "lbl_subtotal";
            this.lbl_subtotal.Size = new System.Drawing.Size(18, 17);
            this.lbl_subtotal.TabIndex = 46;
            this.lbl_subtotal.Text = "--";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(553, 386);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 45;
            this.label7.Text = "Sub Total";
            // 
            // lbl_docnum
            // 
            this.lbl_docnum.AutoSize = true;
            this.lbl_docnum.Location = new System.Drawing.Point(632, 24);
            this.lbl_docnum.Name = "lbl_docnum";
            this.lbl_docnum.Size = new System.Drawing.Size(41, 17);
            this.lbl_docnum.TabIndex = 41;
            this.lbl_docnum.Text = "None";
            this.lbl_docnum.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(486, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 17);
            this.label5.TabIndex = 40;
            this.label5.Text = "Document Number";
            // 
            // txt_remark
            // 
            this.txt_remark.Enabled = false;
            this.txt_remark.Location = new System.Drawing.Point(635, 84);
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.Size = new System.Drawing.Size(155, 25);
            this.txt_remark.TabIndex = 35;
            this.txt_remark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_remark_KeyDown);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(635, 51);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(155, 25);
            this.dateTimePicker1.TabIndex = 34;
            this.dateTimePicker1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePicker1_KeyDown);
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.SkyBlue;
            this.btnclose.ForeColor = System.Drawing.Color.Blue;
            this.btnclose.Location = new System.Drawing.Point(254, 378);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(92, 31);
            this.btnclose.TabIndex = 33;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_clear.ForeColor = System.Drawing.Color.Blue;
            this.btn_clear.Location = new System.Drawing.Point(144, 378);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(92, 31);
            this.btn_clear.TabIndex = 32;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = false;
            // 
            // btn_apply
            // 
            this.btn_apply.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_apply.ForeColor = System.Drawing.Color.Blue;
            this.btn_apply.Location = new System.Drawing.Point(33, 378);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(92, 31);
            this.btn_apply.TabIndex = 31;
            this.btn_apply.Text = "Apply";
            this.btn_apply.UseVisualStyleBackColor = false;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(486, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "Remark";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(486, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "Date";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(155, 74);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(191, 25);
            this.txtname.TabIndex = 27;
            this.txtname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtname_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(36, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Customer Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(36, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Customer ID";
            // 
            // txtcid
            // 
            this.txtcid.Location = new System.Drawing.Point(156, 41);
            this.txtcid.Name = "txtcid";
            this.txtcid.Size = new System.Drawing.Size(53, 25);
            this.txtcid.TabIndex = 24;
            this.txtcid.TextChanged += new System.EventHandler(this.txtcid_TextChanged);
            this.txtcid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcid_KeyDown);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.AliceBlue;
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.btn_close2);
            this.tabPage2.Controls.Add(this.btn_clear2);
            this.tabPage2.Controls.Add(this.btn_apply2);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(836, 419);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Discount Calculation";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_cal);
            this.groupBox3.Controls.Add(this.txt_spclprice);
            this.groupBox3.Controls.Add(this.txt_desc);
            this.groupBox3.Controls.Add(this.txt_wsamount);
            this.groupBox3.Controls.Add(this.txt_purchamount);
            this.groupBox3.Controls.Add(this.txt_rtnqnt);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.lable12);
            this.groupBox3.Controls.Add(this.lable11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(369, 44);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(361, 284);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Deatails";
            // 
            // btn_cal
            // 
            this.btn_cal.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_cal.ForeColor = System.Drawing.Color.Blue;
            this.btn_cal.Location = new System.Drawing.Point(86, 167);
            this.btn_cal.Name = "btn_cal";
            this.btn_cal.Size = new System.Drawing.Size(196, 30);
            this.btn_cal.TabIndex = 12;
            this.btn_cal.Text = "Calculate";
            this.btn_cal.UseVisualStyleBackColor = false;
            // 
            // txt_spclprice
            // 
            this.txt_spclprice.Location = new System.Drawing.Point(197, 215);
            this.txt_spclprice.Name = "txt_spclprice";
            this.txt_spclprice.Size = new System.Drawing.Size(137, 25);
            this.txt_spclprice.TabIndex = 11;
            // 
            // txt_desc
            // 
            this.txt_desc.Location = new System.Drawing.Point(197, 32);
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(137, 25);
            this.txt_desc.TabIndex = 10;
            // 
            // txt_wsamount
            // 
            this.txt_wsamount.Location = new System.Drawing.Point(197, 126);
            this.txt_wsamount.Name = "txt_wsamount";
            this.txt_wsamount.Size = new System.Drawing.Size(137, 25);
            this.txt_wsamount.TabIndex = 9;
            // 
            // txt_purchamount
            // 
            this.txt_purchamount.Location = new System.Drawing.Point(197, 94);
            this.txt_purchamount.Name = "txt_purchamount";
            this.txt_purchamount.Size = new System.Drawing.Size(137, 25);
            this.txt_purchamount.TabIndex = 8;
            // 
            // txt_rtnqnt
            // 
            this.txt_rtnqnt.Location = new System.Drawing.Point(197, 63);
            this.txt_rtnqnt.Name = "txt_rtnqnt";
            this.txt_rtnqnt.Size = new System.Drawing.Size(137, 25);
            this.txt_rtnqnt.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 215);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 17);
            this.label13.TabIndex = 6;
            this.label13.Text = "Special Price";
            // 
            // lable12
            // 
            this.lable12.AutoSize = true;
            this.lable12.Location = new System.Drawing.Point(26, 32);
            this.lable12.Name = "lable12";
            this.lable12.Size = new System.Drawing.Size(81, 17);
            this.lable12.TabIndex = 5;
            this.lable12.Text = "Description";
            // 
            // lable11
            // 
            this.lable11.AutoSize = true;
            this.lable11.Location = new System.Drawing.Point(26, 126);
            this.lable11.Name = "lable11";
            this.lable11.Size = new System.Drawing.Size(130, 17);
            this.lable11.TabIndex = 4;
            this.lable11.Text = "Whole Sale Amount";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 17);
            this.label10.TabIndex = 3;
            this.label10.Text = "Purchase Amount";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "Return Quantity";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_qnt);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(18, 347);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 59);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtering";
            // 
            // txt_qnt
            // 
            this.txt_qnt.Location = new System.Drawing.Point(110, 22);
            this.txt_qnt.Name = "txt_qnt";
            this.txt_qnt.Size = new System.Drawing.Size(123, 25);
            this.txt_qnt.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 17);
            this.label15.TabIndex = 14;
            this.label15.Text = "Quantity";
            // 
            // btn_close2
            // 
            this.btn_close2.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_close2.ForeColor = System.Drawing.Color.Blue;
            this.btn_close2.Location = new System.Drawing.Point(627, 362);
            this.btn_close2.Name = "btn_close2";
            this.btn_close2.Size = new System.Drawing.Size(86, 30);
            this.btn_close2.TabIndex = 18;
            this.btn_close2.Text = "Close";
            this.btn_close2.UseVisualStyleBackColor = false;
            // 
            // btn_clear2
            // 
            this.btn_clear2.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_clear2.ForeColor = System.Drawing.Color.Blue;
            this.btn_clear2.Location = new System.Drawing.Point(506, 362);
            this.btn_clear2.Name = "btn_clear2";
            this.btn_clear2.Size = new System.Drawing.Size(86, 30);
            this.btn_clear2.TabIndex = 17;
            this.btn_clear2.Text = "Clear";
            this.btn_clear2.UseVisualStyleBackColor = false;
            // 
            // btn_apply2
            // 
            this.btn_apply2.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_apply2.ForeColor = System.Drawing.Color.Blue;
            this.btn_apply2.Location = new System.Drawing.Point(384, 362);
            this.btn_apply2.Name = "btn_apply2";
            this.btn_apply2.Size = new System.Drawing.Size(86, 30);
            this.btn_apply2.TabIndex = 16;
            this.btn_apply2.Text = "Apply";
            this.btn_apply2.UseVisualStyleBackColor = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.LightCyan;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(19, 44);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(306, 284);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(836, 419);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Reports";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // returnmgt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 466);
            this.Controls.Add(this.tabControl1);
            this.Name = "returnmgt";
            this.Text = "returnmgt";
            this.Load += new System.EventHandler(this.returnmgt_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_docnum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_quantity;
        private System.Windows.Forms.TextBox txt_price;
        private System.Windows.Forms.TextBox txt_itemname;
        private System.Windows.Forms.TextBox txt_itemcode;
        private System.Windows.Forms.TextBox txt_remark;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_apply;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtcid;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_close2;
        private System.Windows.Forms.Button btn_clear2;
        private System.Windows.Forms.Button btn_apply2;
        private System.Windows.Forms.TextBox txt_qnt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btn_cal;
        private System.Windows.Forms.TextBox txt_spclprice;
        private System.Windows.Forms.TextBox txt_desc;
        private System.Windows.Forms.TextBox txt_wsamount;
        private System.Windows.Forms.TextBox txt_purchamount;
        private System.Windows.Forms.TextBox txt_rtnqnt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lable12;
        private System.Windows.Forms.Label lable11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label lbl_subtotal;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}