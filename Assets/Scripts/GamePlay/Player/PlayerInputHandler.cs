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
        [Autowired]
        private Animator _animator;

        private static readonly int Jump = Animator.StringToHash("jump");
        private static readonly int Move = Animator.StringToHash("move");
        private static readonly int Defending = Animator.StringToHash("defending");
        public float move { get; set; }
        public bool defending { get; set; }
        public bool attack { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            this.InitComponents();
        }

        // Update is called once per frame
        void Update()
        {
            GameObject gameObject = this.gameObject;
            string name = gameObject.name;
            switch (name)
            {
                case "Player1":
                    //跳跃
                    if (Input.GetButtonDown("Jump1"))
                    {
                        _animator.SetTrigger(Jump);
                    }


                    attack = Input.GetButtonDown("Attack1");

                    //移动
                    move = Input.GetAxisRaw("Horizontal1");
                    _animator.SetFloat(Move, move);
                    if (Mathf.Abs(move) > 0.01f) this.transform.localScale = new Vector3((int)move, 1);

                    //格挡
                    defending = Input.GetButton("Block1");
                    _animator.SetBool(Defending, defending);
                    break;

                case "Player2":
                    //跳跃
                    if (Input.GetButtonDown("Jump2"))
                    {
                        _animator.SetTrigger(Jump);
                    }


                    attack = Input.GetButtonDown("Attack2");

                    //移动
                    move = Input.GetAxisRaw("Horizontal2");
                    _animator.SetFloat(Move, move);
                    if (Mathf.Abs(move) > 0.01f) this.transform.localScale = new Vector3((int)move, 1);

                    //格挡
                    defending = Input.GetButton("Block2");
                    _animator.SetBool(Defending, defending);
                    break;
            }
        }
    }
}