using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;

    [SerializeField]
    List<Transform> levelList = new List<Transform>();
    Vector3 tempPos = new Vector3(-1000f, 0, 0);

    private void Awake()
    {
        instance = this;    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLvl(int currLvl, int prevLvl)
    {
        //safety check
        if (currLvl >= levelList.Count + 1) 
            return;
        
        levelList[currLvl - 1].position = Vector3.zero;
        levelList[prevLvl - 1].position = tempPos;
        //return levelStartPos[lvl - 1].position;
    }
}
