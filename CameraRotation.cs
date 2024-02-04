using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation: MonoBehaviour
{
    private int rotationSpeed = 10;

    // Update is called once per frame
    void Update()
    {
        Quaternion currentRotation = transform.rotation;

        float newRotationAngle = currentRotation.eulerAngles.y + rotationSpeed * Time.deltaTime;

        Quaternion newRotation = Quaternion.Euler(45f, newRotationAngle, 0);
        transform.rotation = newRotation;
    }
}
