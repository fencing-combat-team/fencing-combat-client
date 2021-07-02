using Core;
using GamePlay.Data;
using GamePlay.Player;
using UnityEngine;
using UnityEngine.Animations;
using Utils;

namespace States.PlayerStates
{
    public class IdleState : StateMachineBehaviour
    {
        [SerializeField]
        [Tooltip("地面移动速度")]
        private float speed = 5f;

        [Autowired]
        private PlayerMovement _movement;
        [Autowired]
        private PlayerInputHandler _input;
        [Autowired]
        private PlayerDataManager _dataManager;

        private static readonly int Jump = Animator.StringToHash("jump");
        private static readonly int Attack = Animator.StringToHash("attack");
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            this.InitComponents(animator);
            
            animator.ResetTrigger(Jump);
            animator.ResetTrigger(Attack);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            
            var speedNew = speed + _dataManager.Properties.speedInc;
            float move = _input.move;
            _movement.ChangeSpeed(move * speedNew);
        }
    }
}