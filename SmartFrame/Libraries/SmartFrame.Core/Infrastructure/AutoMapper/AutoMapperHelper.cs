using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Castle.Core.Internal;
using SmartFrame.Core.Infrastructure.Reflection;

namespace SmartFrame.Core.Infrastructure.AutoMapper
{
    public static class AutoMapperHelper
    {
        
        public static void CreateMap(Type type)
        {
            CreateMap<AutoMapAttribute>(type);
            CreateMap<AutoMapFromAttribute>(type);
            CreateMap<AutoMapToAttribute>(type);
        }

        

        private static void CreateMap<TAttribute>(Type type) where TAttribute : AutoMapAttribute
        {
            if (type.IsDefined(typeof (TAttribute)))
            {
                foreach (var attribute in type.GetCustomAttributes<TAttribute>())
                {
                    var targetTypes = attribute.TargetTypes;
                    if (targetTypes != null && targetTypes.Any())
                    {
                        foreach (Type targetType in targetTypes)
                        {
                            if (attribute.Direction.HasFlag(AutoMapDirection.To))
                            {
                                Mapper.Map(type, targetType);
                            }

                            if (attribute.Direction.HasFlag(AutoMapDirection.From))
                            {
                                Mapper.Map(targetType,type );
                            }

                        }
                    }
                }
            }

        }
    }
}
