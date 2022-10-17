using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;


public class Scene2 : MonoBehaviour
{
    public static int[] InsertNum = { -1, -1, -1, -1, -1 };
    public int[] InsertNuma = InsertNum;
    public static int[] CorrectNum = { 1, 8, 0, 8, 2 };
    public static int ArrayNum = 0;


    [SerializeField] GameObject PadMenu;
    [SerializeField] GameObject WrongText;

    public int LastInsert;

    bool Answer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LastInsert = InsertNum[4];
        Answer = InsertNum.SequenceEqual(CorrectNum);
    }
    void OnTriggerEnter(Collider col)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        PadMenu.SetActive(true);

        if (LastInsert > 0)
        {
            if (Answer)
            {
                SceneManager.LoadScene("Chapter2");
            }

            else if (!Answer)
            {
                WrongText.SetActive(true);
                

                InsertNum[0] = -1;
                InsertNum[1] = -1;
                InsertNum[2] = -1;
                InsertNum[3] = -1;
                InsertNum[4] = -1;

                ArrayNum = 0;

            }
        }
    }
}
