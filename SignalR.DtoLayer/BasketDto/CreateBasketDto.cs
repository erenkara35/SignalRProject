namespace SignalR.DtoLayer.BasketDto
{
    public class CreateBasketDto
    {
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public decimal TotalPrice { get; set; }
        //Product ile ilişkilendir.
        public int ProductId { get; set; }
        public int MenuTableId { get; set; }
    }
}
