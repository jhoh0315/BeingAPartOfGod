using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.UI.BodyUI;

public class RigController : MonoBehaviour
{
    public Transform leftHandIK;
    public Transform rightHandIK;
    public Transform headIK;

    public Transform leftHandController;
    public Transform rightHandController;
    public Transform hmd;

    public Vector3[] leftOffset;
    public Vector3[] rightOffset;
    public Vector3[] headOffset;

    public float smoothValue = 0.1f;
    public float modelHeight = 1.67f;
    public float bodyoffset = 0f;

    private void LateUpdate()
    {
        MappingHandTransform(leftHandIK, leftHandController, true);
        MappingHandTransform(rightHandIK, rightHandController, false);
        MappingBodyTransform(headIK, hmd);
        MappingHeadTransform(headIK, hmd);
    }

    private void MappingHandTransform(Transform ik, Transform controller, bool isleft)
    {
        var offset = isleft ? leftOffset : rightOffset;

        ik.position = controller.TransformPoint(offset[0]);
        ik.rotation = controller.rotation * Quaternion.Euler(offset[1]);
    }
    private void MappingBodyTransform(Transform ik, Transform hmd)
    {
        float yaw = hmd.eulerAngles.y;
        var targetRotation = new Vector3(this.transform.eulerAngles.x, yaw, this.transform.eulerAngles.z);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(targetRotation), smoothValue);
        this.transform.position = new Vector3(hmd.position.x, hmd.position.y - modelHeight, hmd.position.z) - this.transform.forward * bodyoffset;
    }

    private void MappingHeadTransform(Transform ik, Transform hmd)
    {
        ik.position = hmd.TransformPoint(headOffset[0]);
        ik.rotation = hmd.rotation * Quaternion.Euler(headOffset[1]);
    }



}
