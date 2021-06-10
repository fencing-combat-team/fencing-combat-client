using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    //实现具体的攻击动作，当点击鼠标左键时触发动画以及造成伤害；被攻击者的内容写在（enemy）的script中；并且用两个IEnumerator来决定攻击实际的开始时间和结束时间（前摇，后腰）
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
