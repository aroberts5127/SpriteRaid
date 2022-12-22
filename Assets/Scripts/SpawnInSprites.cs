using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInSprites : MonoBehaviour
{

    [SerializeField] List<Transform> spawnLocations;
    [SerializeField] List<Transform> spawnRightLocations;
    [SerializeField] float spawnLifeTime;
    [SerializeField] float spawnDelayTimeMax = 2.0f;
    int spawnLocIndex;
    int spawnLocIndexRight;
    // Start is called before the first frame update
    void Start()
    {
        if (spawnLocations == null || spawnLocations.Count == 0)
        {
            Debug.LogError("Something Went Wrong in SpawnInSprites.cs");
            return;
        }
        spawnLocIndex = 0;
        spawnLocIndexRight = 0;
        StartCoroutine(SpawnImagesRoutine());
        StartCoroutine(SpawnImagesRoutineRight());
    }

    private IEnumerator SpawnImagesRoutine()
    {
        int spawnInc = 0;
        while (true)
        {
            if (spawnLocIndex >= spawnLocations.Count - 1)
            {
                spawnInc = -1;
            }
            if(spawnLocIndex == 0)
            {
                spawnInc = 1;
            }
            SpawnObj();
            spawnLocIndex += spawnInc;
            yield return new WaitForSeconds(Random.Range(0.25f, spawnDelayTimeMax));
        }
        
    }
    private IEnumerator SpawnImagesRoutineRight()
    {
        int spawnInc = 0;
        while (true)
        {
            if (spawnLocIndexRight >= spawnRightLocations.Count - 1)
            {
                spawnInc = -1;
            }
            if (spawnLocIndexRight == 0)
            {
                spawnInc = 1;
            }
            SpawnObjRight();
            spawnLocIndexRight += spawnInc;
            yield return new WaitForSeconds(Random.Range(0.25f, spawnDelayTimeMax));
        }

    }

    private void SpawnObj()
    {
        GameObject obj = GameObject.Instantiate(PrefabList.instance.GetNextPrefab(), this.transform);
        obj.transform.position = spawnLocations[spawnLocIndex].position;
    }

    private void SpawnObjRight()
    {
        GameObject obj = GameObject.Instantiate(PrefabList.instance.GetNextPrefabRight(), this.transform);
        obj.transform.position = spawnRightLocations[spawnLocIndexRight].position;
    }

}
