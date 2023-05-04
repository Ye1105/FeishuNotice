using FeishuNotice.schema;

namespace Manager.Extensions.AttributeSchemas
{
    /// <summary>
    /// 用户 Open ID 匹配规则
    /// </summary>
    public class UserAttribute : BaseAttribute
    {
        public override bool Validate(object? value, out string errorMessages)
        {
            errorMessages = "";
            try
            {
                var v = value?.ToString();
                if (!string.IsNullOrWhiteSpace(v))
                {
                    if (v.StartsWith("ou_"))
                    {
                        return true;
                    }
                    else
                    {
                        errorMessages = $"{this.GetType().Name}:请输入正确 @ 格式";
                        return false;
                    }
                }
                errorMessages = "值为空";
                return false;
            }
            catch (Exception ex)
            {
                errorMessages = $"{this.GetType().Name}:{ex}";
                return false;
            }
        }
    }
}