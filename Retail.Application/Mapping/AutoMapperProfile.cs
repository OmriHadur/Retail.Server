using AutoMapper;
using Retail.Common.Entities;
using Retail.Standard.Shared.Resources;
using Retail.Standard.Shared.Resources.Users;
using System;
using System.Linq;

namespace Retail.Application.Mapping
{
    public class AutoMapperProfile : MappingBase
    {
        public AutoMapperProfile()
        {
            new CartResourcesMappiing().AddMapping(this);
            new OrderResourcesMappiing().AddMapping(this);

            AddMapping<WeatherForecastCreateResource, WeatherForecastResource, WeatherForecastEntity>();
            AddMapping<ProductCreateResource, ProductResource, ProductEntity>();
            AddMapping<PromotionCreateResource, PromotionResource, PromotionEntity>();

            CreateMap<ProductCreateResource, ProductEntity>()
                .ForMember(d => d.Price, opt => opt.MapFrom(s => Math.Round(s.Price, 2)))
                .ForMember(d => d.SizeDisplay, opt => opt.MapFrom(s => SizeDisplay(s.Size,s.IsInGrams)));

            AddMapping<UserCreateResource, UserResource, UserEntity>();
            AddMapping<LoginCreateResource, LoginResource, LoginEntity>();
            AddMapping<AddressCreateResource, AddressResource, AddressEntity>();

            AddMapping<DepartmentCreateResource, DepartmentResource, DepartmentEntity>();
            CreateMap<DepartmentEntity, DepartmentResource>()
                .ForMember(te => te.Families, opt => DepartmentFamilies(opt));

            CreateMap<CategoryEntity, CategoryResource>();
            CreateMap<DepartmentCreateResource, CategoryEntity>();
            CreateMap<CategoryCreateResource, CategoryEntity>();
        }

        private void DepartmentFamilies(IMemberConfigurationExpression<DepartmentEntity, DepartmentResource, CategoryFamily[]> opt)
        {
            opt.MapFrom((tr, a, b, map) => tr.CategoriesByFamily.Select(s => new CategoryFamily() { Name = s.Key, Categories = map.Mapper.Map<CategoryResource[]>(s.Value) }));
        }
    }
}