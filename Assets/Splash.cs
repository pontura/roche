using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    public GameObject splash;
    public MainMenu mainMenu;

    void Start()
    {
        splash.SetActive(true);
    }

    public void Ready()
    {
        mainMenu.Init();
        splash.SetActive(false);
    }
}
