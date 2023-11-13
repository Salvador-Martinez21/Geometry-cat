using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbe : MonoBehaviour
{
    public enum Orbes { Roja = 0, Amarilla = 1, Rosa = 2 }
    public Orbes Pl_orbes;

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerMovement Player = collision.GetComponent<PlayerMovement>();
        if (collision.CompareTag("Player"))
        {
            Debug.Log("jugador entró");
            if (Pl_orbes == Orbes.Roja)
            {
                Player.Orbe(39.98715f);
            }
            if (Pl_orbes == Orbes.Amarilla)
            {
                Player.Orbe(20.6581f);
            }
            if (Pl_orbes == Orbes.Rosa)
            {
                Player.Orbe(8f);
            }
        }
    }
}
