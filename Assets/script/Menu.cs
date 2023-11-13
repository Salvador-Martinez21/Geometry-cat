using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Salir()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }
}
