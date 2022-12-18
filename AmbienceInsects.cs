using UnityEngine;
using FMODUnity;

public class AmbienceInsects : MonoBehaviour
{
    public EventReference eventRef;
    FMOD.Studio.EventInstance eventInst;

    CameraMain mainCam;

    void Start()
    {
        mainCam = GameObject.Find("vThirdPersonCamera").GetComponent<CameraMain>();
        eventInst = RuntimeManager.CreateInstance(eventRef);
        eventInst.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
        eventInst.start();
    }

    void Update()
    {
        eventInst.setParameterByName("elevation", mainCam.elevation);
    }
}
