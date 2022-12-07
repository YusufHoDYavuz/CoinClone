using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCoin : MonoBehaviour
{
    [SerializeField] private float maxAngle;
    [SerializeField] private float coinsSpeed;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        transform.localPosition += transform.right * Time.deltaTime * coinsSpeed;

        if (Input.GetKey(KeyCode.A))
         {
            transform.Rotate(new Vector3(0, -45, 0) * Time.deltaTime * maxAngle);
         }

         if (Input.GetKey(KeyCode.D))
         {
            transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime * maxAngle);
         }
    }
}
