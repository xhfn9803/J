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
        //Move();
        //CameraRotation();
    }

    public void Move(Vector2 InputDir)
    {
        Vector2 MoveInput = InputDir;

        Vector3 LookForward = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
        Vector3 LookRight = new Vector3(transform.right.x, 0, transform.right.z).normalized;

        Vector3 MoveDir = LookForward*MoveInput.y + LookRight*MoveInput.x;

        Rig.MovePosition(transform.position + MoveDir * MoveSpeed);

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
