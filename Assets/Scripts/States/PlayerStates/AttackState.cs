using System.Collections;
using Core;
using GamePlay.Entity;
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
            switch (_attack._weapon)
            {
                case Sword _:
                    _attack.AttackAfter(0.1f);
                    break;
                case LongSword _:
                    _attack.AttackAfter(0.2f);
                    break;
            }
        }

        

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_attack._weapon is Hammer)
            {
                _attack.DoAttack();
            }
        }
    }
}