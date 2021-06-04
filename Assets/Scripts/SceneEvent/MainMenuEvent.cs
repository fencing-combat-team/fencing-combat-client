using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuEvent: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        var btnStart = GameObject.Find("btnStart").GetComponent<Button>();
        btnStart.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("RoomSearching");
        });

        var btnQuit = GameObject.Find("btnQuit").GetComponent<Button>();
        btnQuit.onClick.AddListener(() =>
        {
            //ÍË³ö²Ù×÷
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
