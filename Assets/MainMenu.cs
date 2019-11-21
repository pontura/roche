using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public List<MainSection> all;
    public Animation anim;
    public GameObject mainSectionsDefault;
    int id;

    private void Start()
    {
        Init();
    }
    private void Init()
    {
        mainSectionsDefault.SetActive(false);
        menu.gameObject.SetActive(true);
        ResetAll();
    }
    public void Clicked(int id)
    {
        mainSectionsDefault.SetActive(false);
        StartCoroutine(Delayed(id));
    }
    void ResetAll()
    {
        foreach (MainSection ms in all)
            ms.gameObject.SetActive(false);
    }
    IEnumerator Delayed(int id)
    {
        this.id = id; 
        MainSection mainSection = all[id - 1];
        switch (id)
        {
            case 1:
                anim.Play("vejiga");
                break;
            case 2:
                anim.Play("mama");
                break;
            case 3:
                anim.Play("pulmon");
                break;
        }
        yield return new WaitForSeconds(0.7f);
        mainSection.gameObject.SetActive(true);
        mainSectionsDefault.SetActive(true);
    }
    public void Back()
    {
        StartCoroutine(BackAnim());
    }
    IEnumerator BackAnim()
    {
        mainSectionsDefault.SetActive(false);
        ResetAll();
        switch (id)
        {
            case 1:
                anim.Play("vejigaBack");
                break;
            case 2:
                anim.Play("mamaBack");
                break;
            case 3:
                anim.Play("pulmonBack");
                break;
        }
        yield return new WaitForSeconds(0.7f);
        Init();
    }
}
