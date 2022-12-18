using System;
using UnityEngine;

public class AnimVaultDoor : MonoBehaviour
{
    public FMODUnity.EventReference eventRef;

    Animator animator;
    GameObject goldenBars;

    void Start()
    {
        animator = GetComponent<Animator>();
        goldenBars = GameObject.Find("bars");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("isOpening", !animator.GetBool("isOpening"));
            
            if (animator.GetBool("isOpening"))
                FMODUtil.PlayEvent(eventRef, gameObject, "isVaultOpening", 1f);
            else
                FMODUtil.PlayEvent(eventRef, gameObject, "isVaultOpening", 0f);
        }
    }

    private void Update()
    {
        if (animator.GetBool("isOpening"))
            goldenBars.GetComponent<BoxCollider>().enabled = true;
        else
            goldenBars.GetComponent<BoxCollider>().enabled = false;
    }
}
