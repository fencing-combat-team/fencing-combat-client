using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Room_mes_PlayerMessageInOneRoom : MonoBehaviour
{
    private static UI_Room_mes_PlayerMessageInOneRoom instance;

    public PlayerMessage player1;
    public PlayerMessage player2;
    public PlayerMessage player3;
    public PlayerMessage player4;

    private UI_Room_mes_RoomSetting RoomSetting;

    public static UI_Room_mes_PlayerMessageInOneRoom Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UI_Room_mes_PlayerMessageInOneRoom();
            }
            return instance;
        }
    }
    private UI_Room_mes_PlayerMessageInOneRoom() { resetPlayerMessage(); }



    #region º¯Êý
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
