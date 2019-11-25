using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToogleButton : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject[] contents;
    int id = -1;
    Animation anim;
    public AnimationClip[] clips;
    void Awake()
    {
        anim = GetComponent<Animation>();
        foreach (GameObject go in contents)
        {
            HandWriting handWritting = go.AddComponent(typeof(HandWriting)) as HandWriting;
            handWritting.Init(go.GetComponentInChildren<Text>().text);
        }
    }
    void OnEnable()
    {
        id = -1;
        Clicked(0);
    }
    public void ToggleOneButton()
    {
        int _id;
        if (id == 0)
            _id = 1;
        else
            _id = 0;
        Clicked(_id);
    }
    public void Clicked(int _id)
    {
        if (id == _id)
            return;
        this.id = _id;
        print(id);
        SetSelect();
        if (anim != null && anim.GetClipCount()>0)
        {
           anim.Play(clips[id].name);
        }
    }
    void SetSelect()
    {
        Reset();
        buttons[id].SetActive(true);
        contents[id].SetActive(true);

        contents[id].GetComponent<HandWriting>().CheckToHandwrite(contents[id]);
    }
    private void Reset()
    {
        foreach (GameObject go in buttons)
            go.SetActive(false);
        foreach (GameObject go in contents)
            go.SetActive(false);

    }
}
