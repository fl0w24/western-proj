using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugVector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.DrawLine(gameObject.transform.position, gameObject.transform.position - transform.forward, new Color(1.0f, 0, 0));
    }
}
