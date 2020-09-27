using AutoMapper;
using Core.Server.Common;
using Retail.Common.Entities;
using Retail.Shared.Resources;
using System;
using System.Linq;

namespace Retail.Application.Mapping
{
    [InjectMany]
    public class AutoMapperProfile : MappingBase
    {
        public override void AddMapping(Profile profile)
        {
            AddMapping<ProductCreateResource, ProductResource, ProductEntity>(profile);
            AddMapping<PromotionCreateResource, PromotionResource, PromotionEntity>(profile);

            profile.CreateMap<ProductCreateResource, ProductEntity>()
                .ForMember(d => d.Price, opt => opt.MapFrom(s => Math.Round(s.Price, 2)))
                .ForMember(d => d.SizeDisplay, opt => opt.MapFrom(s => SizeDisplay(s.Size,s.IsInGrams)));

            AddMapping<AddressCreateResource, AddressResource, AddressEntity>(profile);

            AddMapping<DepartmentCreateResource, DepartmentResource, DepartmentEntity>(profile);
            profile.CreateMap<DepartmentEntity, DepartmentResource>()
                .ForMember(te => te.Families, opt => DepartmentFamilies(opt));

            profile.CreateMap<CategoryEntity, CategoryResource>();
            profile.CreateMap<DepartmentCreateResource, CategoryEntity>();
            profile.CreateMap<CategoryCreateResource, CategoryEntity>();
        }

        private void DepartmentFamilies(IMemberConfigurationExpression<DepartmentEntity, DepartmentResource, CategoryFamily[]> opt)
        {
            opt.MapFrom((tr, a, b, map) => tr.CategoriesByFamily.Select(s => new CategoryFamily() { Name = s.Key, Categories = map.Mapper.Map<CategoryResource[]>(s.Value) }));
        }
    }
}