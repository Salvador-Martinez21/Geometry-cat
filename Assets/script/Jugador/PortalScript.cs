using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerMovement;

public class PortalScript : MonoBehaviour
{
    public Vehiculos Vehiculos;
    public Transform CubeVisual;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement Player = collision.GetComponent<PlayerMovement>();
        if (collision.CompareTag("Player"))
        {
            Debug.Log("jugador entró");
            Player.Portal(Vehiculos);

            Vector3 Rotation = CubeVisual.rotation.eulerAngles;
            Rotation.z = 0;
            CubeVisual.rotation = Quaternion.Euler(Rotation);
        }
    }
}