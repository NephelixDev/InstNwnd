namespace InstNwnd.Web.Data.Models.OrdersCrud
{
    public class OrdersModels
    {
        public object OrderId { get; internal set; }
        public object CustomerId { get; internal set; }
        public object EmployeeId { get; internal set; }
        public object OrderDate { get; internal set; }
        public object RequiredDate { get; internal set; }
        public object ShippedDate { get; internal set; }
        public object ShipVia { get; internal set; }
        public object Freight { get; internal set; }
        public object ShipName { get; internal set; }
        public object ShipAddress { get; internal set; }
        public object ShipCity { get; internal set; }
        public object ShipRegion { get; internal set; }
        public object ShipPostalCode { get; internal set; }
        public object ShipCountry { get; internal set; }
    }
}
