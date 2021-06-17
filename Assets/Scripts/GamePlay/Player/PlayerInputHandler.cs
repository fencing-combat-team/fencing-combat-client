using System;
using Core;
using UnityEngine;
using Utils;

namespace GamePlay.Player
{
    /// <summary>
    /// 玩家输入控制器（仅处理事件和动画）
    /// </summary>
    public class PlayerInputHandler : MonoBehaviour
    {
        [Autowired] private Animator _animator;

        private static readonly int Jump = Animator.StringToHash("jump");
        private static readonly int Move = Animator.StringToHash("move");
        private static readonly int Attack = Animator.StringToHash("attack");
        private static readonly int Defending = Animator.StringToHash("defending");

        // Start is called before the first frame update
        void Start()
        {
            this.InitComponents();
        }

        // Update is called once per frame
        void Update()
        {
            //跳跃
            if (Input.GetButtonDown("Jump"))
            {
                _animator.SetTrigger(Jump);
            }

            //移动
            var move = Input.GetAxisRaw("Horizontal");
            _animator.SetFloat(Move, move);
            if (Mathf.Abs(move) > 0.01f) this.transform.localScale = new Vector3((int) move, 1);


            //攻击
            if (Input.GetButtonDown("Fire1"))
            {
                _animator.SetTrigger(Attack);
            }

            //格挡
            var defending = Input.GetButton("Fire2");
            _animator.SetBool(Defending, defending);
        }
    }
}