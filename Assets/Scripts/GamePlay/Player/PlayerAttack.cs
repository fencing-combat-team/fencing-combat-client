using System.Collections.Generic;
using Core;
using Resources.Weapons;
using UnityEngine;
using Utils;

namespace GamePlay.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [Autowired]
        private Animator _animator;

        private static readonly int Attack = Animator.StringToHash("attack");

        [SerializeField]
        [Tooltip("ÎäÆ÷")]
        private Weapon _weapon;

        private bool attack;
        private float _attackCooldown = 0;

        // Start is called before the first frame update
        void Start()
        {
            this.InitComponents();
        }

        // Update is called once per frame
        void Update()
        {
            attack = this.gameObject.GetComponent<PlayerInputHandler>().attack;

            //¹¥»÷
            if (_attackCooldown > 0)
            {
                _attackCooldown -= Time.deltaTime;
            }
            else if (attack)
            {
                _animator.SetTrigger(Attack);
                _attackCooldown = 1000f / _weapon.AttackFeq;
            }
        }

        public void DoAttack()
        {
            
        }
    }
}