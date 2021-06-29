using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using Utils;

public class PlayerTag : MonoBehaviour
{
    [Autowired(GameObject = "Main Camera")]
    private AutoCamera _autoCamera;
    private void Awake()
    {
        this.InitComponents();
    }

    private void OnEnable()
    {
        _autoCamera.AddPlayerTag(this);
    }

    private void OnDisable()
    {
        _autoCamera.RemovePlayerTag(this);
    }

}
