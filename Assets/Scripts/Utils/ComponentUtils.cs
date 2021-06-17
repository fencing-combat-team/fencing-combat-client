using System.Reflection;
using Core;
using UnityEngine;

namespace Utils
{
    public static class ComponentUtils
    {
        public static void InitComponents(this MonoBehaviour behaviour)
        {
            InitComponents(behaviour.gameObject, behaviour);
        }
        
        public static void InitComponents(this StateMachineBehaviour behaviour, Animator animator)
        {
            InitComponents(animator.gameObject, behaviour);
        }

        /// <summary>
        /// 从GameObject获取Component， 注入[Autowired]特性标记的变量
        /// </summary>
        /// <param name="go">从GameObject</param>
        /// <param name="target">要注入的对象</param>
        public static void InitComponents(GameObject go, object target)
        {
            //自动GetComponent
            var type = target.GetType();
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var property in properties)
            {
                var attr = property.GetCustomAttribute<AutowiredAttribute>();
                if (attr == null) continue;
                var comp = go.GetComponent(property.PropertyType);
                if (comp != null)
                {
                    property.SetValue(target, comp);
                }
                else
                {
                    Debug.LogError($"无法加载类型为: {property.PropertyType}的组件");
                }
            }

            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                var attr = field.GetCustomAttribute<AutowiredAttribute>();
                if (attr == null) continue;
                var comp = go.GetComponent(field.FieldType);
                if (comp != null)
                {
                    field.SetValue(target, comp);
                }
                else
                {
                    Debug.LogError($"无法加载类型为: {field.FieldType}的组件");
                }
            }
        }
    }
}