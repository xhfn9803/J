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
        string sampleText = "�����ߴ� �� �ȿ� �������� �ִ�..��ȣ�� ã�� �����ǿ� �����Ͽ� ���̷����� ������ ã�ƶ�..  �ӹ� ������ ����Ѵ�..";
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
