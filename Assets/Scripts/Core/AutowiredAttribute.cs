using System;

namespace Core
{
    /// <summary>
    /// 自动注入Component，参考ComponentUtils
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class AutowiredAttribute : Attribute
    {

    }
}
