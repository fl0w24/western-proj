using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    public TimeOfDay timeOfDay;
    Vector3 rotation = Vector3.zero;

    public float get()
    {
        //if (rotation.x > 360f) rotation.x -= 360f;
        //rotation.x = timeOfDay.getTimeDelta();
        transform.Rotate(rotation, Space.World);
        //Debug.Log(transform.rotation.x);
        return rotation.x;
    }
}
