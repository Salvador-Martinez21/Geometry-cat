using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaclescript : MonoBehaviour
{
    public Transform Cube;
    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerMovement Player = other.collider.GetComponent<PlayerMovement>();
        if (other.collider.CompareTag("Player"))
        {
            Debug.Log("jugador entró");
            Player.Hit();
        }
    }
}