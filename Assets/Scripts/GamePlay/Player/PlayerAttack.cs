using System.Collections;
using System.Collections.Generic;
using Core;
using GamePlay.Entity;
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
        public Weapon _weapon = new Sword();


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

        public void AttackAfter(float time)
        {
            StartCoroutine(AttackAfterInternal(time));
        }
        private IEnumerator AttackAfterInternal(float time)
        {
            yield return new WaitForSeconds(time);
            DoAttack();
        }

        public void DoAttack()
        {
            Vector2 direction = gameObject.GetComponent<PlayerInputHandler>().direction;
            StartCoroutine(DelayAttack());
            Ray2D ray = new Ray2D((Vector2)transform.position + direction * 1.2f + Vector2.down * 0.5f - direction * 1.1f, direction);
            Ray2D ray1 = new Ray2D((Vector2)transform.position + direction * 1.2f + Vector2.down * 0.5f , Vector2.up);
            StartCoroutine(ShowAttackRay(ray));
            StartCoroutine(ShowAttackRay(ray1));


        }

        IEnumerator DelayAttack()
        {
            yield return new WaitForSeconds(_weapon.delay);
            Vector2 direction = gameObject.GetComponent<PlayerInputHandler>().direction;
            _weapon.Attack(gameObject.transform.position, direction).
                FindAll(g => g != this.gameObject).ForEach(g =>
                {
                    if (g.GetComponent<PlayerAttack>()._weapon.NoDefending)
                        g.GetComponent<PlayerHealth>().Die();
                    else if (!g.GetComponent<PlayerInputHandler>().defending ||
                    g.GetComponent<PlayerInputHandler>().direction == this.gameObject.GetComponent<PlayerInputHandler>().direction)
                        g.GetComponent<PlayerHealth>().Die();
                    else
                    {
                        g.GetComponent<PlayerMovement>().ChangeSpeed
                           (direction.x * (_weapon.AttackDistance + 1f - Mathf.Abs(g.transform.position.x - this.transform.position.x)) * _weapon.ImpactingForce);
                        StartCoroutine(Slide(g));
                    }

                });
        }

        public void DoDropAttack()
        {
            Vector2 direction = gameObject.GetComponent<PlayerInputHandler>().direction;
             _weapon.DropAttack(gameObject.transform.position, direction).FindAll(g => g != this.gameObject).ForEach(g =>
                {
                    if (g.GetComponent<PlayerAttack>()._weapon.NoDefending)
                        g.GetComponent<PlayerHealth>().Die();
                    else if(!g.GetComponent<PlayerInputHandler>().defending ||
                    g.GetComponent<PlayerInputHandler>().direction == this.gameObject.GetComponent<PlayerInputHandler>().direction || _weapon.BreakDefending)
                        g.GetComponent<PlayerHealth>().Die();
                    else
                    {
                        g.GetComponent<PlayerMovement>().ChangeSpeed
                        (direction.x * (_weapon.AttackDistance + 1f - Mathf.Abs(g.transform.position.x - this.transform.position.x)) * _weapon.ImpactingForce);
                        StartCoroutine(Slide(g));

                    }

                });

        }

        public void DoDropDownAttack()
        {
            Vector2 direction = gameObject.GetComponent<PlayerInputHandler>().direction;
            _weapon.DropDownAttack(gameObject.transform.position, direction).FindAll(g => g != this.gameObject).ForEach(
                g =>
                {
                    if (g.GetComponent<PlayerAttack>()._weapon.NoDefending)
                        g.GetComponent<PlayerHealth>().Die();
                    else if (!g.GetComponent<PlayerInputHandler>().defending ||
                             g.GetComponent<PlayerInputHandler>().direction ==
                             this.gameObject.GetComponent<PlayerInputHandler>().direction)
                        g.GetComponent<PlayerHealth>().Die();
                    else
                    {
                        g.GetComponent<PlayerMovement>().ChangeSpeed
                        (direction.x *
                         (_weapon.AttackDistance + 1f - Mathf.Abs(g.transform.position.x - this.transform.position.x)) *
                         _weapon.ImpactingForce);
                        StartCoroutine(Slide(g));
                    }


                });
            Ray2D ray = new Ray2D((Vector2)transform.position + direction * 0.87f + Vector2.down * 1.3f - 2f / 3f * 1.1f * direction, direction);
            StartCoroutine(ShowAttackRay(ray));
        }


        IEnumerator Slide(GameObject gameObject)
        {
            yield return new WaitForSeconds(0.5f);
            gameObject.GetComponent<PlayerMovement>().ChangeSpeed(0);
        }

        IEnumerator ShowAttackRay(Ray2D ray)
        {
            for(int i=0;i<400;i++)
            {
                Debug.DrawLine(ray.origin, ray.origin + 2f / 3f * ray.direction * 2.2f, Color.red);
                yield return null;
            }
        }
    }
}