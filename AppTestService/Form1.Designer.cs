using System.Collections.Generic;
using System.Windows.Forms;

namespace SolomonInvoice
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.madonvi = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.thumuc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.apikey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.log = new System.Windows.Forms.TextBox();
            this.lblphienban = new System.Windows.Forms.Label();
            this.bangchung = new System.Windows.Forms.CheckBox();
            this.hinhthuc = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.date_From = new System.Windows.Forms.DateTimePicker();
            this.date_To = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.hengio = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_getListCompanyID = new System.Windows.Forms.Button();
            this.ma_congty = new System.Windows.Forms.ComboBox();
            this.ma_phongban = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.menu_chucnang = new System.Windows.Forms.ComboBox();
            this.field_extend = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.allow_overwrite = new System.Windows.Forms.CheckBox();
            this.btn_getQuantityInvoice = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtPageNumber = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hengio)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mã đơn vị";
            // 
            // madonvi
            // 
            this.madonvi.Enabled = false;
            this.madonvi.Location = new System.Drawing.Point(157, 22);
            this.madonvi.Margin = new System.Windows.Forms.Padding(2);
            this.madonvi.Name = "madonvi";
            this.madonvi.Size = new System.Drawing.Size(144, 20);
            this.madonvi.TabIndex = 6;
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(23, 598);
            this.txtResult.Margin = new System.Windows.Forms.Padding(2);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(518, 82);
            this.txtResult.TabIndex = 16;
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.Blue;
            this.btn_start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_start.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_start.Location = new System.Drawing.Point(157, 433);
            this.btn_start.Margin = new System.Windows.Forms.Padding(2);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(79, 38);
            this.btn_start.TabIndex = 27;
            this.btn_start.Text = "Bắt đầu";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 524);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 14);
            this.label11.TabIndex = 38;
            this.label11.Text = "Đường dẫn lưu tài liệu";
            // 
            // thumuc
            // 
            this.thumuc.Enabled = false;
            this.thumuc.Location = new System.Drawing.Point(157, 524);
            this.thumuc.Margin = new System.Windows.Forms.Padding(2);
            this.thumuc.Name = "thumuc";
            this.thumuc.Size = new System.Drawing.Size(384, 20);
            this.thumuc.TabIndex = 39;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(309, 69);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 14);
            this.label12.TabIndex = 48;
            this.label12.Text = "Số ngày lặp lại";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Brown;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(288, 433);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 38);
            this.button1.TabIndex = 50;
            this.button1.Text = "Kết thúc";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(346, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 14);
            this.label1.TabIndex = 65;
            this.label1.Text = "Apikey";
            // 
            // apikey
            // 
            this.apikey.Enabled = false;
            this.apikey.Location = new System.Drawing.Point(401, 22);
            this.apikey.Margin = new System.Windows.Forms.Padding(2);
            this.apikey.Name = "apikey";
            this.apikey.PasswordChar = '*';
            this.apikey.Size = new System.Drawing.Size(140, 20);
            this.apikey.TabIndex = 66;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 564);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 14);
            this.label3.TabIndex = 67;
            this.label3.Text = "Đường dẫn lưu log";
            // 
            // log
            // 
            this.log.Enabled = false;
            this.log.Location = new System.Drawing.Point(157, 561);
            this.log.Margin = new System.Windows.Forms.Padding(2);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(384, 20);
            this.log.TabIndex = 68;
            // 
            // lblphienban
            // 
            this.lblphienban.AutoSize = true;
            this.lblphienban.Location = new System.Drawing.Point(517, 680);
            this.lblphienban.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblphienban.Name = "lblphienban";
            this.lblphienban.Size = new System.Drawing.Size(24, 14);
            this.lblphienban.TabIndex = 69;
            this.lblphienban.Text = "Ver";
            this.lblphienban.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // bangchung
            // 
            this.bangchung.AutoSize = true;
            this.bangchung.Checked = true;
            this.bangchung.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bangchung.Location = new System.Drawing.Point(401, 138);
            this.bangchung.Margin = new System.Windows.Forms.Padding(2);
            this.bangchung.Name = "bangchung";
            this.bangchung.Size = new System.Drawing.Size(124, 18);
            this.bangchung.TabIndex = 73;
            this.bangchung.Text = "Lấy File bằng chứng";
            this.bangchung.UseVisualStyleBackColor = true;
            // 
            // hinhthuc
            // 
            this.hinhthuc.DisplayMember = "name";
            this.hinhthuc.FormattingEnabled = true;
            this.hinhthuc.Location = new System.Drawing.Point(157, 174);
            this.hinhthuc.Margin = new System.Windows.Forms.Padding(2);
            this.hinhthuc.Name = "hinhthuc";
            this.hinhthuc.Size = new System.Drawing.Size(221, 22);
            this.hinhthuc.TabIndex = 74;
            this.hinhthuc.ValueMember = "id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 483);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 14);
            this.label4.TabIndex = 78;
            this.label4.Text = "ID Hợp đồng";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(157, 486);
            this.id.Margin = new System.Windows.Forms.Padding(2);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(210, 20);
            this.id.TabIndex = 77;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Green;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(401, 483);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 26);
            this.button2.TabIndex = 79;
            this.button2.Text = "Tải HĐ theo ID";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 14);
            this.label5.TabIndex = 82;
            this.label5.Text = "Thời gian từ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(314, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 14);
            this.label6.TabIndex = 83;
            this.label6.Text = "Thời gian đến";
            // 
            // date_From
            // 
            this.date_From.CustomFormat = "dd/MM/yyyy";
            this.date_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_From.Location = new System.Drawing.Point(157, 101);
            this.date_From.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.date_From.Name = "date_From";
            this.date_From.Size = new System.Drawing.Size(144, 20);
            this.date_From.TabIndex = 84;
            this.date_From.Value = new System.DateTime(2023, 7, 4, 9, 7, 39, 122);
            // 
            // date_To
            // 
            this.date_To.CustomFormat = "dd/MM/yyyy";
            this.date_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_To.Location = new System.Drawing.Point(401, 103);
            this.date_To.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.date_To.Name = "date_To";
            this.date_To.Size = new System.Drawing.Size(140, 20);
            this.date_To.TabIndex = 85;
            this.date_To.Value = new System.DateTime(2023, 7, 4, 9, 7, 39, 124);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 69);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 14);
            this.label7.TabIndex = 86;
            this.label7.Text = "Tự động lặp lại theo ngày";
            // 
            // hengio
            // 
            this.hengio.Location = new System.Drawing.Point(0, 0);
            this.hengio.Name = "hengio";
            this.hengio.Size = new System.Drawing.Size(120, 20);
            this.hengio.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 89;
            this.label8.Text = "Hình thức lấy";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 14);
            this.label9.TabIndex = 90;
            this.label9.Text = "Lấy theo Công ty";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(19, 248);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 14);
            this.label10.TabIndex = 91;
            this.label10.Text = "Lấy theo phòng ban";
            // 
            // btn_getListCompanyID
            // 
            this.btn_getListCompanyID.BackColor = System.Drawing.Color.Green;
            this.btn_getListCompanyID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_getListCompanyID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_getListCompanyID.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_getListCompanyID.Location = new System.Drawing.Point(401, 171);
            this.btn_getListCompanyID.Margin = new System.Windows.Forms.Padding(2);
            this.btn_getListCompanyID.Name = "btn_getListCompanyID";
            this.btn_getListCompanyID.Size = new System.Drawing.Size(124, 26);
            this.btn_getListCompanyID.TabIndex = 94;
            this.btn_getListCompanyID.Text = "Lấy danh sách CTY";
            this.btn_getListCompanyID.UseVisualStyleBackColor = false;
            this.btn_getListCompanyID.Click += new System.EventHandler(this.btn_getListCompanyID_Click);
            // 
            // ma_congty
            // 
            this.ma_congty.DisplayMember = "name";
            this.ma_congty.FormattingEnabled = true;
            this.ma_congty.Location = new System.Drawing.Point(157, 211);
            this.ma_congty.Margin = new System.Windows.Forms.Padding(2);
            this.ma_congty.Name = "ma_congty";
            this.ma_congty.Size = new System.Drawing.Size(221, 22);
            this.ma_congty.TabIndex = 95;
            this.ma_congty.ValueMember = "id";
            this.ma_congty.SelectedIndexChanged += new System.EventHandler(this.ma_congty_SelectedIndexChanged);
            // 
            // ma_phongban
            // 
            this.ma_phongban.DisplayMember = "name";
            this.ma_phongban.FormattingEnabled = true;
            this.ma_phongban.Location = new System.Drawing.Point(157, 248);
            this.ma_phongban.Margin = new System.Windows.Forms.Padding(2);
            this.ma_phongban.Name = "ma_phongban";
            this.ma_phongban.Size = new System.Drawing.Size(221, 22);
            this.ma_phongban.TabIndex = 96;
            this.ma_phongban.ValueMember = "id";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(19, 65);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 14);
            this.label13.TabIndex = 97;
            this.label13.Text = "Chọn chức năng";
            // 
            // menu_chucnang
            // 
            this.menu_chucnang.DisplayMember = "name";
            this.menu_chucnang.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_chucnang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.menu_chucnang.FormattingEnabled = true;
            this.menu_chucnang.Location = new System.Drawing.Point(157, 61);
            this.menu_chucnang.Margin = new System.Windows.Forms.Padding(2);
            this.menu_chucnang.Name = "menu_chucnang";
            this.menu_chucnang.Size = new System.Drawing.Size(144, 22);
            this.menu_chucnang.TabIndex = 98;
            this.menu_chucnang.ValueMember = "id";
            this.menu_chucnang.SelectedIndexChanged += new System.EventHandler(this.menu_chucnang_SelectedIndexChanged);
            // 
            // field_extend
            // 
            this.field_extend.Enabled = false;
            this.field_extend.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.field_extend.Location = new System.Drawing.Point(157, 287);
            this.field_extend.Name = "field_extend";
            this.field_extend.Size = new System.Drawing.Size(384, 61);
            this.field_extend.TabIndex = 99;
            this.field_extend.Text = "";
            this.field_extend.GotFocus += new System.EventHandler(this.RemoveText);
            this.field_extend.LostFocus += new System.EventHandler(this.AddText);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(18, 287);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 14);
            this.label14.TabIndex = 100;
            this.label14.Text = "Tên field mở rộng Export";
            // 
            // allow_overwrite
            // 
            this.allow_overwrite.AutoSize = true;
            this.allow_overwrite.Location = new System.Drawing.Point(401, 61);
            this.allow_overwrite.Margin = new System.Windows.Forms.Padding(2);
            this.allow_overwrite.Name = "allow_overwrite";
            this.allow_overwrite.Size = new System.Drawing.Size(150, 18);
            this.allow_overwrite.TabIndex = 102;
            this.allow_overwrite.Text = "Cho phép ghi đè file đã tải";
            this.allow_overwrite.UseVisualStyleBackColor = true;
            // 
            // btn_getQuantityInvoice
            // 
            this.btn_getQuantityInvoice.BackColor = System.Drawing.Color.Green;
            this.btn_getQuantityInvoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_getQuantityInvoice.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_getQuantityInvoice.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_getQuantityInvoice.Location = new System.Drawing.Point(401, 379);
            this.btn_getQuantityInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.btn_getQuantityInvoice.Name = "btn_getQuantityInvoice";
            this.btn_getQuantityInvoice.Size = new System.Drawing.Size(124, 26);
            this.btn_getQuantityInvoice.TabIndex = 104;
            this.btn_getQuantityInvoice.Text = "Lấy số lượng HĐ";
            this.btn_getQuantityInvoice.UseVisualStyleBackColor = false;
            this.btn_getQuantityInvoice.Click += new System.EventHandler(this.btn_getQuantityInvoice_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(21, 401);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 14);
            this.label15.TabIndex = 105;
            this.label15.Text = "Số lượng tài liệu";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(157, 398);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.Size = new System.Drawing.Size(210, 20);
            this.txtQuantity.TabIndex = 106;
            // 
            // txtPageNumber
            // 
            this.txtPageNumber.Location = new System.Drawing.Point(157, 366);
            this.txtPageNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtPageNumber.Name = "txtPageNumber";
            this.txtPageNumber.Size = new System.Drawing.Size(210, 20);
            this.txtPageNumber.TabIndex = 107;
            this.txtPageNumber.Text = "1";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(22, 372);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 14);
            this.label16.TabIndex = 108;
            this.label16.Text = "Trang số";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 696);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtPageNumber);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btn_getQuantityInvoice);
            this.Controls.Add(this.allow_overwrite);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.field_extend);
            this.Controls.Add(this.menu_chucnang);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ma_phongban);
            this.Controls.Add(this.ma_congty);
            this.Controls.Add(this.btn_getListCompanyID);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.date_To);
            this.Controls.Add(this.date_From);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.id);
            this.Controls.Add(this.hinhthuc);
            this.Controls.Add(this.bangchung);
            this.Controls.Add(this.lblphienban);
            this.Controls.Add(this.log);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.apikey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.thumuc);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.madonvi);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tool đồng bộ Ccontract";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.hengio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox madonvi;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox thumuc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox apikey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.Label lblphienban;
        private System.Windows.Forms.CheckBox bangchung;
        private System.Windows.Forms.ComboBox hinhthuc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker date_From;
        private System.Windows.Forms.DateTimePicker date_To;
        private Label label7;
        // Ẩn lặp lại theo ngày
        //private CheckBox chBox_Timer;
        private NumericUpDown hengio;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button btn_getListCompanyID;
        private ComboBox ma_congty;
        private ComboBox ma_phongban;
        private Label label13;
        private ComboBox menu_chucnang;
        private RichTextBox field_extend;
        private Label label14;
        private CheckBox allow_overwrite;
        private Button btn_getQuantityInvoice;
        private Label label15;
        private TextBox txtQuantity;
        private TextBox txtPageNumber;
        private Label label16;
    }
}

