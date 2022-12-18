using UnityEngine;

public class DoorLock : MonoBehaviour
{
    /*public FMODUnity.EventReference eventRef;
    bool isLocked = true;
    Rigidbody emptyObjectRigidBody;
    HingeJoint joint;
    float timer = 0f;

    void Start()
    {
        joint = GetComponent<HingeJoint>();
        //emptyObjectRigidBody = GameObject.Find("joint_toggle").GetComponent<Rigidbody>();
        //joint.connectedBody = emptyObjectRigidBody;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2.0f) timer -= 1.0f;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E) && timer > 1.0f)
        {
            if (isLocked)
            {
                //joint.connectedBody = GetComponent<Rigidbody>();
                joint.spring.spring = 0.0f;
                FMODUtil.PlayEvent(eventRef, gameObject, "isDoorLocked", 0f);
                isLocked = false;
            }
            else
            {
                //joint.connectedBody = emptyObjectRigidBody;
                FMODUtil.PlayEvent(eventRef, gameObject, "isDoorLocked", 1f);
                isLocked = true;
            }
            timer = 0f;
        }
    }*/
}
