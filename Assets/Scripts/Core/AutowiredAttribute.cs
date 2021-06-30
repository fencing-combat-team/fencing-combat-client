using System;

namespace Core
{
    /// <summary>
    /// �Զ�ע��Component���ο�ComponentUtils
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class AutowiredAttribute : Attribute
    {
        public AutowiredAttribute()
        {
        }

        public AutowiredAttribute(string gameObject)
        {
            GameObject = gameObject;
        }

        public string GameObject { get; set; }
    }
}