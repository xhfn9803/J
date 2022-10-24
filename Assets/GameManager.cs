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
        talkText.text = "이것의 이름은" + scanObject.name + "이라고 한다";
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
                Cursor.lockState = CursorLockMode.Locked; //마우스 커서 고정
                
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
        Cursor.lockState = CursorLockMode.Locked; //마우스 커서 고정

    }

    //void Talk()
    // {
    //talkManager.GetTalk(Id, talkIndex);
    //}
}
