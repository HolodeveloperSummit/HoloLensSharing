using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloSharingMatrix : MonoBehaviour {

    GameObject calibrationObj;
    Camera mainCam;
    Transform mainCamParent;
    Transform sceneParent;
    float lastTimeRun;
    GameObject originObj;
    public string mainSceneName;


	// Use this for initialization
	void Start () {
        calibrationObj = GameObject.Find("CalibrationObj");
        originObj= GameObject.Find("InputManager");
        mainCam = Camera.main;
        mainCamParent = mainCam.transform.parent;
        sceneParent = GameObject.Find("SceneParent").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C) && Time.realtimeSinceStartup - lastTimeRun > 2f)
        {
            lastTimeRun = Time.realtimeSinceStartup;
            CalibrateSharedWorldSpace();
        }

        if (Input.GetKey(KeyCode.L) && Time.realtimeSinceStartup - lastTimeRun > 2f)
        {
            lastTimeRun = Time.realtimeSinceStartup;
            LoadScene();
        }
    }

    public void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainSceneName);
    }

    public void CalibrateSharedWorldSpace()
    {
        Vector3 newCameraParentPos = calibrationObj.transform.position;
        Vector3 newCameraParentForward = calibrationObj.transform.forward;

        //Matrix4x4 cameraTRSMatrix = Matrix4x4.TRS(mainCam.transform.position, mainCam.transform.rotation, Vector3.one);

        StartCoroutine(MoveCamera(newCameraParentPos, newCameraParentForward));//, cameraTRSMatrix));

    }

    IEnumerator MoveCamera(Vector3 newCameraParentPos, Vector3 newCameraParentForward)//, Matrix4x4 cameraTRSMatrix)//, Matrix4x4 cameraRotateMatrix)
    {
        Vector3 oldCameraPos = mainCamParent.position;
        Vector3 oldCameraForward = mainCamParent.forward;

        sceneParent.forward = newCameraParentForward;
        sceneParent.position = newCameraParentPos;

        
        mainCamParent.forward = oldCameraForward;
        mainCamParent.position = oldCameraPos;
        yield return null;
    }
}
