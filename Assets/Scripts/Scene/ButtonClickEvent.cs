using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClickEvent: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var btnStart = GameObject.Find("btnStart").GetComponent<Button>();
        btnStart.onClick.AddListener(() =>
        {
            //Debug.Log("");
            SceneManager.LoadScene("RoomSearching");
        });

        var btnQuit = GameObject.Find("btnQuit").GetComponent<Button>();
        btnQuit.onClick.AddListener(() =>
        {
            //Debug.Log("");
            //
        });

        var btnEnterRoom = GameObject.Find("btnEnterRoom").GetComponent<Button>();
        btnEnterRoom.onClick.AddListener(() =>
        {
            //Debug.Log("");
            SceneManager.LoadScene("Combat");
        });

        var btnBackToMenu = GameObject.Find("btnBackToMenu").GetComponent<Button>();
        btnBackToMenu.onClick.AddListener(() =>
        {
            //Debug.Log("");
            SceneManager.LoadScene("MainMenu");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
