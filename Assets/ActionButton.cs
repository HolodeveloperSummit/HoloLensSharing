using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;
using UnityEngine.UI;
using UnityEngine.Events;

public class ActionButton : MonoBehaviour, IInputClickHandler
{
    public UnityEvent response;
    AudioSource audioS;


    // Use this for initialization
    void Start()
    {
        audioS = GameObject.Find("Buttons").GetComponent<AudioSource>();
    }


    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (audioS != null && audioS.clip != null && !audioS.isPlaying)
        {
            audioS.loop = false;
            audioS.Play();
        }
        CancelInvoke("DelayedAction");
        Invoke("DelayedAction", 0.1f);
    }

    public void DelayedAction()
    {
        //Select random word from list
        if (response != null)
        {
            try
            {
                response.Invoke();
                Debug.Log("Took action: " + response.GetPersistentMethodName(0));
            }
            catch
            {
                Debug.Log("Response not set up.");
            }
        }
    }

	
}
