using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    public FMODUnity.EventReference eventRef;
    FMOD.Studio.EventInstance eventInst;

    public GameObject origin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eventInst = FMODUnity.RuntimeManager.CreateInstance(eventRef);
            eventInst.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(origin));
            eventInst.start();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eventInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            eventInst.release();
        }
    }

    
}
