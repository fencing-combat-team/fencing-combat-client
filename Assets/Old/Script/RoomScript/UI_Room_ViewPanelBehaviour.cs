using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//�������н��������Ļ�����

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
