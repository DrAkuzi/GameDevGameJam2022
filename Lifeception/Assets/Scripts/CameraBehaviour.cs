using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    Transform target;
    Vector3 targetPos;

    [SerializeField]
    List<Transform> boundries;
    Vector2 screenBoundries;

    private void Awake()
    {
        targetPos = transform.position;
        //this willl give negative value which we can treat as min values
        screenBoundries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));
        //screenBoundries *= -1;
        print(screenBoundries);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }

    public void SetTarget(Transform t)
    {
        target = t;
    }

    void FollowTarget()
    {
        targetPos.x = target.position.x;

        if (targetPos.x < boundries[0].position.x + screenBoundries.x)
            targetPos.x = boundries[0].position.x + screenBoundries.x;

        if (targetPos.x > boundries[1].position.x - screenBoundries.x)
            targetPos.x = boundries[1].position.x - screenBoundries.x;

        transform.position = targetPos;
    }
}
