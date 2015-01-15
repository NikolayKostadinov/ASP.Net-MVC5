namespace SportStore.Domain.Abstract
{
    using SportStore.Domain.Entities;

    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
