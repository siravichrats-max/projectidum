using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsApp1 // *** เช็คชื่อนี้ให้ตรงกับโปรเจกต์ของคุณ (ดูที่บรรทัดบนสุดของไฟล์ Program.cs) ***
{
    public partial class Form1 : Form
    {
        int id = 0;
        decimal price = 0;
        int currentStock = 0;

        // 1. ตัวเชื่อมฐานข้อมูล
        DatabaseHelper db = new DatabaseHelper();

        public Form1()
        {
            InitializeComponent();
        }

        // 2. ฟังก์ชันโหลดหน้าจอ
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData(); // โหลดข้อมูลลงตารางทันทีที่เปิดโปรแกรม

            // (แถม) เพิ่มตัวเลือกใน ComboBox แบรนด์ให้อัตโนมัติ (ถ้ายังไม่ได้ใส่ใน Properties)
            if (cboBrand.Items.Count == 0)
            {
                cboBrand.Items.Add("Nike");
                cboBrand.Items.Add("Adidas");
                cboBrand.Items.Add("Puma");
                cboBrand.Items.Add("Uniqlo");
            }
        }

        // 3. ฟังก์ชันดึงข้อมูลมาแสดงในตาราง
        // แก้ไขฟังก์ชันนี้ใน Form1.cs
        private void LoadData()
        {
            try
            {
                // 1. สั่งตัดการเชื่อมต่อเก่าก่อน (เพื่อให้มันรู้ว่ามีการเปลี่ยนแปลง)
                dataGridView1.DataSource = null;

                // 2. ดึงข้อมูลใหม่มาใส่
                dataGridView1.DataSource = db.GetAllProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // 4. ฟังก์ชันปุ่มเพิ่มสินค้า (กดแล้วบันทึก)
        // ฟังก์ชันปุ่มเพิ่มสินค้า (โค้ดที่หายไป)
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Product p = new Product();
                p.Name = txtName.Text;
                p.Brand = cboBrand.Text;
                p.Category = txtCategory.Text;

                // แปลงราคาจากข้อความ เป็นตัวเลข
                if (decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    p.Price = price;
                }
                else
                {
                    MessageBox.Show("กรุณากรอกราคาเป็นตัวเลขเท่านั้น");
                    return;
                }

                // บันทึกลงฐานข้อมูล
                db.AddProduct(p);
                MessageBox.Show("เพิ่มสินค้าเรียบร้อย!");

                // ล้างค่าในช่องกรอก
                txtName.Clear();
                txtPrice.Clear();
                txtCategory.Clear();
                cboBrand.SelectedIndex = -1;

                // โหลดตารางใหม่
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtName.Text; // ใช้ช่องชื่อสินค้าในการค้นหาไปก่อน

            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("กรุณาพิมพ์คำค้นหา");
                return;
            }

            // เรียกใช้ฟังก์ชันค้นหาที่เราเพิ่งเขียน
            List<Product> result = db.SearchProducts(keyword);

            // เอาผลลัพธ์ใส่ตาราง
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = result;
        }




        private void txtSaleQty_Click_1(object sender, EventArgs e)
        {
            // 1. ตรวจว่าเลือกสินค้าหรือยัง
            if (id == 0)
            {
                MessageBox.Show("กรุณาเลือกสินค้าก่อน");
                return;
            }

            // 2. แปลงค่าจำนวนที่ลูกค้าพิมพ์
            int saleQty = 0;
            if (int.TryParse(txtSaleQty.Text, out saleQty) == false)
            {
                MessageBox.Show("กรุณากรอกจำนวนให้ถูกต้อง");
                return;
            }

            // 3. เช็คสต็อก
            if (currentStock < saleQty)
            {
                MessageBox.Show($"สินค้าไม่พอ! มีเหลือแค่ {currentStock} ชิ้น");
                return;
            }

            // 4. คำนวณเงินและตัดสต็อก
            decimal totalPrice = price * saleQty;
            int newStock = currentStock - saleQty;

            // อัปเดตลงฐานข้อมูล
            db.UpdateStock(id, newStock);

            // 5. แสดงใบเสร็จ
            string receipt = $"=== ใบเสร็จรับเงิน ===\n\n" +
                             $"สินค้า: {txtName.Text}\n" +
                             $"ราคาต่อชิ้น: {price:N2} บาท\n" +
                             $"จำนวนที่ซื้อ: {saleQty}\n" +
                             $"------------------\n" +
                             $"รวมเป็นเงิน: {totalPrice:N2} บาท\n" +
                             $"------------------\n" +
                             $"ขอบคุณที่ใช้บริการ";

            MessageBox.Show(receipt, "การขายสำเร็จ");

            // 6. โหลดตารางใหม่และเคลียร์ช่อง
            LoadData();
            txtSaleQty.Clear();
        }

        private void btnSell_Click_Click(object sender, EventArgs e)
        {
            // 1. ตรวจว่าเลือกสินค้าหรือยัง
            if (id == 0)
            {
                MessageBox.Show("กรุณาเลือกสินค้าก่อน");
                return;
            }

            // 2. แปลงค่าจำนวนที่ลูกค้าพิมพ์
            int saleQty = 0;
            if (int.TryParse(txtSaleQty.Text, out saleQty) == false)
            {
                MessageBox.Show("กรุณากรอกจำนวนให้ถูกต้อง");
                return;
            }

            // 3. เช็คสต็อก
            if (currentStock < saleQty)
            {
                MessageBox.Show($"สินค้าไม่พอ! มีเหลือแค่ {currentStock} ชิ้น");
                return;
            }

            // 4. คำนวณเงินและตัดสต็อก
            decimal totalPrice = price * saleQty;
            int newStock = currentStock - saleQty;

            // อัปเดตลงฐานข้อมูล
            db.UpdateStock(id, newStock);

            // 5. แสดงใบเสร็จ
            string receipt = $"=== ใบเสร็จรับเงิน ===\n\n" +
                             $"สินค้า: {txtName.Text}\n" +
                             $"ราคาต่อชิ้น: {price:N2} บาท\n" +
                             $"จำนวนที่ซื้อ: {saleQty}\n" +
                             $"------------------\n" +
                             $"รวมเป็นเงิน: {totalPrice:N2} บาท\n" +
                             $"------------------\n" +
                             $"ขอบคุณที่ใช้บริการ";

            MessageBox.Show(receipt, "การขายสำเร็จ");

            // 6. โหลดตารางใหม่และเคลียร์ช่อง
            LoadData();
            txtSaleQty.Clear();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // สั่งให้ปริ้น
            // บรรทัดนี้จะบังคับให้เลือกเครื่องปริ้นเป็น PDF ทันที
            printDoc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            printDoc.Print();
        }

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // --- ตั้งค่าฟอนต์ (ขนาดตัวหนังสือ) ---
            Font titleFont = new Font("Angsana New", 20, FontStyle.Bold); // หัวข้อ
            Font bodyFont = new Font("Angsana New", 16, FontStyle.Regular); // เนื้อหา
            Brush brush = Brushes.Black; // สีหมึกดำ

            // --- เริ่มวาดหัวกระดาษ ---
            int y = 50; // เริ่มเขียนบรรทัดแรกที่ความสูง 50
            e.Graphics.DrawString("รายงานสต็อกสินค้า", titleFont, brush, 300, y);

            y += 40; // ขยับลงมา 40
            e.Graphics.DrawString("วันที่พิมพ์: " + DateTime.Now.ToString(), bodyFont, brush, 50, y);

            y += 30;
            e.Graphics.DrawString("--------------------------------------------------------------------------------", bodyFont, brush, 50, y);

            // --- วาดหัวตาราง ---
            y += 30;
            e.Graphics.DrawString("ชื่อสินค้า", bodyFont, brush, 50, y);
            e.Graphics.DrawString("ราคา", bodyFont, brush, 300, y);
            e.Graphics.DrawString("จำนวนคงเหลือ", bodyFont, brush, 450, y);

            y += 10;
            e.Graphics.DrawString("--------------------------------------------------------------------------------", bodyFont, brush, 50, y);

            // --- วนลูปดึงข้อมูลจากตาราง (DataGridView) มาแสดง ---
            y += 30; // เริ่มรายการแรก

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // ถ้าเป็นบรรทัดว่างๆ ให้ข้ามไป
                if (row.IsNewRow) continue;

                // ดึงค่าจากแต่ละช่อง (ชื่อ, ราคา, จำนวน)
                // หมายเหตุ: เช็คเลขช่อง Cells[...] ให้ตรงกับตารางของคุณ (ปกติเริ่มที่ 0, 1, 2...)
                // สมมติ: ช่อง 1=ชื่อ, ช่อง 3=ราคา, ช่อง 4=จำนวน (ตามรูปที่คุณเคยส่งมา)
                string name = row.Cells[1].Value?.ToString() ?? "";
                string price = row.Cells[3].Value?.ToString() ?? "0";
                string stock = row.Cells[4].Value?.ToString() ?? "0";

                // วาดลงกระดาษ
                e.Graphics.DrawString(name, bodyFont, brush, 50, y);
                e.Graphics.DrawString(price, bodyFont, brush, 300, y);
                e.Graphics.DrawString(stock, bodyFont, brush, 450, y);

                y += 30; // ขยับบรรทัดลงมาสำหรับการวนรอบถัดไป
            }
        }
    }
}