using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomSearchingEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var btnEnterRoom = GameObject.Find("btnEnterRoom").GetComponent<Button>();
        btnEnterRoom.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Room");
        });

        var btnBackToMenu = GameObject.Find("btnBackToMenu").GetComponent<Button>();
        btnBackToMenu.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainMenu");
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
