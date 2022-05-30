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


    Animator anim;


    List<int> prevJumpCounts = new List<int>(); 

    private void Awake()
    {
        jumpText.text = totalJumps.ToString();
        startPos = transform.position;
        anim = GetComponentInChildren<Animator>();
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
        anim.SetBool("isDead", false);

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
        if (GameManager.instance.isTest)
            return true;

        currJumps--;
        jumpText.text = currJumps.ToString();
        return currJumps != 0;
    }
}
