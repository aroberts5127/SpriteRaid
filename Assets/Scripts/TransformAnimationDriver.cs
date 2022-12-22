using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformAnimationDriver : MonoBehaviour
{
    private Transform transform;
    public float lifeTime;
    private WaitForSecondsRealtime waitTime;
    private float resetTime;
    [SerializeField] private float moveSpeed;
    private float curTime;
    [SerializeField] bool goingRight;
    // Start is called before the first frame update
    void Start()
    {
        if(transform == null)
        {
            transform = GetComponent<Transform>();
        }
        resetTime = 1.0f / 8.0f;
        waitTime = new WaitForSecondsRealtime(resetTime);
        StartCoroutine(MoveAcrossScreenRoutine());
        if (goingRight)
            moveSpeed = moveSpeed * -1;
    }

    private void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * moveSpeed;
    }

    private IEnumerator MoveAcrossScreenRoutine()
    {
        curTime = 0;
        while(curTime < lifeTime)
        {
            yield return waitTime;
            curTime += resetTime;
        }
        Destroy(this.gameObject);
    }
}
