using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNiveles : MonoBehaviour
{
    public void Nivel1()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void Nivel2()
    {
        SceneManager.LoadScene("Nivel2");
    }
}
