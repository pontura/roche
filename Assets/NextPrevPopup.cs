using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPrevPopup : MonoBehaviour
{
    public GameObject[] all;
    int id;
    GameObject active;

    private void Start()
    {
        id = 0;
        SetActiveSection();
    }
    void SetActiveSection()
    {
        foreach (GameObject go in all)
            go.SetActive(false);
        all[id].SetActive(true);
    }
    public void Next()
    {
        if (id < all.Length - 1)
            id++;
        else
            id = 0;
        SetActiveSection();
    }
    public void Prev()
    {
        if (id > 0)
            id--;
        else
            id = all.Length - 1;
        SetActiveSection();
    }
}
