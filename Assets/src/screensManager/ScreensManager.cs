using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MainEvents
{
    public static System.Action<ButtonStandard> OnButtonClicked = delegate { };
    public static System.Action<string> OnUIFX = delegate { };
}

public class ScreensManager : MonoBehaviour
{
	public ScreenBase[] all;

    public ScreenBase activeScreen;
    ScreenBase lastActiveScreen;
    public bool isAdmin;
    public float timeToTransition = 1;
    public bool loading;
    int id;

    void Start()
    {
        int id = 0;
        foreach (ScreenBase screenBase in all)
        {
            screenBase.Init(this, id);
            id++;
        }
        ResetAll();       
    }
	public void LoadScreen(int id, bool isRight)
	{
        this.id = id;
        Debug.Log("LoadScreen " + id + " loading: " + loading + " activeScreen: " + activeScreen);

        if (loading)
			return;

        MainEvents.OnUIFX("swipe");

		loading = true;
		if (activeScreen != null) {
			activeScreen.SetCenterPosition ();
			activeScreen.MoveTo (isRight, timeToTransition);
			lastActiveScreen = activeScreen;
		}

        activeScreen = all [id];
        activeScreen.gameObject.SetActive (true);
        activeScreen.SetInitialPosition (isRight);
        activeScreen.MoveTo (isRight, timeToTransition);

    }
	public void OnTransitionDone()
	{
        if (!loading)
			return;
		loading = false;
		if (lastActiveScreen != null) {
			lastActiveScreen.gameObject.SetActive (false);
			lastActiveScreen.OnReset ();
		}
		activeScreen.OnInit ();
	}
	public void ResetAll()
	{
        foreach (ScreenBase mainScreen in all) {
			mainScreen.gameObject.SetActive (false);
		}
	}
    void OnApplicationFocus(bool pauseStatus)
    {
        
    }

}
