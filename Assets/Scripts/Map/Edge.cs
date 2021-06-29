using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using GamePlay.Player;


public class Edge : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.GetComponent<PlayerHealth>().Die();
    }
}
