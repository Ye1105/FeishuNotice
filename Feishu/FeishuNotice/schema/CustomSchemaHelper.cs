using FeishuNotice.schema;

namespace Manager.Extensions.AttributeSchemas
{
    public static class CustomSchemaHelper
    {
        /// <summary>
        /// 实体扩展方法
        /// 验证方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Validate<T>(this T model, out IList<string> errorMessages) where T : class
        {
            errorMessages = new List<string>();
            try
            {
                //获取类型
                Type type = model.GetType();

                //反射找到属性值
                var properties = type.GetProperties();
                var count = 0;

                //遍历属性
                foreach (var prop in properties)
                {
                    #region 【枚举校验】

                    //【枚举校验】
                    var isEnumType = prop.GetMethod.ReturnType.IsEnum;
                    if (isEnumType)
                    {
                        //获取当前的枚举值
                        var value = prop.GetValue(model);

                        //程序集
                        var assembly = prop.GetMethod.ReturnType.Assembly;

                        //命名空间
                        var nameSpace = prop.GetMethod.ReturnType.Namespace;

                        //名称
                        var name = prop.GetMethod.ReturnType.Name;

                        //创建枚举实例
                        var enumInfo = assembly.CreateInstance($"{nameSpace}.{name}", false);
                        if (enumInfo != null)
                        {
                            var enumType = enumInfo.GetType();
                            var enums = Enum.GetValues(enumType);
                            List<int> values = new();
                            foreach (var item in enums)
                            {
                                values.Add((int)item);
                            }
                            if (values == null || !values.Any())
                            {
                                count++;
                                errorMessages.Add($"{prop.Name}- EnumValidate:枚举成员为空");
                            }
                            else if (!values.Contains((int)value))
                            {
                                count++;
                                errorMessages.Add($"{prop.Name}- EnumValidate:值 {(int)value} 不在枚举 {name} 范围中");
                            }
                        }
                        else
                        {
                            count++;
                            errorMessages.Add($"{prop.Name}- EnumValidate:枚举实例创建失败");
                        }

                        continue;
                    }

                    #endregion 【枚举校验】

                    #region 【特性校验】

                    //【特性校验】是否将指定类型或其派生类型的一个或多个特性应用于此成员
                    if (prop.IsDefined(typeof(BaseAttribute), true))
                    {
                        var attributes = prop.GetCustomAttributes(typeof(BaseAttribute), true); //获取自定义特性

                        foreach (BaseAttribute attr in attributes.Cast<BaseAttribute>())
                        {
                            var res = attr.Validate(prop.GetValue(model), out string errorMessage);
                            if (!res)
                            {
                                count++;
                                errorMessages.Add($"{prop.Name}-{errorMessage}");
                            }
                        }
                    }

                    #endregion 【特性校验】
                }
                if (count > 0)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                errorMessages.Add(ex.ToString());
                return false;
            }
        }
    }
}