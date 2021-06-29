using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using Utils;

public class JumpState : StateMachineBehaviour
{
    [Tooltip("跳跃力量")]
    [SerializeField]
    private float jumpForce = 100;

    [Autowired] private Rigidbody2D _rigidbody2D;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.InitComponents(animator);
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
    }
}