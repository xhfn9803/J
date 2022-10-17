using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCAreaController : MonoBehaviour
{
    public GameObject dialogPanel;
    public UnityEvent onPlayerEntered;
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
            
            dialogPanel.SetActive(true);
            onPlayerEntered.Invoke();
            
        };
    }
}

