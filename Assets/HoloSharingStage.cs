using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloSharingStage : MonoBehaviour {
    public GameObject[] duplicatedObjectsToRemove;
    public GameObject unetSharingStage;
    GameObject sceneParent;

    // Use this for initialization
    void Awake () {
        sceneParent = GameObject.Find("SceneParent");
        if (sceneParent != null) {
            unetSharingStage.transform.SetParent(sceneParent.transform, false);

            foreach(GameObject goToRemove in duplicatedObjectsToRemove)
            {
                DestroyImmediate(goToRemove);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
