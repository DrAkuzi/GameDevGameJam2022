using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    int totalJumps = 5;
    int currJumps;

    Vector3 startPos;
    //float scale;

    [SerializeField]
    Text jumpText;


    List<int> prevJumpCounts = new List<int>(); 

    private void Awake()
    {
        jumpText.text = totalJumps.ToString();
        startPos = transform.position;
        //SavePos(0);
        //scale = transform.localScale.x;
        currJumps = totalJumps;
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
        //lastPos.x += (x < 0) ? scale : (x == 0) ? 0 : -scale;
        //lastPos = transform.position;
    }

    public void Revive(bool resetJump)
    {
        transform.position = startPos;

        if (resetJump)
        {
            prevJumpCounts.Add(currJumps);
            currJumps = totalJumps;
            jumpText.text = currJumps.ToString();
        }
        else
        {
            currJumps += prevJumpCounts[prevJumpCounts.Count - 1];
            prevJumpCounts.RemoveAt(prevJumpCounts.Count - 1);
            jumpText.text = currJumps.ToString();
        }
    }

    public void Die()
    {
        
    }

    public void AddJumpCount(int j)
    {
        currJumps += j;
        jumpText.text = currJumps.ToString();
    }

    public bool UpdateJump()
    {
        currJumps--;
        jumpText.text = currJumps.ToString();
        return currJumps != 0;
    }
}
