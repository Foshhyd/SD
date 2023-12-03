using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccController : MonoBehaviour
{
    private Rigidbody rb;
    private float AccValue;
    public float RotateSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        AccValue = Input.acceleration.x * RotateSpeed;
        transform.Rotate(0, AccValue, 0);

    }
}
