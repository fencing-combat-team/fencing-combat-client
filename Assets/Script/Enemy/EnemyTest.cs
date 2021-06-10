using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    public int health;
    public int enemyDamage;
    public GameObject bloodEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
            
        }
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
    } 
}
