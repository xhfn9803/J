using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MAreaController : MonoBehaviour
{
    public UnityEvent onPlayerEntered;
    public GameObject Mpanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Mpanel.SetActive(true);
            onPlayerEntered.Invoke();
        };
    }
}