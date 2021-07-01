using Core;
using GamePlay.Player;
using UnityEngine;
using Utils;

namespace States.PlayerStates
{
    /// <summary>
    /// 静止不动的状态
    /// </summary>
    public class StillState : StateMachineBehaviour
    {
        [Autowired]
        private PlayerMovement _movement;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            this.InitComponents(animator);
            _movement.ChangeSpeed(0);
        }
    }
}