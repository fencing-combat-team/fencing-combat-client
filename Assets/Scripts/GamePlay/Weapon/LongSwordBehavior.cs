using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay.Player;
using GamePlay.Entity;

public class LongSwordBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<PlayerAttack>()._weapon = new LongSword();
        Sprite spriteB = Resources.Load<Sprite>("Player/LongSword/idle");
        collision.gameObject.GetComponent<SpriteRenderer>().sprite = spriteB;
        Destroy(this.gameObject);
    }
}
