using UnityEngine;

public class ChurchDoor : MonoBehaviour
{
    public FMODUnity.EventReference eventRef;

    Animator animator;

    float timer = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10.0f) timer -= 1.0f;

        if (timer > 5.0f && animator.GetBool("isOpen"))
        {
            animator.SetBool("isOpen", false);
            FMODUtil.PlayEvent(eventRef, gameObject, "isDoorOpen", "false");
            var clipInfo = animator.GetCurrentAnimatorStateInfo(0);
            timer = 0 - clipInfo.length;
        }
        Debug.Log(timer);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E) && !animator.GetBool("isOpen") && timer > 5.0f)
        {
            animator.SetBool("isOpen", true);
            FMODUtil.PlayEvent(eventRef, gameObject, "isDoorOpen", "true");
            var clipInfo = animator.GetCurrentAnimatorStateInfo(0);
            timer = 0 - clipInfo.length;
        }
    }
}
