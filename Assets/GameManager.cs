using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Text talkText;
    public GameObject scanObject;
    //public TalkManager talkManager;

    /*public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        talkText.text = "�̰��� �̸���" + scanObject.name + "�̶�� �Ѵ�";
    }*/
    public void ChangeScene()
    {
        SceneManager.LoadScene("Title");
    }
    public GameObject menuSet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
            {
                Cursor.visible = false;
                menuSet.SetActive(false);
                
            }

            else
            {
                menuSet.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
                
        }      
            
    }
    public void GameExit()
    {
        Application.Quit();
    }
    
    //void Talk()
   // {
        //talkManager.GetTalk(Id, talkIndex);
    //}
}
