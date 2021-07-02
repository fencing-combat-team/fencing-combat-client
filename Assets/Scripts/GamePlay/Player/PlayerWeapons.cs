using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Enums;
using GamePlay.Entity;
using GamePlay.Player;
using UnityEditor.Animations;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerWeapons : WeakSingletonBehaviour<PlayerWeapons>
{
    public GameObject hammerPrefab;
    public GameObject longswordPrefab;

    public Map map;

    public void SwitchPlayerWeapon(GameObject player, WeaponTypeEnum weapon)
    {
        switch (weapon)
        {
            case WeaponTypeEnum.Sword:
                player.GetComponent<PlayerAttack>()._weapon = new Sword();
                player.GetComponent<Animator>().runtimeAnimatorController =
                    Resources.Load<AnimatorController>("Animation/Player/Player");
                player.GetComponent<SpriteRenderer>().sprite =
                    Resources.Load<Sprite>("Player/Sword/idle");
                break;
            case WeaponTypeEnum.LongSword:
                player.GetComponent<PlayerAttack>()._weapon = new LongSword();
                player.GetComponent<Animator>().runtimeAnimatorController =
                    Resources.Load<AnimatorOverrideController>("Animation/Player/LongSword");
                player.GetComponent<SpriteRenderer>().sprite =
                    Resources.Load<Sprite>("Player/LongSword/idle");
                break;
            case WeaponTypeEnum.Hammer:
                player.GetComponent<PlayerAttack>()._weapon = new Hammer();
                player.GetComponent<Animator>().runtimeAnimatorController =
                    Resources.Load<AnimatorOverrideController>("Animation/Player/Hammer");
                player.GetComponent<SpriteRenderer>().sprite =
                    Resources.Load<Sprite>("Player/Hammer/idle");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(weapon), weapon, null);
        }
    }

    private float _gameTime;
    private Dictionary<WeaponTypeEnum, float> _spawnInterval;
    private Dictionary<WeaponTypeEnum, bool> _isSpawned;

    // Start is called before the first frame update
    void Start()
    {
        _gameTime = 0;
        _spawnInterval = new Dictionary<WeaponTypeEnum, float>()
        {
            {WeaponTypeEnum.Hammer, 0},
            {WeaponTypeEnum.LongSword, 0}
        };
        _isSpawned = new Dictionary<WeaponTypeEnum, bool>()
        {
            {WeaponTypeEnum.Hammer, false},
            {WeaponTypeEnum.LongSword, false}
        };
    }

    // Update is called once per frame
    void Update()
    {
        _gameTime += Time.deltaTime;
        foreach (var weapon in map.weapons)
        {
            if (_isSpawned[weapon.weaponId])
            {
                continue;
            }

            if (_spawnInterval[weapon.weaponId] > 0)
            {
                _spawnInterval[weapon.weaponId] -= Time.deltaTime;
                continue;
            }

            if (weapon.appearBeginTime > _gameTime)
            {
                //������������
                var rand = Random.Range(0, 1);
                if (rand < weapon.spawnChance)
                {
                    var pos = weapon.possibleSpawnPoints[Random.Range(0, weapon.possibleSpawnPoints.Length)];
                    SpawnWeapon(pos, weapon.weaponId);
                }
                else
                {
                    _spawnInterval[weapon.weaponId] = weapon.appearAttemptInterval;
                }
            }
        }
    }

    public void SpawnWeapon(Vector2 position, WeaponTypeEnum weaponId)
    {
        GameObject obj;
        switch (weaponId)
        {
            case WeaponTypeEnum.LongSword:
                obj = Instantiate(longswordPrefab);
                obj.transform.position = position;
                break;
            case WeaponTypeEnum.Hammer:
                obj = Instantiate(hammerPrefab);
                obj.transform.position = position;
                break;
            default:
                break;
        }
    }
}