using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 同步的更新方法
/// </summary>
public abstract class SyncBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void Start()
    {

    }

    public long DeltaTime { get; set; }
    public FrameInfo CurrentFrame { get; set; }

    /// <summary>
    /// 同步的更新方法
    /// </summary>
    public abstract void SyncUpdate();
}
