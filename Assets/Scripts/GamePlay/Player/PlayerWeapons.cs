using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public GameObject hammer;
    public GameObject longsword;
    // Start is called before the first frame update
    void Start()
    {
        hammer = UnityEngine.Resources.Load<GameObject>("Prefabs/Weapon/hammer");
        longsword = UnityEngine.Resources.Load<GameObject>("Prefabs/Weapon/longSword");
        InitWeapon(new Vector2(-7, 4), 1);
        InitWeapon(new Vector2(7, 4), 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitWeapon(Vector2 position, int weaponId)
    {
        GameObject obj;
        switch (weaponId)
        {
            case 1:
                obj = Instantiate(longsword);
                obj.transform.position = position;
                break;
            case 2:
                obj = Instantiate(hammer);
                obj.transform.position = position;
                break;
            default:
                break;
        }
    }
}