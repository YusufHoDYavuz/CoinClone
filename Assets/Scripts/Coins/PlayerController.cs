using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    private bool left;
    private bool right;

    [SerializeField] private float rotSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion leftRot = Quaternion.Euler(transform.rotation.y, 330, transform.rotation.z);
        Quaternion rightRot = Quaternion.Euler(transform.rotation.x, 210, transform.rotation.z);

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.deltaPosition.x > 0.01f)
            {
                left = false;
                right = true;
            }

            if (touch.deltaPosition.x < -0.01f)
            {
                left = true;
                right = false;
            }

            if (right)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, leftRot, rotSpeed * Time.deltaTime);
            }

            if (left)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, rightRot, rotSpeed * Time.deltaTime);
            }
        }
    }
}
