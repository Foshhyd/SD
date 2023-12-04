using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRotation : MonoBehaviour
{
    public float RotationSpeed;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, RotationSpeed * Time.deltaTime);
    }
}
