using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject uiObject;
    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
    }
    void OnTriggerEnter (Collider Player)
    {
        uiObject.SetActive(true);
    }
     void OnTriggerExit(Collider Player)
    {
        uiObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
