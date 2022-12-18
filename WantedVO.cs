using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class WantedVO : MonoBehaviour
{
    public EventReference eventRef;
    public GameObject origin;

    private void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E))
        {
            //Debug.Log("Hmm...");
            FMODUtil.PlayEvent(eventRef, origin);
        }
    }
}
