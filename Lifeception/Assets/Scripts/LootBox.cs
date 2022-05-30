using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LootBox : MonoBehaviour
{
    [SerializeField]
    int JumpCount;
    [SerializeField]
    Text CountText;

    SpriteRenderer sprite;
    Collider2D col;


    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        CountText.text = JumpCount.ToString();
    }

    private void OnEnable()
    {
        GameManager.ResetLevelState += ResetState;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetJumpCount()
    {
        sprite.enabled = 
        col.enabled = 
        CountText.enabled = false;
        return JumpCount;
    }

    void ResetState()
    {
        sprite.enabled =
        col.enabled =
        CountText.enabled = true;
    }

    private void OnDisable()
    {
        GameManager.ResetLevelState -= ResetState;
    }
}
