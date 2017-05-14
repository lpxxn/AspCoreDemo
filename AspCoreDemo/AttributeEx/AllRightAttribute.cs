using System;

namespace AspCoreDemo.AttributeEx
{
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Method)]
    public class AllRightAttribute : Attribute
    {
    }
}