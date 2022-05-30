using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] GameObject WinScreen;
    [SerializeField] GameObject LoseScreen;

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

    public void ShowWinScreen()
    {
        WinScreen.SetActive(true);
    }

    public void ShowLoseScreen()
    {
        LoseScreen.SetActive(true);
    }
}
