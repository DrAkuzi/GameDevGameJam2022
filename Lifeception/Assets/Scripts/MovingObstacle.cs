using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField]
    Transform endpoint;
    [SerializeField]
    float speed;
    [SerializeField]
    float pauseDuration;

    Vector3 endpos;
    Vector3 startpos;
    bool moveBack;
    Vector3 targetpos;
    float lerpDuration;

    Coroutine coroutine;

    private void Awake()
    {
        
        targetpos = endpos = endpoint.parent.parent.InverseTransformPoint(endpoint.position);
        startpos = transform.localPosition;

        lerpDuration = Vector3.Distance(startpos, endpos) / speed;
    }
    private void OnEnable()
    {
        //may change this in the future instead of using local position since its not efficient when the game scales up
        //instead of using game manager to check state, each level shld have its own state as well. 
        GameManager.ResetLevelState += ResetState;
        GameManager.ChangeLevel += StopMove;
    }

    // Start is called before the first frame update
    void Start()
    {
        coroutine = StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Move()
    {
        float timeElapsed = 0;
        Vector3 initpos = moveBack ? endpos : startpos;
        while (timeElapsed < lerpDuration)
        {
            transform.localPosition = Vector3.Lerp(initpos, targetpos, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = targetpos;
        moveBack = !moveBack;
        targetpos = moveBack ? startpos : endpos;
        yield return new WaitForSeconds(pauseDuration);
        coroutine = StartCoroutine(Move());
    }

    void ResetState()
    {
        transform.localPosition = startpos;
        moveBack = false;
        targetpos = endpos;
        coroutine = StartCoroutine(Move());
    }

    void StopMove()
    {
        StopCoroutine(coroutine);
    }

    private void OnDisable()
    {
        GameManager.ResetLevelState -= ResetState;
        GameManager.ChangeLevel -= StopMove;
    }
}
