using System.ComponentModel;
using System.Reflection;

namespace ProGCoder_ExportExcel.Helpers;

public static class ModelHelper<T>
{
    public static List<string> GetDescriptionProperties()
    {
        var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var descriptions = new List<string>();

        foreach (var prop in props)
        {
            var descriptionAttribute = prop.GetCustomAttribute<DescriptionAttribute>();
            if (descriptionAttribute != null)
            {
                descriptions.Add(descriptionAttribute.Description);
            }
            else
            {
                descriptions.Add(prop.Name);
            }
        }

        return descriptions;
    }
}