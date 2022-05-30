using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    Transform target;
    Vector3 targetPos;

    [SerializeField]
    List<Transform> boundries;

    private void Awake()
    {
        targetPos = transform.position;
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

        if (targetPos.x < boundries[0].position.x)
            targetPos.x = boundries[0].position.x;

        if (targetPos.x > boundries[1].position.x)
            targetPos.x = boundries[1].position.x;

        transform.position = targetPos;
    }
}
