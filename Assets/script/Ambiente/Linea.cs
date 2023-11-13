using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linea : MonoBehaviour
{
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        if(Player == null) 
        {
            return; 
        
        }
        Vector3 position = transform.position;
        position.x = Player.transform.position.x + 6f;
        transform.position = position;
        
    }
}
