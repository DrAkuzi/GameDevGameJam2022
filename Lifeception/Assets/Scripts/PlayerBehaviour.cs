using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    Vector3 lastPos;
    float scale;
    private void Awake()
    {
        SavePos(0);
        scale = transform.localScale.x;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePos(float x)
    {
        lastPos.x += (x < 0) ? scale : (x == 0) ? 0 : -scale;
        lastPos = transform.position;
    }

    public void Revive()
    {
        transform.position = lastPos;
    }
}
