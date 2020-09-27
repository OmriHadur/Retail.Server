using AutoMapper;
using Core.Server.Common;
using Retail.Common.Entities;
using Retail.Shared.Resources;
using Retail.Shared.Resources.Order;
using System;

namespace Retail.Application.Mapping
{
    [InjectMany]
    public class OrderResourcesMappiing: MappingBase
    {
        public override void AddMapping(Profile profile)
        {
            profile.CreateMap<OrderEntity, OrderResource>()
                .ForMember(te => te.Status, opt => opt.MapFrom(tr => tr.Status.ToString()))
                .ForPath(te => te.Customer.FullName, opt => opt.MapFrom(tr => tr.CustomerFullName))
                .ForPath(te => te.Customer.Address, opt => opt.MapFrom(tr => tr.Address))
                .ForPath(te => te.Customer.Id, opt => opt.MapFrom(tr => tr.Cart.CustomerId));
            profile.CreateMap<OrderItemCreateResource, CartItemEntity>();
            profile.CreateMap<CartItemEntity, OrderItemResource>()
                .ForPath(cir => cir.ItemPrice.PricePerItem, opt => opt.MapFrom(ci => ci.Price))
                .ForPath(cir => cir.ItemPrice.TotalPrice, opt => opt.MapFrom(ci => ci.TotalPrice))
                .ForPath(cir => cir.ItemPrice.HasDiscount, opt => opt.MapFrom(ci => ci.Promotion != null))
                .ForPath(cir => cir.ItemPrice.BeforeDiscount, opt => opt.MapFrom(ci => ci.TotalPriceBeforeDiscount));

            profile.CreateMap<DeliveryWindowOrderCreateResource, DeliveryWindowOrderEntity>()
                .ForMember(te => te.Id, opt => opt.MapFrom(tr => tr.OrderId));
            profile.CreateMap<DeliveryWindowOrderEntity, DeliveryWindowOrderResource>();

            profile.CreateMap<DeliveryWindowCreateResource, DeliveryWindowEntity>()
                .ForMember(te => te.Date, opt => opt.MapFrom(tr => tr.Date.Date));
            profile.CreateMap<DeliveryWindowEntity, DeliveryWindowResource>();

            profile.CreateMap<DeliveryWindowEntity, DeliveryWindowResource>()
                .ForMember(te => te.IsAvailable, opt => opt.MapFrom(tr => tr.Orders.Count < 1));
        }
    }
}
