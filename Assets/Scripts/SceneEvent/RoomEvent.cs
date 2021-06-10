using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        var btnNewGame = GameObject.Find("btnNewGame").GetComponent<Button>();
        btnNewGame.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Combat");
        });

        var btnQuitRoom = GameObject.Find("btnQuitRoom").GetComponent<Button>();
        btnQuitRoom.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("RoomSearching");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
