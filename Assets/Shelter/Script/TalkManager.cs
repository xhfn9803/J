using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
        
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(100, new string[] { " ��.. ���� ������ Ȯ���� ���߰ڱ�.." , "����� �ϴ��� �� �ȵ鸮�µ�.."});
        talkData.Add(200, new string[] { " ������ ����Ʈ�� ���� �����߱�.." });
        talkData.Add(200, new string[] { " ���� ��������? ���� �׸� ������;�" });

    }

    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];

    }
}
