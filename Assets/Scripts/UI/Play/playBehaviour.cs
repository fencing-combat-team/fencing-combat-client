using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay.Data;
using UnityEngine.UI;
using GamePlay.Entity;
using GamePlay.Player;
using Managers;
using GamePlay.Buff;
using UnityEditor;

namespace UI.Play
{
    public class playBehaviour : MonoBehaviour
    {
        public Image[] playerimages;
        public Image[] playerchecks;
        public Text[] playerlives;

        private GameObject[] players;
        private bool PlayerNumsetted;

        public PlayerColors colors;
        public PlayerRoomData roomData;

        public GameObject buffStackPrefab;
        public Vector3[] buffStackPos;
        private List<GameObject> buffStackList;
        private Dictionary<int, int> buffCountEachPlayer; // 每个玩家的buff数，键为玩家id，值为buff数

        private void Awake()
        {
            Load();
        }

        // Start is called before the first frame update
        void Start()
        {
            SetColor();
        }

        private void Load()
        {
            for (int i = 0; i < playerimages.Length; i++)
            {
                playerimages[i].GetComponent<CanvasGroup>().alpha =
                    i < PlayerInGameData.Instance.Properties.Length ? 1 : 0;
            }

            buffCountEachPlayer = new Dictionary<int, int>();
            buffStackList = new List<GameObject>();
            for (int i = 0; i < PlayerInGameData.Instance.Properties.Length; i++)
            {
                buffCountEachPlayer.Add(i, 0);
                var info = PrefabUtility.InstantiatePrefab(buffStackPrefab) as GameObject;
                info.transform.SetParent(this.transform);
                info.transform.position = buffStackPos[i];
                info.name = "BuffStack" + (i + 1);
                buffStackList.Add(info);
            }
        }

        void Update()
        {
            foreach (var playerProp in PlayerInGameData.Instance.Properties)
            {
                if (playerProp.life <= 0)
                {
                    playerchecks[playerProp.playerId - 1].color = new Color(1, 1, 1, 1);
                    playerlives[playerProp.playerId - 1].text = "";
                }
                else
                {
                    playerchecks[playerProp.playerId - 1].color = new Color(1, 1, 1, 0);
                    if (playerProp.shield > 0)
                    {
                        playerlives[playerProp.playerId - 1].text =
                            $"{playerProp.life.ToString()}({playerProp.shield})";
                    }
                    else
                    {
                        playerlives[playerProp.playerId - 1].text =
                            playerProp.life.ToString();
                    }
                }
            }
        }

        public void SetBuffInfo(int playerId, Buff buff)
        {
            var info = buffStackList[playerId - 1];
            var stack = info.GetComponent<BuffStackBehaviour>();

            stack.SetBuffInfo(playerId, buff);

            buffCountEachPlayer[playerId - 1]++;
        }

        public void RemoveInfo(int playerId, Buff buff)
        {
            buffStackList[playerId - 1].GetComponent<BuffStackBehaviour>().RemoveInfo(playerId, buff);
            buffCountEachPlayer[playerId - 1]--;
        }

        #region

        private void SetColor()
        {
            Color color1 = colors[roomData.players[0].playerColor];
            color1.a = 100;
            playerimages[0].color = color1;
            Color color2 = colors[roomData.players[1].playerColor];
            color2.a = 100;
            playerimages[1].color = color2;
            Color color3 = colors[roomData.players[2].playerColor];
            color3.a = 100;
            playerimages[2].color = color3;
            Color color4 = colors[roomData.players[3].playerColor];
            color4.a = 100;
            playerimages[3].color = color4;
        }


        private GameObject[] FindAllPlayers()
        {
            GameObject[] Currentplayers = GameObject.FindGameObjectsWithTag("Player");
            Debug.Log(Currentplayers.Length);
            return Currentplayers;


            /*
            object[] playerInput = FindObjectsOfType<PlayerInputHandler>();
            Debug.Log(playerInput.Length);
            GameObject[] Currentplayers = new GameObject[playerInput.Length];
            for(int i= 0; i < Currentplayers.Length; i++)
            {
                if(playerInput[i] is PlayerInputHandler)
                {
                    Currentplayers[i] = (playerInput[i] as PlayerInputHandler).gameObject;
                    Debug.Log(Currentplayers[i].name);
                }
                else
                {
                    Debug.Log("Can't Find Player");
                    return null;
                }
            }
            return Currentplayers;
            */
        }

        #endregion
    }
}