using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.Networking;


public class buttonClick : MonoBehaviour, IInputClickHandler
{

    public GameObject UNETsharing;

    // Use this for initialization
    void Start()
    {
    

    }

    public virtual void OnInputClicked(InputClickedEventData eventData)
    {
        if (transform.GetChild(0).GetChild(0).name == "Host")
        {
            UNETsharing.GetComponent<networkmanagerHUD2>().startH();
        }
        else if (transform.GetChild(0).GetChild(0).name == "Client")
        {
            Debug.Log("calling start client function");
            UNETsharing.GetComponent<networkmanagerHUD2>().startC();
        }
        else if (transform.GetChild(0).GetChild(0).name == "Stop")
        {
            Debug.Log("calling stop function");
            UNETsharing.GetComponent<networkmanagerHUD2>().stopHost();
        }
        else if (transform.GetChild(0).GetChild(0).name == "FindMatch")
        {
            UNETsharing.GetComponent<networkmanagerHUD2>().findMatch();
        }

        else if (transform.GetChild(0).GetChild(0).name == "JoinMatch")
        {
            UNETsharing.GetComponent<networkmanagerHUD2>().joinMatch();
        }
        else if (transform.GetChild(0).GetChild(0).name == "createMatch")
        {
            UNETsharing.GetComponent<networkmanagerHUD2>().createMatch();
        }
        else
        {
            Debug.Log("No button was recognized.");
                }
    }

}
