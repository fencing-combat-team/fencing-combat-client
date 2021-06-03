using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    private EventManager()
    {

    }
    public static EventManager Instance { get; private set; } = new EventManager();


    public event EventHandler ApplicationStart;
}
