using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ApplicationPartSample.Extensions
{
    public class GenericControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            // 获取ApplicationPart中所有的AssemblyPart
            var assemblyTypes = parts.Where(it => it.GetType().Equals(typeof(AssemblyPart))).Cast<AssemblyPart>();


            foreach (var assemblyType in assemblyTypes)
            {
                // 获取当前AssemblyPart中的所有以"Test"结尾的类
                var types = assemblyType.Assembly.GetTypes()
                    .Where(it => it.Name.EndsWith("Test"));

                foreach (Type type in types)
                {
                    feature.Controllers.Add(type.GetTypeInfo());
                }
            }
        }
    }
}
