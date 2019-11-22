using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainButton : MonoBehaviour
{
    public GameObject state_normal;
    public GameObject state_selected;
    public Text field;
    MainSection mainSection;
    public int id;
    bool isOn;
    HandWriting handWritting;

    void Awake()
    {
        mainSection = GetComponentInParent<MainSection>();
        handWritting = gameObject.AddComponent(typeof(HandWriting)) as HandWriting;
        handWritting.Init(field.text);
    }
    void OnEnable()
    {
        if (isOn)
           handWritting.CheckToHandwrite(state_selected);
        else
           handWritting.CheckToHandwrite(state_normal);
    }
    public void SetState(bool isOn)
    {
        field.text = handWritting.text;
        this.isOn = isOn;
        if (isOn)
        {
            state_normal.SetActive(false);           
            state_selected.SetActive(true);
            handWritting.CheckToHandwrite(state_selected);
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
