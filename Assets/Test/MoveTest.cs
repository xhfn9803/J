using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    [SerializeField]
    float MoveSpeed;

    [SerializeField]
    float LookSensitivity;

    [SerializeField]
    float CameraRot;
    float CurrentCameraRotX = 0;

    [SerializeField]
    Camera Cam;

    Rigidbody Rig;
    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CameraRotation();
    }

    void Move()
    {
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveZ = Input.GetAxisRaw("Vertical");

        Vector3 Horizontal = transform.right * MoveX;
        Vector3 Vertical = transform.forward * MoveZ;

        Vector3 Velocity = (Horizontal + Vertical).normalized * MoveSpeed;

        Rig.MovePosition(transform.position + Velocity * Time.deltaTime);

    }

    void CameraRotation()
    {
        float XRot = Input.GetAxisRaw("Mouse Y");
        float CameraRotX = XRot * LookSensitivity;
        CurrentCameraRotX -= CameraRotX;
        CurrentCameraRotX = Mathf.Clamp(CurrentCameraRotX, -CameraRot, CameraRot);

        Cam.transform.localEulerAngles = new Vector3(CurrentCameraRotX+90, 0f, 0f);

    }

}
