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
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            this.InitComponents(animator);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _attack.DoAttack();
        }
    }
}