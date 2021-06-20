using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//这是所有界面控制类的基础类

public class UI_Room_ViewPanelBehaviour : MonoBehaviour
{
    public void Show()
    {
        transform.gameObject.SetActive(true);
    }

    public void Hide()
    {
        transform.gameObject.SetActive(false);
    }
}
