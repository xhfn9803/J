using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogController : MonoBehaviour
{
    public Text dialogText;

    public UnityEvent onDialogFinished;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void StartDialog()
    {
        dialogText.text = "";
        string sampleText = "도착했다 이 안에 연구실이 있다..암호를 찾아 연구실에 잠입하여 바이러스의 원인을 찾아라..  임무 성공을 기원한다..";
        StartCoroutine(Typing(sampleText));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FinishDialog()
    {
        gameObject.SetActive(false);
        StopAllCoroutines();
        onDialogFinished.Invoke();
    }
    IEnumerator Typing(string text)
    {
        foreach (char letter in text.ToCharArray())
                {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(3f);
        FinishDialog();
    }
}
