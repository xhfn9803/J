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
        talkData.Add(100, new string[] { " 음.. 빨리 안쪽을 확인해 봐야겠군.." , "뭐라고 하는지 잘 안들리는데.."});
        talkData.Add(200, new string[] { " 누군가 뮤턴트에 대해 연구했군.." });
        talkData.Add(200, new string[] { " 어디로 가야하지? 이제 그만 나가고싶어" });

    }

    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];

    }
}
