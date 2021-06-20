using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Room_mes_PlayerMessageInOneRoom : MonoBehaviour
{
    private static UI_Room_mes_PlayerMessageInOneRoom instance;

    private PlayerMessage player1;
    private PlayerMessage player2;
    private PlayerMessage player3;
    private PlayerMessage player4;

    private UI_Room_mes_RoomSetting RoomSetting;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }

    #region ����
    public void resetPlayerMessage()
    {
        player1 = new PlayerMessage();
        player2 = new PlayerMessage();
        player3 = new PlayerMessage();
        player4 = new PlayerMessage();
    }

    public void reloadPlayerMessage(string playername1, string playername2, string playername3, string playername4)
    {
        player1 = new PlayerMessage(playername1);
        player2 = new PlayerMessage(playername2);
        player3 = new PlayerMessage(playername3);
        player4 = new PlayerMessage(playername4);
    }

    public void getscore(ScoreMessage sm)
    {
        player1.score += sm.playerScore1;
        player2.score += sm.playerScore2;
        player3.score += sm.playerScore3;
        player4.score += sm.playerScore4;
    }

    #endregion
}
