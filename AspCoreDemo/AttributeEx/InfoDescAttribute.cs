using System;

namespace AspCoreDemo.AttributeEx
{
    public class InfoDescAttribute : Attribute
    {
        public string Desc { get; set; }
        public InfoDescAttribute(string desc)
        {
            Desc = desc;
        }
    }
}