using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public long DeltaTime { get; set; } = 100;
    public Queue<FrameInfo> PendingFrames { get; set; } = new Queue<FrameInfo>();

    public bool IsSimulate { get; set; }

    private object _lock = new object();
    private float _lastUpdate = 0;
    private List<SyncBehaviour> _syncBehaviours = new List<SyncBehaviour>();

    

    void Update()
    {
        //´¦ÀíÍøÂç°ü
        //NetworkManager.Instance.ReceivedMessages;
        _lastUpdate += Time.deltaTime;
        if (!IsSimulate && _lastUpdate < DeltaTime)
        {
            return;
        }
        _lastUpdate = 0;

        foreach (var behaviour in _syncBehaviours)
        {
            behaviour.SyncUpdate();
        }

    }

    public void AddSyncBehaviour(SyncBehaviour behaviour)
    {
        lock (_lock)
        {
            _syncBehaviours.Add(behaviour);
        }
    }
}
