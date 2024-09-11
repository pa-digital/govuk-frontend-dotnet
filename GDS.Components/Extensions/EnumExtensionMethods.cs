namespace GDS.Components.Extensions
{
    public static class EnumExtensionMethods
    {
        public static TAttribute GetAttribute<TAttribute>(this System.Enum value)
            where TAttribute : Attribute
        {
            var enumType = value.GetType();
            var name = System.Enum.GetName(enumType, value);
            return enumType.GetField(name).GetCustomAttributes(false).OfType<TAttribute>().SingleOrDefault();
        }
    }
}
