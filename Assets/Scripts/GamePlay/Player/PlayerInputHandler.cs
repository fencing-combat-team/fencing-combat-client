using System;
using Core;
using Enums;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;
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

        [Autowired]
        private PlayerDataManager _dataManager;

        private static readonly int Jump = Animator.StringToHash("jump");
        private static readonly int Move = Animator.StringToHash("move");
        private static readonly int Defending = Animator.StringToHash("defending");
        public float move { get; set; }
        public Vector2 direction { get; set; }
        public bool defending { get; set; }
        public bool attack { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            direction = Vector2.right;
            this.InitComponents();
        }

        // Update is called once per frame
        void Update()
        {
            var playerId = _dataManager.PlayerId;
            var provider = InputProvider.GetPlayerInput(playerId);
            //跳跃
            if (provider.GetKeyDown(FencingKey.Jump))
            {
                _animator.SetTrigger(Jump);
            }


            attack = provider.GetKeyDown(FencingKey.Attack);

            //移动
            move = provider.GetHorizontalAxis();
            _animator.SetFloat(Move, move);
            if (move != 0)
            {
                this.transform.localScale = new Vector3((int) move, 1);
                direction = new Vector2(move, 0);
            }

            //格挡
            defending = provider.GetKey(FencingKey.Defend);
            _animator.SetBool(Defending, defending);
        }
        
    }
}