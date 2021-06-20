using System;
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

        
        private static Component GetComponent(GameObject defaultGo, Type type, AutowiredAttribute attribute)
        {
            Component result;
            if (attribute.GameObject == null)
                result = defaultGo.GetComponent(type);
            else
            {
                var gameObject = GameObject.Find(attribute.GameObject);
                result = gameObject.GetComponent(type);
            }

            if (result == null)
            {
                Debug.LogError($"无法加载类型为: {type}的组件");
            }

            return result;
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
                var comp = GetComponent(go, property.PropertyType, attr);
                if (comp != null)
                    property.SetValue(target, comp);
            }

            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                var attr = field.GetCustomAttribute<AutowiredAttribute>();
                if (attr == null) continue;
                var comp = GetComponent(go, field.FieldType, attr);
                if (comp != null)
                    field.SetValue(target, comp);
            }
        }
    }
}