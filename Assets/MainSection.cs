using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSection : MonoBehaviour
{
    MainButton[] all;
    public MainContent[] content;

    void Start()
    {
        Reset();
        all = GetComponentsInChildren<MainButton>();
    }
    
    public virtual void Clicked(MainButton button)
    {
        Reset();
        foreach (MainButton b in all)
        {
            if (b == button)
            {
                b.SetState(true);
                content[button.id - 1].gameObject.SetActive(true);
            }
            else
            {
                b.SetState(false);
            }
        }
    }
    void Reset()
    {
       foreach(MainContent c in content)
        {
            c.gameObject.SetActive(false);
        }
    }
}
