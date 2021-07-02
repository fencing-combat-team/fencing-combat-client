using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay.Player;
using GamePlay.Entity;

public class HammerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 StartPoint;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Sprite spriteB = Resources.Load<Sprite>("Player/Hammer/idle");
        collision.gameObject.GetComponent<SpriteRenderer>().sprite = spriteB;
        Debug.Log(spriteB.name);
        collision.gameObject.GetComponent<PlayerAttack>()._weapon = new Hammer();
        Destroy(this.gameObject);
    }
}
