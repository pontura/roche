using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulmon : MainSection
{
    public MainMenu mainMenu;
    public GameObject header;
    public GameObject content1;
    public GameObject content2;
    public GameObject content3;
    bool isMainPulmon;

    private void Start()
    {
        Init();
    }
    private void Init()
    {
        isMainPulmon = true;
        header.SetActive(true);
        content1.SetActive(false);
        content2.SetActive(false);
        content3.SetActive(false);
    }
    public override void Clicked(MainButton button)
    {
        isMainPulmon = false;
        header.SetActive(false);
        switch (button.id)
        {
            case 1:
                content1.SetActive(true);
                break;
            case 2:
                content2.SetActive(true);
                break;
            case 3:
                content3.SetActive(true);
                break;
        }
    }
    public void Back()
    {
        if (isMainPulmon)
            mainMenu.Back();        
        else
            Init();
    }
}
