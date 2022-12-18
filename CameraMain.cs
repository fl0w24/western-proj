using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour
{
    public float elevation
    {
        get { return transform.position.y; }
    }
}
