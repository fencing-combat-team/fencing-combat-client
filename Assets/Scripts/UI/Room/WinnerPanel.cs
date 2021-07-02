using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay.Data;
using UnityEngine.UI;
using GamePlay.Entity;
using GamePlay.Player;
using Managers;
using UI.Data;

public class WinnerPanel : ViewPanelBehaviourBase
{
    public PlayerRoomData roomData;
    public PlayerColors playerColors;
    public RoomSetting setting;

    public Image[] playerimages;
    public Text winnerName;

    private PlayerData[] playerDatas;

    #region
    public void ExitButtonClick()
    {
        this.Hide();
    }

    private void SortPlaeyrDataByScore()
    {
        for(int i= 0; i < 3; i++)
        {
            int max = 1;
            for(int j = i + 1; j < 4; j++)
            {
                if (playerDatas[j].score > playerDatas[max].score)
                {
                    max = j;
                }
            }
            if(max != i)
            {
                PlayerData temp = playerDatas[max];
                playerDatas[max] = playerDatas[i];
                playerDatas[i] = temp;
            }
        }
    }
    private void SetColor()
    {
        Color color1 = playerColors[playerDatas[0].playerColor];
        playerimages[0].color = color1;
        Color color2 = playerColors[playerDatas[1].playerColor];
        playerimages[1].color = color2;
        Color color3 = playerColors[playerDatas[2].playerColor];
        playerimages[2].color = color3;
        Color color4 = playerColors[playerDatas[3].playerColor];
        playerimages[3].color = color4;
    }

    private void SetSetting()
    {
        switch (setting.playerNumbers)
        {
            case 4:
                break;
            case 3:
                playerimages[3].color = new Color(1, 1, 1, 0);
                break;
            case 2:
                playerimages[3].color = new Color(1, 1, 1, 0);
                playerimages[2].color = new Color(1, 1, 1, 0);
                break;
            default:
                break;
        }
    }

    public void GetWinner()
    {
        playerDatas = roomData.players;
        SortPlaeyrDataByScore();
        SetColor();
        SetSetting();
        winnerName.text = playerDatas[0].playerName;
    }
    #endregion

}
