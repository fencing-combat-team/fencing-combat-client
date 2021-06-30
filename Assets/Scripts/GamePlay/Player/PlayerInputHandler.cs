using System;
using Core;
using Enums;
using Managers;
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

        [Autowired]
        private PlayerDataManager _dataManager;

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
            var playerId = _dataManager.playerId;


            //跳跃
            if (InputManager.Instance.GetKeyDown(playerId, FencingKey.Jump))
            {
                _animator.SetTrigger(Jump);
            }

            attack = InputManager.Instance.GetKeyDown(playerId, FencingKey.Attack);


            //移动
            move = InputManager.Instance.GetHorizontalAxis(playerId);
            _animator.SetFloat(Move, move);
            if (Mathf.Abs(move) > 0.01f) this.transform.localScale = new Vector3((int) move, 1);

            //格挡
            defending = InputManager.Instance.GetKey(playerId, FencingKey.Defend);
            _animator.SetBool(Defending, defending);
        }
    }
}