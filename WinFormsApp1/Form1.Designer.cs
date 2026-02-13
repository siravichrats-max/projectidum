namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            groupBox1 = new GroupBox();
            btnSell_Click = new Button();
            cboBrand = new ComboBox();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            txtSaleQty = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            button8 = new Button();
            btnPrint = new Button();
            btnSearch = new Button();
            button5 = new Button();
            btnAdd = new Button();
            button3 = new Button();
            button2 = new Button();
            txtCategory = new TextBox();
            txtPrice = new TextBox();
            txtName = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            printDoc = new System.Drawing.Printing.PrintDocument();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 27);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 0;
            label1.Text = "Book Shop 101";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSell_Click);
            groupBox1.Controls.Add(cboBrand);
            groupBox1.Controls.Add(textBox6);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(txtSaleQty);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(button8);
            groupBox1.Controls.Add(btnPrint);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(txtCategory);
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(25, 69);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(265, 497);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "รายการ";
            // 
            // btnSell_Click
            // 
            btnSell_Click.Font = new Font("Segoe UI", 8.25F);
            btnSell_Click.Location = new Point(6, 205);
            btnSell_Click.Name = "btnSell_Click";
            btnSell_Click.Size = new Size(75, 23);
            btnSell_Click.TabIndex = 24;
            btnSell_Click.Text = "ขาย";
            btnSell_Click.UseVisualStyleBackColor = true;
            // 
            // cboBrand
            // 
            cboBrand.FormattingEnabled = true;
            cboBrand.Location = new Point(76, 74);
            cboBrand.Name = "cboBrand";
            cboBrand.Size = new Size(100, 23);
            cboBrand.TabIndex = 23;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(149, 344);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(100, 23);
            textBox6.TabIndex = 22;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(147, 297);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 21;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(149, 251);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 20;
            // 
            // txtSaleQty
            // 
            txtSaleQty.Location = new Point(149, 207);
            txtSaleQty.Name = "txtSaleQty";
            txtSaleQty.Size = new Size(100, 23);
            txtSaleQty.TabIndex = 19;
            txtSaleQty.Click += txtSaleQty_Click_1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(100, 345);
            label9.Name = "label9";
            label9.Size = new Size(43, 17);
            label9.TabIndex = 18;
            label9.Text = "จํานวน";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(100, 298);
            label8.Name = "label8";
            label8.Size = new Size(43, 17);
            label8.TabIndex = 17;
            label8.Text = "จํานวน";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(100, 251);
            label7.Name = "label7";
            label7.Size = new Size(43, 17);
            label7.TabIndex = 16;
            label7.Text = "จํานวน";
            // 
            // button8
            // 
            button8.Font = new Font("Segoe UI", 8.25F);
            button8.Location = new Point(172, 387);
            button8.Name = "button8";
            button8.Size = new Size(75, 23);
            button8.TabIndex = 15;
            button8.Text = "ล้าง";
            button8.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            btnPrint.Font = new Font("Segoe UI", 8.25F);
            btnPrint.Location = new Point(140, 425);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(75, 23);
            btnPrint.TabIndex = 14;
            btnPrint.Text = "ปริ้นใบ PDF";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 8.25F);
            btnSearch.Location = new Point(41, 425);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 13;
            btnSearch.Text = "ค้นหาสินค้า";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 8.25F);
            button5.Location = new Point(6, 387);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 12;
            button5.Text = "ลบสินค้า";
            button5.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 8.25F);
            btnAdd.Location = new Point(6, 343);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "เพิ่มสินค้า";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 8.25F);
            button3.Location = new Point(6, 296);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 10;
            button3.Text = "ส่งออก";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 8.25F);
            button2.Location = new Point(6, 249);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 9;
            button2.Text = "นําเข้า";
            button2.UseVisualStyleBackColor = true;
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(76, 160);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(100, 23);
            txtCategory.TabIndex = 7;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(76, 117);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 23);
            txtPrice.TabIndex = 6;
            // 
            // txtName
            // 
            txtName.Location = new Point(76, 30);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(100, 207);
            label6.Name = "label6";
            label6.Size = new Size(43, 17);
            label6.TabIndex = 4;
            label6.Text = "จํานวน";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(6, 161);
            label5.Name = "label5";
            label5.Size = new Size(56, 17);
            label5.TabIndex = 3;
            label5.Text = "จ่ายสินค้า";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(6, 118);
            label4.Name = "label4";
            label4.Size = new Size(33, 17);
            label4.TabIndex = 2;
            label4.Text = "ราคา";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(6, 75);
            label3.Name = "label3";
            label3.Size = new Size(42, 17);
            label3.TabIndex = 1;
            label3.Text = "แบรนด์";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 31);
            label2.Name = "label2";
            label2.Size = new Size(51, 17);
            label2.TabIndex = 0;
            label2.Text = "ชื่อสินค้า";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(438, 87);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(341, 479);
            dataGridView1.TabIndex = 2;
            // 
            // printDoc
            // 
            printDoc.PrintPage += printDoc_PrintPage;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 591);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private ComboBox cboBrand;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox txtSaleQty;
        private Label label9;
        private Label label8;
        private Label label7;
        private Button button8;
        private Button btnPrint;
        private Button btnSearch;
        private Button button5;
        private Button btnAdd;
        private Button button3;
        private Button button2;
        private TextBox txtCategory;
        private TextBox txtPrice;
        private TextBox txtName;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnSell_Click;
        private System.Drawing.Printing.PrintDocument printDoc;
    }
}
