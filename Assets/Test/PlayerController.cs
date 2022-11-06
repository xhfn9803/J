using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Input KeyCodes")]
    [SerializeField]
    private KeyCode KeyCodeRun = KeyCode.LeftShift; //달리기 키
    [SerializeField]
    private KeyCode KeyCodeJump = KeyCode.Space; //점프 키
    [SerializeField]
    private KeyCode keyCodeReload = KeyCode.R; //재장전 키


    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip audioClipWalk;
    [SerializeField]
    private AudioClip audioClipRun;

    private RotateToMouse rotateToMouse; //마우스 이동으로 카메라 회전
    private MovementCharacterController movement;
    private Status status;
    private PlayerAnimatorController animator;
    private AudioSource audioSource; //사운드 재생 제어
    private WeaponAssaultRifle weapon; //무기를 이용한 공격 제어


         private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rotateToMouse = GetComponent<RotateToMouse>();
        movement = GetComponent<MovementCharacterController>();
        status = GetComponent < Status>();
        animator = GetComponent<PlayerAnimatorController>();
        audioSource = GetComponent<AudioSource>();
        weapon = GetComponentInChildren<WeaponAssaultRifle>();
    }

    private void Update()
    {
        UpdateRotate();
        UpdateMove();
        UpdateJump();
        UpdateWeaponAction();
    }

    private void UpdateRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotateToMouse.UpdateRotate(mouseX, mouseY);
    }

    private void UpdateMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        //이동중 일때 9걷기 or 뛰기)
        if( x != 0 || z !=0)
        {
            bool isRun = false;

            //옆이나 뒤로 이동할 째는 달릴 수 없다
            if (z > 0) isRun = Input.GetKey(KeyCodeRun);

            movement.MoveSpeed = isRun == true ? status.RunSpeed : status.WalkSpeed;
            animator.MoveSpeed = isRun == true ? 1 : 0.5f;
            audioSource.clip = isRun == true ? audioClipRun : audioClipWalk;

            if ( audioSource.isPlaying == false)
            {
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        //제자리에 멈춰 있을 때
        else
        {
            movement.MoveSpeed = 0;
            animator.MoveSpeed = 0;

            if ( audioSource.isPlaying == true)
            {
                audioSource.Stop();
            }
        }

        movement.MoveTo(new Vector3(x, 0, z));
    }

    private void UpdateJump()
    {
        if (Input.GetKeyDown(KeyCodeJump))
        {
            movement.Jump();
        }
    }

    private void UpdateWeaponAction()
    {
        if( Input.GetMouseButtonDown(0))
        {
            weapon.StartWeaponAction();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            weapon.StopWeaponAction();
        }

        if( Input.GetMouseButtonDown(1))
        {
            weapon.StartWeaponAction(1);
        }
        else if(Input.GetMouseButtonUp(1))
        {
            weapon.StopWeaponAction(1);
        }

        if(Input.GetKeyDown(keyCodeReload))
        {
            weapon.StartReload();
        }
    }
}
