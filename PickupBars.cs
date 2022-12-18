using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBars : MonoBehaviour
{
    public FMODUnity.EventReference eventRef;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            FMODUtil.PlayEvent(eventRef, gameObject);
            gameObject.SetActive(false);
        }
    }
}
