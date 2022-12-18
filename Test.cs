using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject origin;
    public GameObject target;

    void Update()
    {
        Physics.Raycast(origin.transform.position, target.transform.position, out RaycastHit rHit, Mathf.Infinity);
        //Debug.Log(rHit.distance);
    }
}
