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

    }

    public void Move(Vector2 InputDir)
    {
        Vector2 MoveInput = InputDir;

        Vector3 LookForward = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
        Vector3 LookRight = new Vector3(transform.right.x, 0, transform.right.z).normalized;

        Vector3 MoveDir = LookForward*MoveInput.y + LookRight*MoveInput.x;

        Rig.MovePosition(transform.position + MoveDir * MoveSpeed);

    }

    public void CameraRotation(Vector3 InputDir)
    {
        
        Vector2 MouseDelta = InputDir;
        Vector3 CamAngle = transform.rotation.eulerAngles;
        float X = CamAngle.x - MouseDelta.y;

        if (X < 180f)
        {
            X = Mathf.Clamp(X, -1f, 70f);
        }
        else
        {
            X = Mathf.Clamp(X, 335f, 361f);
        }

        transform.rotation = Quaternion.Euler(X, CamAngle.y + MouseDelta.x, CamAngle.z);
    }

}
