namespace Beyon.Domain
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public static class EnumExtension
    {
        public static string GetRemark(this Enum em)
        {
            FieldInfo field = em.GetType().GetField(em.ToString());
            if (field == null)
            {
                return string.Empty;
            }
            object[] customAttributes = field.GetCustomAttributes(typeof(RemarkAttribute), false);
            string remark = string.Empty;
            foreach (RemarkAttribute attribute in customAttributes)
            {
                remark = attribute.Remark;
            }
            return remark;
        }
    }
}

