using AutoMapper;
using Core.Server.Common.Entities;
using Core.Server.Common.Mapping;
using Core.Server.Shared.Resources;
using System;

namespace Retail.Application.Mapping
{
    public abstract class MappingBase : IResourceMapper
    {
        public abstract void AddMapping(Profile profile);

        public void AddMapping<TCreateResource, TResource, TEntity>(Profile profile)
            where TCreateResource : CreateResource
            where TResource : Resource
            where TEntity : Entity, new()
        {
            profile.CreateMap<TCreateResource, TEntity>();
            profile.CreateMap<TResource, TEntity>().ReverseMap();
        }

        public string SizeDisplay(int size,bool IsInGrams)
        {
            var roundedSize = size < 1000 ? size : Math.Round((decimal)size / 1000, 1);
            return LongUom(roundedSize, size, IsInGrams);
        }
        public string ShortUom(decimal valueDisplay, int value, bool inInGrams)
        {
            return $"{valueDisplay} {(inInGrams ? (value > 999 ? "kg" : "g") : "l")}";
        }
        public string LongUom(decimal valueDisplay, int value, bool inInGrams)
        {
            return $"{valueDisplay} {(inInGrams ? (value > 999 ? "Kilo" : "Gram") : "Liter")}";
        }
    }
}
