using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SaloonDoors : MonoBehaviour
{
    public EventReference aEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            FMODUtil.PlayEvent(aEvent, gameObject);
    }
}
