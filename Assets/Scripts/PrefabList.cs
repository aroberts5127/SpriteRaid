using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabList : MonoBehaviour
{
    public static PrefabList instance;

    [SerializeField] private List<GameObject> prefabList;
    [SerializeField] private List<GameObject> prefabListRight;
    private int curItem;
    private int curItemRight;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
        {
            instance = this;
        }
        curItem = 0;
        curItemRight = 0;
    }

    public GameObject GetNextPrefab()
    {
        if(curItem < prefabList.Count-1)
            curItem++;
        else
        {
            curItem = 0;
        }
        return prefabList[curItem];
    }

    public GameObject GetRandomPrefab()
    {
        int r = Random.Range(0, prefabList.Count);
        return prefabList[r];
    }

    public GameObject GetNextPrefabRight()
    {
        if (curItemRight < prefabListRight.Count - 1)
            curItemRight++;
        else
        {
            curItemRight = 0;
        }
        return prefabListRight[curItemRight];
    }

    public GameObject GetRandomPrefabRight()
    {
        int r = Random.Range(0, prefabListRight.Count);
        return prefabListRight[r];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
