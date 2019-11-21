using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButton : MonoBehaviour
{
    public GameObject state_normal;
    public GameObject state_selected;
    MainSection mainSection;
    public int id;
    bool isOn;

    void Start()
    {
        mainSection = GetComponentInParent<MainSection>();
    }
    void OnEnable()
    {
        if(isOn)
            Data.Instance.handWritting.CheckToHandwrite(state_selected);
        else
            Data.Instance.handWritting.CheckToHandwrite(state_normal);
    }
    public void SetState(bool isOn)
    {
        this.isOn = isOn;
        if (isOn)
        {
            state_normal.SetActive(false);           
            state_selected.SetActive(true);
            Data.Instance.handWritting.CheckToHandwrite(state_selected);
        }
        else
        {
            state_normal.SetActive(true);
            state_selected.SetActive(false);
        }
    }

    public void Clicked()
    {
        mainSection.Clicked(this);
    }
    
}
