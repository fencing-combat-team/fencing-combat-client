using UnityEngine;
using UnityEngine.Animations;
using Utils;

namespace States.PlayerStates
{
    public class IdleState : StateMachineBehaviour
    {
        public float speed = 5f;

        [Autowired]
        private Rigidbody2D _rigidbody2D;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            this.InitComponents(animator);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);
            float move = Input.GetAxis("Horizontal");
            _rigidbody2D.velocity = new Vector2(move * speed, _rigidbody2D.velocity.y);
        }
    }
}