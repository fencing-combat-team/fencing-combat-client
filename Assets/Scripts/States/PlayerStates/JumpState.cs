using System.Collections;
using System.Collections.Generic;
using Core;
using GamePlay.Data;
using GamePlay.Player;
using UnityEngine;
using Utils;

public class JumpState : StateMachineBehaviour
{
    [Tooltip("跳跃力量")]
    [SerializeField]
    private float jumpForce = 100;

    [Autowired]
    private Rigidbody2D _rigidbody2D;

    [Autowired]
    private PlayerDataManager _dataManager;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.InitComponents(animator);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Jump();
    }

    void Jump()
    {
        var force = jumpForce + _dataManager.Properties.jumpInc;
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, force);
    }
}