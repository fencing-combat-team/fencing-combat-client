using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core;
using Enums;
using GamePlay;
using GamePlay.Camera;
using GamePlay.Entity;
using GamePlay.Player;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerWeapons : WeakSingletonBehaviour<PlayerWeapons>
{
    public GameObject hammerPrefab;
    public GameObject longswordPrefab;

    public Map map;

    public void SwitchPlayerWeapon(GameObject player, WeaponTypeEnum weapon)
    {
        var playerAtttack = player.GetComponent<PlayerAttack>();
        if (!(playerAtttack._weapon is Sword))
        {
            _isSpawned[playerAtttack._weapon.Id] = false;
        }

        switch (weapon)
        {
            case WeaponTypeEnum.Sword:
                playerAtttack._weapon = new Sword();
                player.GetComponent<Animator>().runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("Animation/Player/Player");
                player.GetComponent<SpriteRenderer>().sprite =
                    Resources.Load<Sprite>("Player/Sword/idle");
                break;
            case WeaponTypeEnum.LongSword:
                playerAtttack._weapon = new LongSword();
                player.GetComponent<Animator>().runtimeAnimatorController =
                    Resources.Load<AnimatorOverrideController>("Animation/Player/LongSword");
                player.GetComponent<SpriteRenderer>().sprite =
                    Resources.Load<Sprite>("Player/LongSword/idle");
                break;
            case WeaponTypeEnum.Hammer:
                playerAtttack._weapon = new Hammer();
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

    public Dictionary<GameObject, Vector3> CurrentWeapon = new Dictionary<GameObject, Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Begin()
    {
        if (!_isBegin)
        {
            _isBegin = true;
            Random.InitState((int) DateTime.Now.Ticks);
        }
    }

    private bool _isBegin;

    public void Init()
    {
        _isBegin = false;
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

    private Vector3 FindSpawnPos(Vector3[] possible)
    {
        var remains = possible.Where(a => CurrentWeapon.Values.Any(b =>
            a.x - b.x + a.y - b.y < 0.1f)
        ).ToArray();
        if (remains.Length <= 0)
        {
            return possible[Random.Range(0, possible.Length)];
        }

        return remains[Random.Range(0, remains.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isBegin)
        {
            return;
        }

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

            if (weapon.appearBeginTime < _gameTime)
            {
                //������������
                var rand = Random.Range(0, 1);
                if (rand < weapon.spawnChance)
                {
                    var pos = FindSpawnPos(weapon.possibleSpawnPoints);

                    var obj = SpawnWeapon(pos, weapon.weaponId);

                    GameObject.Find("Main Camera").GetComponent<AutoCamera>().InspectPositons
                        .Add(pos);
                    _isSpawned[weapon.weaponId] = true;

                    CurrentWeapon.Add(obj, pos);
                    obj.AddComponent<DestroyListener>().Destroy += () => { CurrentWeapon.Remove(obj); };
                }
                else
                {
                    _spawnInterval[weapon.weaponId] = weapon.appearAttemptInterval;
                }
            }
        }
    }

    public GameObject SpawnWeapon(Vector2 position, WeaponTypeEnum weaponId)
    {
        GameObject obj = null;
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

        return obj;
    }
}