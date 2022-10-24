using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    
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
        if (SceneManager.GetActiveScene().name == "Ending")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

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
                Cursor.lockState = CursorLockMode.Locked; //���콺 Ŀ�� ����
                
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
    public void Continue()
    {

        Cursor.visible = false;
        menuSet.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked; //���콺 Ŀ�� ����

    }

    //void Talk()
    // {
    //talkManager.GetTalk(Id, talkIndex);
    //}
}
