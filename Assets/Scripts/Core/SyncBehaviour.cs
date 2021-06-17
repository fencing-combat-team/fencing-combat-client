using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

/// <summary>
/// 同步的更新方法
/// </summary>
public abstract class SyncBehaviour : MonoBehaviour
{
    public virtual void Start()
    {
        GameManager.Instance.AddSyncBehaviour(this);

        //自动GetComponent
        var type = GetType();
        var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (var property in properties)
        {
            var attr = property.GetCustomAttribute<AutowiredAttribute>();
            if (attr != null)
            {
                var comp = GetComponent(property.PropertyType);
                if (comp != null)
                {
                    property.SetValue(this, comp);
                }
                else
                {
                    Debug.LogError($"无法加载类型为: {property.PropertyType}的组件");
                }
            }
        }

        var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (var field in fields)
        {
            var attr = field.GetCustomAttribute<AutowiredAttribute>();
            if (attr != null)
            {
                var comp = GetComponent(field.FieldType);
                if (comp != null)
                {
                    field.SetValue(this, comp);
                }
                else
                {
                    Debug.LogError($"无法加载类型为: {field.FieldType}的组件");
                }
            }
        }
    }

    public long DeltaTime { get; set; }
    public FrameInfo CurrentFrame { get; set; }

    /// <summary>
    /// 同步的更新方法
    /// </summary>
    public abstract void SyncUpdate();
}
