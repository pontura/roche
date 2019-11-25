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
    public int sec;
    int totalSecsToReset = 10;
    public bool isOnMain;
    Splash splash;
    private void Start()
    {
        splash = GetComponent<Splash>();
        ResetMain();
        Loop();
    }
    void ResetMain()
    {
        mainSectionsDefault.SetActive(false);
        menu.gameObject.SetActive(false);
    }
    public void Init()
    {
        sec = 0;
        menu.gameObject.SetActive(true);
        ResetAll();
        isOnMain = true;
    }
    public void Clicked(int id)
    {
        isOnMain = false;
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
    void Loop()
    {
        Invoke("Loop", 1);
        if (isOnMain)
        {
            sec++;
            if(sec>totalSecsToReset)
            {
                GotoSplash();               
            }
        } else
        {
            sec = 0;
        }
    }
    void GotoSplash()
    {
        isOnMain = false;
        splash.Init();
        ResetMain();
    }
}
