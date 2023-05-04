namespace model
{
    [AttributeUsage(AttributeTargets.All)]
    public class EnumDescriptionAttribute : Attribute
    {
        private readonly string m_strDescription;

        public EnumDescriptionAttribute(string strPrinterName)
        {
            m_strDescription = strPrinterName;
        }

        public string Description
        {
            get { return m_strDescription; }
        }

        public static string GetEnumDescription(Enum enumObj)
        {
            System.Reflection.FieldInfo? fieldInfo = enumObj.GetType().GetField(enumObj.ToString());

            try
            {
                object[]? attribArray = fieldInfo?.GetCustomAttributes(false);
                if (attribArray is not null && attribArray.Length == 0)
                {
                    return String.Empty;
                }
                else
                {
                    if (attribArray is not null && attribArray[0] is not null)
                    {
                        return attribArray[0] is EnumDescriptionAttribute attrib ? attrib.Description : string.Empty;
                    }
                    return String.Empty;
                }
            }
            catch
            {
                return String.Empty;
            }
        }
    }
}