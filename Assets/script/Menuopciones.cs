using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Menuopciones : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void PantallaCompleta(bool Pantallacompleta)
    {
        Screen.fullScreen = Pantallacompleta;
    }

    public void CambiarVolumen(float volumen)
    {
        audioMixer.SetFloat("volumen", volumen);
    }
}
