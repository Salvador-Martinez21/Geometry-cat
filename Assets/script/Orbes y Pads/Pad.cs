using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    public enum Pads { Roja = 0, Amarilla = 1, Rosa = 2 }
    public Pads Pl_pads;

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerMovement Player = collision.GetComponent<PlayerMovement>();
        if (collision.CompareTag("Player"))
        {
            Debug.Log("jugador entró");
            if (Pl_pads == Pads.Roja)
            {
                Player.pad(39.98715f);
            }
            if (Pl_pads == Pads.Amarilla)
            {
                Player.pad(30.6581f);
            }
            if (Pl_pads == Pads.Rosa)
            {
                Player.pad(20f);
            }
        }
    }
}
