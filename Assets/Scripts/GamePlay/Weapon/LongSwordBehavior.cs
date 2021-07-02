using System.Collections;
using System.Collections.Generic;
using Enums;
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
        PlayerWeapons.Instance.SwitchPlayerWeapon(collision.gameObject, WeaponTypeEnum.LongSword);
        Destroy(this.gameObject);
    }
}
