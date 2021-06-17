using Core;
using UnityEngine;
using UnityEngine.Animations;
using Utils;

namespace States.PlayerStates
{
    public class FlightState : StateMachineBehaviour
    {
        [SerializeField]
        [Tooltip("空中移动速度")]
        private float speed = 2f;

        [Autowired]
        private Rigidbody2D _rigidbody2D;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            this.InitComponents(animator);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //移动
            float move = Input.GetAxis("Horizontal");
            _rigidbody2D.velocity = new Vector2(move * speed, _rigidbody2D.velocity.y);
        }
    }
}
