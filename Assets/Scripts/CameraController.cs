using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private float cameraAngle;
    Vector3 offset;
    Vector3 currentVelocity = Vector3.zero;

    void Awake()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 targetPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref currentVelocity, smoothSpeed);
        transform.LookAt(target.position + new Vector3(0, cameraAngle, 0));
    }
}
