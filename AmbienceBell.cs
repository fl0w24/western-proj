using System;
using UnityEngine;
using FMODUnity;

public class AmbienceBell : MonoBehaviour
{
    public EventReference aEvent;

    bool isPlayed = false;

    private void Update()
    {
        if (TimeOfDay.hours_str == Convert.ToString(12) && isPlayed == false)
        {
            isPlayed = true;
            Debug.Log("Bang!");
            FMODUtil.PlayEvent(aEvent, gameObject);
        }
        if (TimeOfDay.hours_str == Convert.ToString(13)) isPlayed = false;
    }
}
