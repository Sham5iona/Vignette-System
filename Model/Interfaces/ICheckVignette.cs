using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VignetteSystem.Model.Interfaces
{
    public interface ICheckVignette
    {
        public Task<Vignette> ConnectToAPIAsync(string api);
    }
}
