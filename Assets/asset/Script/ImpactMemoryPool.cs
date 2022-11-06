using UnityEngine;

public enum ImpactType { Normal = 0, Obstacle, }

public class ImpactMemoryPool : MonoBehaviour
{
    [SerializeField]
    private GameObject[] impactPrefab; //�ǰ� ����Ʈ
    private MemoryPool[] memoryPool; //�ǰ� ����Ʈ �޸�Ǯ

    private void Awake()
    {
        //�ǰ� ����Ʈ�� ���� �����̸� �������� memoryPool ����
        memoryPool = new MemoryPool[impactPrefab.Length];
        for ( int i = 0; i < impactPrefab.Length; ++ i )
        {
            memoryPool[i] = new MemoryPool(impactPrefab[i]);
        }
    }

    public void SpawnImpact(RaycastHit hit)
    {
        //�ε��� ������Ʈ�� Tag ������ ���� �ٸ��� ó��
        if (hit.transform.CompareTag("ImpactNormal"))
        {
            OnSpawnImpact(ImpactType.Normal, hit.point, Quaternion.LookRotation(hit.normal));
        }
        else if (hit.transform.CompareTag("ImpactObstacle"))
        {
            OnSpawnImpact(ImpactType.Obstacle, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }

    public void OnSpawnImpact(ImpactType type, Vector3 position, Quaternion rotation)
    {
        GameObject item = memoryPool[(int)type].ActivatePoolItem();
        item.transform.position = position;
        item.transform.rotation = rotation;
        item.GetComponent<Impact>().Setup(memoryPool[(int)type]);
    }
}