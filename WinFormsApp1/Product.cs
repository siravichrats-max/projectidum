namespace WinFormsApp1 // *** เช็คชื่อนี้ให้ตรงกับโปรเจกต์คุณ ***
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        // เพิ่มตัวนี้ครับ เอาไว้เก็บจำนวนสินค้าคงเหลือ
        public int Quantity { get; set; }
    }

}