using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC.Core.ComponentModel;

namespace WpfApplication1
{
    [DescriptiveEnumEnforcement(EnforcementType = DescriptiveEnumEnforcementAttribute.EnforcementTypeEnum.ThrowException)]
    public enum Operation
    {
        [EnumDescription("+")]
        Add,
        [EnumDescription("-")]
        Substract,
        [EnumDescription("*")]
        Multiple,
        [EnumDescription("/")]
        Divide
    }
}
