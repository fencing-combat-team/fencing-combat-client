using System.Collections;
using UnityEngine;

namespace Old.Script.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        public int playerDamage;
        public float timeStart, timeEnd;
        private Animator anim;
        private PolygonCollider2D poly;
        public int damage = 5;

        // Start is called before the first frame update
        void Start()
        {
            anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
            poly = GetComponent<PolygonCollider2D>();
        }

        // Update is called once per frame
        void Update()
        {
            Attack();
        }
        //ʵ�־���Ĺ��������������������ʱ���������Լ�����˺����������ߵ�����д�ڣ�enemy����script�У�����������IEnumerator����������ʵ�ʵĿ�ʼʱ��ͽ���ʱ�䣨ǰҡ��������
        void Attack()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("attack");
                StartCoroutine(StartAttack());
                StartCoroutine(DisableHitbox());
            }
            

        }

        IEnumerator StartAttack()
        {
            yield return new WaitForSeconds(timeStart);
            poly.enabled = true;
            StartCoroutine(DisableHitbox());

        }
        IEnumerator DisableHitbox()
        {
            yield return new WaitForSeconds(timeEnd);
            poly.enabled = false;

        }

    

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.SendMessage("TakeDamage", damage);
            }
        }
    }
}
