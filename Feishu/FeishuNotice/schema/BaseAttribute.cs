namespace FeishuNotice.schema
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class BaseAttribute : Attribute
    {
        public abstract bool Validate(object value, out string errorMessages);
    }
}