using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    NavMeshAgent Nav;
    Animator Anim;

    private Vector3[] WayPoints;

    [SerializeField] Transform[] Target;
    [SerializeField] Transform Player;
    float Range = 30f;
    Collider[] Colliders;
    [SerializeField] BoxCollider AttackArea;
    public Slider Hpbar;

    [SerializeField] int MaxHp = 5;
    [SerializeField] int CurrentHp = 0;
    [SerializeField] float NavRadious = 10f;
    [SerializeField] float NavRange = 20f;
    public int Damage = 1;
    bool isAttack = true;

    bool IsBorder;

    

    void Awake()
    {
        Nav = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();
        CurrentHp = MaxHp;
    }

    // Start is called before the first frame update
    void Start()
    {
        /*WayPoints = new Vector3[Target.Length + 1];

        for (int i = 0; i < Target.Length; i++)
        {
            WayPoints[i] = Target[i].position;
        }

        WayPoints[WayPoints.Length - 1] = transform.position;*/

    }

    // Update is called once per frame
    void Update()
    {


        RaycastHit[] RayHits =
            Physics.SphereCastAll(transform.position,
            NavRadious,
            transform.forward, NavRange,
            LayerMask.GetMask("Player"));

        if (RayHits.Length > 0)
        {
            Nav.SetDestination(Player.position);
        }

        if (CurrentHp <= 0)
        {
            Die();
        }

        Targeting();


        Hpbar.maxValue = MaxHp;
        Hpbar.value = CurrentHp;

    }

   

    /*void Sight()
    {
        for (int i = 0; i < Colliders.Length; i++)
        {
            Player = Colliders[i].transform;

            if (Player.tag == "Player")
            {
                Nav.SetDestination(Player.position);             
            }
        }
        
    }*/



    /* void Patrol()
     {
         for (int j = 0; j < WayPoints.Length; j++)
         {
             if (Vector3.Distance(transform.position, WayPoints[j]) <= 1f)
             {
                 if (j != WayPoints.Length - 1)
                 {
                     Nav.SetDestination(WayPoints[j + 1]);
                 }
                 else
                 {
                     Nav.SetDestination(WayPoints[0]);
                 }
             }
         }
     }*/

    void Targeting()
    {
        float TargetRadius = 1.5f;
        float TargetRange = 3f;

        RaycastHit[] RayHits =
            Physics.SphereCastAll(transform.position,
            TargetRadius,
            transform.forward, TargetRange,
            LayerMask.GetMask("Player"));

        if (RayHits.Length > 0)
        {
            StartCoroutine(Attack());
        }

        else
        {
            Nav.isStopped = false;
            Anim.SetBool("Attack", false);
        }
    }

    IEnumerator Attack()
    {
        Nav.isStopped = true;
        Anim.SetBool("Attack", true);

        yield return new WaitForSeconds(1f);
        AttackArea.enabled = true;

        yield return new WaitForSeconds(1f);
        AttackArea.enabled = false;
    }

    void Die()
    {
        Anim.SetTrigger("Die");
        Destroy(gameObject, 5f);
        Nav.isStopped = true;
        // Nav.enabled = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            CurrentHp -= BulletScript.Damage;
        }
    }

    /*void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Nav.isStopped = true;
            Anim.SetBool("Attack", true);
        }

        else
        {
            Nav.isStopped = false;
            Anim.SetBool("Attack", false);
        }
    }*/

}



