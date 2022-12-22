using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimationDriver : MonoBehaviour
{
    public List<Sprite> spriteList;
    private WaitForSecondsRealtime waitTime;
    private int spriteIndex;
    private SpriteRenderer spriteRender;
    // Start is called before the first frame update
    void Start()
    {
        if (spriteRender == null) spriteRender = this.GetComponent<SpriteRenderer>();
        float resetRate = 1.0f / 8.0f;
        waitTime = new WaitForSecondsRealtime(resetRate);
        StartCoroutine(CycleAnimationsRoutine());
    }

    private IEnumerator CycleAnimationsRoutine()
    {
        while (true)
        {
            if(spriteIndex == spriteList.Count)
                spriteIndex = 0;
            spriteRender.sprite = spriteList[spriteIndex];
            yield return waitTime;
            spriteIndex++;
        }
    }
}
