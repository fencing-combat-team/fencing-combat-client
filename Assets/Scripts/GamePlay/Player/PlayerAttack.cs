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
        [Autowired]
        private PlayerInputHandler _input;

        [Autowired]
        private Rigidbody2D _rigidbody2D;

        private static readonly int Attack = Animator.StringToHash("attack");

        [SerializeField]
        [Tooltip("����")]
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
            attack = _input.attack;

            //����
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
            float move = gameObject.GetComponent<PlayerInputHandler>().move;
            Vector2 direction = new Vector2((int)move / Mathf.Abs(move), 0);
            _weapon = ScriptableObject.CreateInstance<Sword>();
            _weapon.Attack(gameObject.transform.position, direction);

        }
    }
}