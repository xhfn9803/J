using UnityEngine;
using System.Collections.Generic;

public class MemoryPool
{
    //�޸� Ǯ�� �����Ǵ� ������Ʈ ����
    private class PoolItem
    {
        public bool isActive; //"gameObject"�� Ȱ��ȭ/��Ȱ��ȭ ����
        public GameObject gameObject; //ȭ�鿡 ���̴� ���� ���� ������Ʈ
    }

    private int increaseCount = 5; //������Ʈ�� ������ �� Unstantiate()�� �߰� �����Ǵ� ������Ʈ ����
    private int maxCount;
    private int activeCount;

    private GameObject poolObject;
    private List<PoolItem> poolItemList;

    public int MaxCount => maxCount;
    public int ActiveCount => activeCount;

    public MemoryPool(GameObject poolObject)
    {
        maxCount = 0;
        activeCount = 0;
        this.poolObject = poolObject;

        poolItemList = new List<PoolItem>();

        InstantiateObjects();
    }


    public void InstantiateObjects()
    {
        maxCount += increaseCount;

        for ( int i = 0; i < increaseCount; ++ i)
        {
            PoolItem poolItem = new PoolItem();

            poolItem.isActive = false;
            poolItem.gameObject = GameObject.Instantiate(poolObject);
            poolItem.gameObject.SetActive(false);

            poolItemList.Add(poolItem);

        }
    }

    public void DestroyObjects()
    {
        if (poolItemList == null) return;

        int count = poolItemList.Count;
        for (int i = 0; i< count; ++i)
        {
            GameObject.Destroy(poolItemList[i].gameObject);
        }

        poolItemList.Clear();
    }

    public GameObject ActivatePoolItem()
    {
        if (poolItemList == null) return null;

        if(maxCount == activeCount)
        {
            InstantiateObjects();
        }

        int count = poolItemList.Count;
        for ( int i = 0; i < count; ++ i )
        {
            PoolItem poolItem = poolItemList[i];

            if(poolItem.isActive == false)
            {
                activeCount++;

                poolItem.isActive = true;
                poolItem.gameObject.SetActive(true);

                return poolItem.gameObject;
            }
        }

        return null;
    }

    public void DeactivatePoolItem(GameObject removeObject)
    {
        if (poolItemList == null || removeObject == null) return;

        int count = poolItemList.Count;
        for ( int i = 0; i < count; ++ i)
        {
            PoolItem poolItem = poolItemList[i];

            if(poolItem.gameObject == removeObject)
            {
                activeCount--;

                poolItem.isActive = false;
                poolItem.gameObject.SetActive(false);

                return;
            }
        }
    }

    public void DeactivateAllPoolItems()
    {
        if (poolItemList == null) return;

        int count = poolItemList.Count;
        for(int i = 0; i < count; ++ i)
        {
            PoolItem poolItem = poolItemList[i];

            if( poolItem.gameObject != null && poolItem.isActive == true)
            {
                poolItem.isActive = false;
                poolItem.gameObject.SetActive(false);

            }
        }

        activeCount = 0;
    }
}
