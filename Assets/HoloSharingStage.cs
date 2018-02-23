using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloSharingStage : MonoBehaviour {
    public GameObject[] duplicatedObjectsToRemove;
    public GameObject unetSharingStage;
    GameObject sceneParent;
    public string calibrationSceneName;

    // Use this for initialization
    void Awake () {
        sceneParent = GameObject.Find("SceneParent");
        if (sceneParent != null) {
            unetSharingStage.transform.SetParent(sceneParent.transform, false);

            if (duplicatedObjectsToRemove.Length > 0)
            {
                foreach (GameObject goToRemove in duplicatedObjectsToRemove)
                {
                    Destroy(goToRemove);
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadCalibrationScene()
    {
        if (!string.IsNullOrEmpty(calibrationSceneName) && UnityEngine.SceneManagement.SceneManager.GetSceneByName(calibrationSceneName) != null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(calibrationSceneName);
        }
        else
        {
            Debug.Log("Invalid Scene Name:" + calibrationSceneName);
        }
    }
}
