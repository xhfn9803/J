using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();

    }

    public float MoveSpeed
    {
        set => animator.SetFloat("MovementSpeed", value);
        get => animator.GetFloat("MovementSpeed");
    }

    public void OnReload()
    {
        animator.SetTrigger("onReload");
    }

    // Assault Rifle 마우스 오른ㅉㄱ 클릭 액션 (default/aim mode)
    public bool AimModeIs
    {
        set => animator.SetBool("isAimMode", value);
        get => animator.GetBool("isAimMode");
    }

    public void Play(string stateName, int layer, float normalizedTime)
    {
        animator.Play(stateName, layer, normalizedTime);
    }

    public bool currentAnimationIs(string name)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(name);
    }
}
