using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Room_mes_RoomSetting
{
    private static UI_Room_mes_RoomSetting instance;

    public static UI_Room_mes_RoomSetting Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UI_Room_mes_RoomSetting();
            }
            return instance;
        }
    }


    public int roundNums = 1;
    public int LivesNum = 3;
    public int PlayerNum = 4;
    public float recovertime = 0;
}
