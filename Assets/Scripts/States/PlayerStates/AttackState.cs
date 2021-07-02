using Core;
using GamePlay.Player;
using UnityEngine;
using Utils;
using System.Collections;
using GamePlay.Entity;

namespace States.PlayerStates
{
    public class AttackState : StateMachineBehaviour
    {
        [Autowired]
        private PlayerAttack _attack;


        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            this.InitComponents(animator);
            _attack.DoAttack();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {

        }





    }
}