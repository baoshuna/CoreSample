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
            var assemblyTypes = parts.Where(it => it.GetType().Equals(typeof(AssemblyPart))).Cast<AssemblyPart>();


            foreach (var assemblyType in assemblyTypes)
            {
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
