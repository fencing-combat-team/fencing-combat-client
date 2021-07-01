using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay.Data;
using UnityEngine.UI;
using GamePlay.Entity;
using GamePlay.Player;
using Managers;

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

        // Start is called before the first frame update
        void Start()
        {
            SetColor();
            PlayerInGameData.Instance.Reset += Load;
        }

        private void Load()
        {
            
            for (int i = 0; i < playerimages.Length; i++)
            {
                playerimages[i].GetComponent<CanvasGroup>().alpha =
                    i <  PlayerInGameData.Instance.Properties.Length ? 1 : 0;
            }
        }

        private void OnDestroy()
        {
            PlayerInGameData.Instance.Reset -= Load;
            
        }

        void Update()
        {
            foreach (var playerProp in PlayerInGameData.Instance.Properties)
            {
                if (playerProp.life < 0)
                {
                    playerchecks[playerProp.playerId - 1].color = new Color(1, 1, 1, 1);
                }
                else
                {
                    playerchecks[playerProp.playerId - 1].color = new Color(1, 1, 1, 0);
                }

                playerlives[playerProp.playerId - 1].text =
                    playerProp.life.ToString();
            }
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