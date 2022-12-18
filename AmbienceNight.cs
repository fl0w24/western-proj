using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AmbienceNight : MonoBehaviour
{
    public EventReference eventRef;
    FMOD.Studio.EventInstance eventInst;

    CameraMain mainCam;

    void Start()
    {
        mainCam = GameObject.Find("vThirdPersonCamera").GetComponent<CameraMain>();
        eventInst = RuntimeManager.CreateInstance(eventRef);
        eventInst.start();
    }

    void Update()
    {
        eventInst.setParameterByName("elevation", mainCam.elevation);
    }
}
