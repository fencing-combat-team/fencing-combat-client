using Core;
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

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            this.InitComponents(animator);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            float move = Input.GetAxis("Horizontal1");
            _movement.ChangeSpeed(move * speed);
        }
    }
}