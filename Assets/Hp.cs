using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Hp : MonoBehaviour
{

    [SerializeField] private int MaxHp = 3;
    [SerializeField] int CurrentHp;
    [SerializeField] int Force = 5;
    bool NoHp = false;
    bool isDamage = false;
    [SerializeField] Rigidbody rb;
    Vector3 ReactVec;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHp <= 0)
        {
            NoHp = true;

            StartCoroutine(SceneLoad());
        }



    }

    IEnumerator SceneLoad()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Ending");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (NoHp == false && !isDamage)
        {
            if (col.gameObject.tag == "Monster")
            {
                Monster monster = col.GetComponent<Monster>();
                CurrentHp -= monster.Damage;
                ReactVec = transform.position - col.transform.position;
                StartCoroutine(OnDamage(ReactVec));
            }
        }
       
    }

    IEnumerator OnDamage(Vector3 ReactVec)
    {
        isDamage = true;
        ReactVec = ReactVec.normalized;

        yield return new WaitForSeconds(1f);

        rb.AddForce(ReactVec * Force, ForceMode.Impulse);

        yield return new WaitForSeconds(2f);
        isDamage = false;
    }


}
