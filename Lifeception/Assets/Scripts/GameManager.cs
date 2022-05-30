using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TarodevController;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    bool test;
    public bool isTest { get { return test; } }
    int currLvl = 1;
    int prevLvl;
    [SerializeField]
    int maxLvl = 5;
    [SerializeField]
    PlayerBehaviour player;
    CameraBehaviour cam;
    bool gameOver;

    public delegate void resetLevelState();
    public static event resetLevelState ResetLevelState;

    public delegate void changeLevel();
    public static event changeLevel ChangeLevel;

    private void Awake()
    {
        instance = this;
        cam = Camera.main.GetComponent<CameraBehaviour>();
        cam.SetTarget(player.transform);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(0);
    }

    public void PlayerDied()
    {
        if(currLvl == maxLvl)
        {
            GameOver();
        }
        else
        {
            //print("lock input");
            //player.GetComponent<PlayerController>().LockInput(true);
            prevLvl = currLvl;
            currLvl++;
            NextLvl();
        }
    }

    public void PlayerCompleted()
    {
        if (currLvl == 1)
        {
            GameCompleted();
        }
        else
        {
            //print("lock input");
            //player.GetComponent<PlayerController>().LockInput(true);
            prevLvl = currLvl;
            currLvl--;
            NextLvl();
        }
    }

    void NextLvl()
    {
        ChangeLevel();
        StartCoroutine(NextLvlTransitionDone());
        //Invoke("NextLvlTransitionDone", 1.5f);
        //NextLvlTransitionDone();
    }

    IEnumerator NextLvlTransitionDone()
    {
        yield return new WaitForSeconds(1.5f);
        ResetLevelState();
        LevelGenerator.instance.NextLvl(currLvl, prevLvl);
        player.Revive(prevLvl < currLvl);
        //print("unlock input");
        player.GetComponent<PlayerController>().LockInput(false);
    }

    void GameOver()
    {
        UIManager.instance.ShowLoseScreen();
        gameOver = true;
    }

    void GameCompleted()
    {
        UIManager.instance.ShowWinScreen();
    }
}
