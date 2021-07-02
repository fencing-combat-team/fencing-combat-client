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
        public Weapon _weapon;
        
        private Sword _sword=new Sword();
        private LongSword _longSword = new LongSword();
        private Hammer _hammer = new Hammer();

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
                _attackCooldown = 1000f / _longSword.AttackFeq;
            }
        }

        public void DoAttack()
        {
            Vector2 direction = gameObject.GetComponent<PlayerInputHandler>().direction;
            _hammer.Attack(gameObject.transform.position, direction).
                FindAll(g => g != this.gameObject ).ForEach(g =>
                {
                    if (g.GetComponent<PlayerAttack>()._hammer.NoDefending)
                        g.GetComponent<PlayerHealth>().Die();
                    else if(!g.GetComponent<PlayerInputHandler>().defending || 
                    g.GetComponent<PlayerInputHandler>().direction ==this.gameObject.GetComponent<PlayerInputHandler>().direction)
                        g.GetComponent<PlayerHealth>().Die();
                    else
                    {
                        g.GetComponent<PlayerMovement>().ChangeSpeed
                           (direction.x * (_hammer.AttackDistance+1f - Mathf.Abs(g.transform.position.x - this.transform.position.x)) * _hammer.ImpactingForce);
                        StartCoroutine(Slide(g));
                    }
                        
                });
            Ray2D ray = new Ray2D((Vector2)(transform.position) + direction * 0.6f + Vector2.down * 0.5f - direction * 2f, direction);
            StartCoroutine(ShowAttackRay(ray));

        }

        public void DoDropAttack()
        {
            Vector2 direction = gameObject.GetComponent<PlayerInputHandler>().direction;
            _hammer.DropAttack(gameObject.transform.position, direction).
                FindAll(g => g != this.gameObject).ForEach(g =>
                {
                    if (g.GetComponent<PlayerAttack>()._hammer.NoDefending)
                        g.GetComponent<PlayerHealth>().Die();
                    else if(!g.GetComponent<PlayerInputHandler>().defending ||
                    g.GetComponent<PlayerInputHandler>().direction == this.gameObject.GetComponent<PlayerInputHandler>().direction)
                        g.GetComponent<PlayerHealth>().Die();
                    else
                    {
                        g.GetComponent<PlayerMovement>().ChangeSpeed
                        (direction.x * (_hammer.AttackDistance + 1f - Mathf.Abs(g.transform.position.x - this.transform.position.x)) * _hammer.ImpactingForce);
                        StartCoroutine(Slide(g));

                    }

                });

        }

        public void DoDropDownAttack()
        {
            Vector2 direction = gameObject.GetComponent<PlayerInputHandler>().direction;
            _hammer.DropDownAttack(gameObject.transform.position, direction).
                FindAll(g => g != this.gameObject).ForEach(g =>
                {
                    if (g.GetComponent<PlayerAttack>()._hammer.NoDefending)
                        g.GetComponent<PlayerHealth>().Die();
                    else if (!g.GetComponent<PlayerInputHandler>().defending ||
                    g.GetComponent<PlayerInputHandler>().direction == this.gameObject.GetComponent<PlayerInputHandler>().direction)
                        g.GetComponent<PlayerHealth>().Die();
                    else
                    {
                        g.GetComponent<PlayerMovement>().ChangeSpeed
                        (direction.x * (_hammer.AttackDistance + 1f - Mathf.Abs(g.transform.position.x - this.transform.position.x)) * _hammer.ImpactingForce);
                        StartCoroutine(Slide(g));

                    }

                });

            Ray2D ray = new Ray2D((Vector2)transform.position + direction * -0.3f + Vector2.down * 0.5f, Vector2.right);
            StartCoroutine(ShowAttackRay(ray));

        }


        IEnumerator Slide(GameObject gameObject)
        {

            yield return new WaitForSeconds(0.5f);
            gameObject.GetComponent<PlayerMovement>().ChangeSpeed(0);
        }

        IEnumerator ShowAttackRay(Ray2D ray)
        {
            for(int i=0;i<60;i++)
            {
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * 2f, Color.red);
                yield return null;
        }

        }

    }
}