using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandWriting : MonoBehaviour {

    Coroutine c;
    float speed = 0.025f;
    public string text;
    public void Init(string text)
    {
        this.text = text;
    }
    
    public void CheckToHandwrite(GameObject go)
    {
        Text field = go.GetComponentInChildren<Text>();
        if (field == null)
            return;
        field.text = "";
        WriteTo(field, text, null);
    }

	public void WriteTo(Text field, string textToWrite,  System.Action OnReadyFunc)
	{
        if (c != null)
            StopCoroutine(c);
        field.text = "";

		c = StartCoroutine (WriteLoop (field, textToWrite, OnReadyFunc));
	}
	IEnumerator WriteLoop(Text field, string textToWrite,  System.Action OnReadyFunc)
	{
		int letterId = 0;
		int totalWords = textToWrite.Length;
		while (letterId < totalWords) {		
			if (field == null) {
                field.text = textToWrite;
                yield return null;
				StopAllCoroutines ();
			}	
			if (field != null) {
                field.text += textToWrite[letterId]; // + "_";
				letterId++;
				yield return new WaitForSeconds (speed);
			}
		}
		if(OnReadyFunc != null)
			OnReadyFunc ();
		yield return null;
	}
	void OnDestroy()
	{
		StopAllCoroutines ();
	}
	void OnDisable()
	{
        if (c != null)
            StopCoroutine(c);
    }
}
