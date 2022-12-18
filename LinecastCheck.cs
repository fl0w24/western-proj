using FMODUnity;
using UnityEngine;

public class LinecastCheck : MonoBehaviour
{
    public GameObject origin;
    public GameObject target;

    public EventReference eventRef;
    FMOD.Studio.EventInstance eventInst;

    bool isBlocking;
    bool isPlayerInTriggerZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eventInst = RuntimeManager.CreateInstance(eventRef);
            isPlayerInTriggerZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eventInst.release();
            isPlayerInTriggerZone = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        eventInst.getPlaybackState(out FMOD.Studio.PLAYBACK_STATE playbackState);
        if (other.CompareTag("Player"))
        {
            if (isBlocking && FMODUtil.isStoppedOrStopping(eventInst))
                eventInst.start();

            if (!isBlocking && FMODUtil.isPlayingOrStarting(eventInst))
                eventInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

    private void FixedUpdate()
    {
        if (isPlayerInTriggerZone)
            isBlocking = Physics.Linecast(origin.transform.position, target.transform.position, LayerMask.GetMask("RaycastBlock"));
    }
}
