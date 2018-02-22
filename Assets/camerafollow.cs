using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class camerafollow : NetworkBehaviour
{

	// Use this for initialization
	void Start () {

    }


	
	// Update is called once per frame
	void Update () {

        if (!isLocalPlayer)
        {
            return;
        }

        transform.position = Camera.main.transform.position;
        transform.rotation = Camera.main.transform.rotation;


    }
}
