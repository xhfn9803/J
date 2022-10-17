using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPad : MonoBehaviour
{

    [SerializeField] GameObject WrongText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button1()
    {
        Scene2.InsertNum[Scene2.ArrayNum] = 1;
        Scene2.ArrayNum++;

    }

    public void Button2()
    {
        Scene2.InsertNum[Scene2.ArrayNum] = 2;
        Scene2.ArrayNum++;

    }

    public void Button3()
    {
        Scene2.InsertNum[Scene2.ArrayNum] = 3;
        Scene2.ArrayNum++;

    }

    public void Button4()
    {
        Scene2.InsertNum[Scene2.ArrayNum] = 4;
        Scene2.ArrayNum++;

    }

    public void Button5()
    {
        Scene2.InsertNum[Scene2.ArrayNum] = 5;
        Scene2.ArrayNum++;

    }

    public void Button6()
    {
        Scene2.InsertNum[Scene2.ArrayNum] = 6;
        Scene2.ArrayNum++;

    }

    public void Button7()
    {
        Scene2.InsertNum[Scene2.ArrayNum] = 7;
        Scene2.ArrayNum++;

    }

    public void Button8()
    {
        Scene2.InsertNum[Scene2.ArrayNum] = 8;
        Scene2.ArrayNum++;

    }

    public void Button9()
    {
        Scene2.InsertNum[Scene2.ArrayNum] = 9;
        Scene2.ArrayNum++;

    }

    public void Button0()
    {
        Scene2.InsertNum[Scene2.ArrayNum] = 0;
        Scene2.ArrayNum++;

    }

    public void WrongButton()
    {
        WrongText.SetActive(false);
    }

}
