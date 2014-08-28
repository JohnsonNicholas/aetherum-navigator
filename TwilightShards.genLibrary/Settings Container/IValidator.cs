using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwilightShards.genLibrary
{
    public interface IValidator
    {
        bool Validate(object input);
    }
}
