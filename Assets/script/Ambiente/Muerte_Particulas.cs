using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Muerte_Particulas : MonoBehaviour

{
    public GameObject Player;
    public ParticleSystem Particulas;

    void Update()
    {
        if (Player == null) { return; }
        Vector3 position = transform.position;
        position.x = Player.transform.position.x;
        position.y = Player.transform.position.y;
        transform.position = position;
    }
}