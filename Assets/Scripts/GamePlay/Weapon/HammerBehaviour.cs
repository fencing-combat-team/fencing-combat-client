using System.Collections;
using System.Collections.Generic;
using Enums;
using GamePlay.Camera;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerWeapons.Instance.SwitchPlayerWeapon(collision.gameObject, WeaponTypeEnum.Hammer, false);
        Destroy(this.gameObject);
    }
}