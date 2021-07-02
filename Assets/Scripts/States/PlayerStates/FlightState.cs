using Core;
using GamePlay.Data;
using GamePlay.Player;
using UnityEngine;
using UnityEngine.Animations;
using Utils;

namespace States.PlayerStates
{
    public class FlightState : StateMachineBehaviour
    {
        [SerializeField]
        [Tooltip("空中移动速度")]
        private float speed = 3f;

        [Autowired]
        private PlayerMovement _movement;
        [Autowired]
        private PlayerInputHandler _input;
        [Autowired]
        private PlayerDataManager _dataManager;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            this.InitComponents(animator);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            
            var speedNew = speed + _dataManager.Properties.speedInc / 2.0f;
            //移动
            float move = _input.move;
            _movement.ChangeSpeed(move * speedNew);
        }
    }
}