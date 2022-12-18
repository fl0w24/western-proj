using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    Vector3 lightRotation = Vector3.zero;
    // Градусы в секунду
    public TimeOfDay timeOfDay;
    public SunRotation sunRotation;
    Light lightComp;

    private void Start()
    {
        lightComp = GetComponent<Light>();
    }

    void Update()
    {
        //lightRotation.x = timeOfDay.getTimeDelta();
        transform.Rotate(lightRotation, Space.World);
        // Debug.Log(transform.rotation.x);
        if (sunRotation.get() < 0f || sunRotation.get() > 180f)
            lightComp.intensity = 0f;
        else lightComp.intensity = 1f;
    }
}
