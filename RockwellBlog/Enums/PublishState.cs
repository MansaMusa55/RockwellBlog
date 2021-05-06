using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RockwellBlog.Enums
{
    public enum PublishState
    {
        [Description("Production Ready")]
        ProductionReady, 
        PreviewReady,
        NotReady
    }
}
