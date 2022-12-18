using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using Invector.vCharacterController;

public class FootstepSound : MonoBehaviour
{
    public GameObject soundEmitter;
    public EventReference footstepEvent;

    FMOD.Studio.EventInstance footstepInstance;

    vThirdPersonInput tpInput;
    vThirdPersonController tpController;

    string surfaceType;
    string locomotionType;

    private void Start()
    {
        tpInput = GetComponent<vThirdPersonInput>();
        tpController = GetComponent<vThirdPersonController>();
    }

    private void Update()
    {
        surfaceType = getSurfaceType(soundEmitter.transform.position, Mathf.Infinity, "Surface");
        locomotionType = getLocomotionType();
    }

    void Footstep()
    {
        if (tpInput.cc.inputMagnitude > 0.1f)
        {
            footstepInstance.setParameterByNameWithLabel("surfaceType", surfaceType);
            footstepInstance.setParameterByNameWithLabel("locomotionType", locomotionType);
            FMODUtil.PlayEvent(footstepEvent, soundEmitter, new string[] { "surfaceType", "locomotionType" }, new string[] { surfaceType, locomotionType });
        }
    }

    string getSurfaceType(Vector3 origin, float distance, string layerName)
    {
        if (Physics.Raycast(origin, Vector3.down,
            out RaycastHit rHit, distance,
            LayerMask.GetMask(layerName)))
            return rHit.collider.tag;
        else
        {
            RuntimeManager.StudioSystem.getParameterLabelByName("surfaceType", 0, out string defaultSurfaceType);
            return defaultSurfaceType;
        }
    }

    string getLocomotionType()
    {
        if (tpController.isSprinting)
            return "Sprint";
        else
            return "Walk";
    }
}
