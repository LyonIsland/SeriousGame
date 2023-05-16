using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeviceData : MonoBehaviour
{
    // Attitude Sensor;
    private Transform deviceRotator;

    public bool isRotLeft;

    public bool isRotRight;

    public float rotLeftAngle;

    public float rotRightAngle;

    // Start is called before the first frame update
    void Start()
    {
        // Device Setup
        InputSystem.EnableDevice(AttitudeSensor.current);
        deviceRotator = new GameObject("Device").transform;
        deviceRotator.SetPositionAndRotation(transform.position,transform.rotation);
        isRotLeft = false;
        isRotRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if (gyro.rotationRate.z > 0)
        // {
        //     isGyroRotRight = true;
        //     isGyroRotLeft = false;
        //     gyroRightAngle = Mathf.Abs(Vector3.Angle(Vector3.right, gyro.attitude.eulerAngles));
        // }
        // if (gyro.rotationRate.z < 0)
        // {
        //     isGyroRotRight = false;
        //     isGyroRotLeft = true;
        //     gyroLeftAngle = Mathf.Abs(Vector3.Angle(Vector3.left, gyro.attitude.eulerAngles));
        // }
        
    }
    
}
