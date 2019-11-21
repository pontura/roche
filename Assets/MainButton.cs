using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButton : MonoBehaviour
{
    public GameObject state_normal;
    public GameObject state_selected;
    MainSection mainSection;
    public int id;

    void Start()
    {
        mainSection = GetComponentInParent<MainSection>();
    }
    public void SetState(bool isOn)
    {
        if(isOn)
        {
            state_normal.SetActive(true);
            state_selected.SetActive(false);
        }
        else
        {
            state_normal.SetActive(false);
            state_selected.SetActive(true);
        }
    }

    public void Clicked()
    {
        mainSection.Clicked(this);
    }
}
