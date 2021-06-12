using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMessage 
{
    #region ±äÁ¿
    public string name;
    public int score;
    //image headphoto  Í·Ïñ£¬Í¼Æ¬

    #endregion

    public PlayerMessage()
    {
        name = "None Player";
        score = 0;
    }

    public PlayerMessage(string name)
    {
        this.name = name;
        score = 0;
    }
}
