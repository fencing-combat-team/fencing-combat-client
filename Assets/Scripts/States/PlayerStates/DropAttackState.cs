using Core;
using GamePlay.Player;
using UnityEngine;
using Utils;

namespace States.PlayerStates
{
    //跳劈
    public class DropAttackState : StateMachineBehaviour
    {
        [Autowired]
        private PlayerAttack _attack;
        [Autowired]
        private Rigidbody2D _rigidbody2D;
        
        [Tooltip("下落攻击力量")]
        [SerializeField]
        private float downForce = 2;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            this.InitComponents(animator);
            _rigidbody2D.velocity = new Vector2(0, -downForce);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _attack.DoDropAttack();
        }
    }
}