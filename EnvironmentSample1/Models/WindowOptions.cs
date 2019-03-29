using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnvironmentSample1.Models
{
    public class WindowOptions :IOptions<WindowOptions>
    {
        public WindowOptions Value => this;

        public string Length { get; set; }

        public string Width { get; set; }

        public string Height { get; set; }

    }
}
