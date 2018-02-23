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
            UNETsharing.GetComponent<networkmanagerHUD2>().startH();

        if (transform.GetChild(0).GetChild(0).name == "Client")
            UNETsharing.GetComponent<networkmanagerHUD2>().startC();

        if (transform.GetChild(0).GetChild(0).name == "Stop")
            UNETsharing.GetComponent<networkmanagerHUD2>().stopHost();

        if (transform.GetChild(0).GetChild(0).name == "FindMatch")
            UNETsharing.GetComponent<networkmanagerHUD2>().findMatch();

        if (transform.GetChild(0).GetChild(0).name == "JoinMatch")
            UNETsharing.GetComponent<networkmanagerHUD2>().joinMatch();
    }

}
