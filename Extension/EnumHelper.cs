using System.ComponentModel;
using System.Reflection;

namespace PersonalSite.Extension;

public static class EnumHelper
{
    public static string GetDescription(this Enum value)
    {
        Type type = value.GetType();
        var name = Enum.GetName(type, value);
        if (name == null)
        {
            return null;
        }

        FieldInfo field = type.GetField(name);
        if (field == null)
        {
            return null;
        }

        DescriptionAttribute attr =
            Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) as DescriptionAttribute;
        return attr?.Description;
    }
}