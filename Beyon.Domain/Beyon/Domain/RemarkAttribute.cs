namespace Beyon.Domain
{
    using System;
    using System.Reflection;

    public class RemarkAttribute : Attribute
    {
        private string m_remark;

        public RemarkAttribute(string remark)
        {
            this.m_remark = remark;
        }

        public static string GetEnumRemark(Enum val)
        {
            FieldInfo field = val.GetType().GetField(val.ToString());
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

        public string Remark
        {
            get
            {
                return this.m_remark;
            }
            set
            {
                this.m_remark = value;
            }
        }
    }
}

