using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace FastMoneyBookmaker.Helpers
{
    class EnumExtension:MarkupExtension
    {
        public Type EnumType { get; set; }
        public EnumExtension() { }
        public EnumExtension(Type enumType) => EnumType = enumType;
        public override object ProvideValue(IServiceProvider serviceProvider)
            => Enum.GetValues(EnumType);
    }
}
