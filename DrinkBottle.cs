using UnityEngine;
using System.Linq;

public class DrinkBottle : MonoBehaviour
{
    public FMODUnity.EventReference eventRef;
    GameObject origin;

    Transform[] allChildren;
    float timer;

    //bool isPlayerInTriggerZone = false;
    void Start()
    {
        origin = GameObject.Find("Head");
    }

    void OnTriggerStay(Collider other)
    {
        allChildren = GetComponentsInChildren<Transform>();
        GameObject closest = FindClosestObject(allChildren);
        if (other.CompareTag("Player") &&
            Input.GetKey(KeyCode.E) &&
            timer >= 0.5f && allChildren.Length > 1
            && Vector3.Distance(origin.transform.position, closest.transform.position) < 1.1f
            && allChildren.Length > 1)
        {
            FMODUtil.PlayEvent(eventRef, origin);
            closest.SetActive(false);
            timer = 0f;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.5f) timer -= 1.0f;

        //// Debug

        /*if (isPlayerInTriggerZone && allChildren.Length > 1)
        {
            GameObject closest = FindClosestObject(allChildren);
            Debug.DrawLine(origin.transform.position, closest.transform.position, Color.cyan);
            Debug.Log("Distance to closest: " + Vector3.Distance(closest.transform.position, origin.transform.position));
        }*/
        
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerInTriggerZone = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerInTriggerZone = false;
    }*/

    GameObject FindClosestObject(Transform[] targets)
    {
        Transform[] targetsWithoutParent = new Transform[targets.Length - 1];
        for (int i = 0; i < targetsWithoutParent.Length; i++)
        {
            targetsWithoutParent[i] = targets[i + 1];
        }
        Transform closest = targetsWithoutParent.OrderBy(target => Vector3.Distance(origin.transform.position, target.transform.position)).FirstOrDefault();
        return closest.gameObject;
    }
}
