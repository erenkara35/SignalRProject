using System.ComponentModel.DataAnnotations.Schema;

namespace SignalR.EntityLayer.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string TableNumber { get; set; }
        public string Description { get; set; }
       
        [Column(TypeName ="Date")] //DateTime yapıp Date olarak kullanmak (string.leng kullanımı gibi)
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderDetail> OrderDetails { get; set;}
    }
}

