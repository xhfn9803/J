using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MController : MonoBehaviour
{
    public Text DText;

    public UnityEvent onDialogFinished;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartDialog()
    {
        DText.text = "";
        string sampleText = "����-�ô�-�⵵-��- ��- �ð� ��";
        StartCoroutine(Typing(sampleText));
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
            DText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }

        // TODO
        yield return new WaitForSeconds(0.5f);
        FinishDialog();
    }
}