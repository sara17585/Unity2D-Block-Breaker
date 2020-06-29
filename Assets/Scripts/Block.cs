using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparleFX;
   // [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprits;
    //Cached reference
    Level level;
    GameStatus score;

    //state variables
    [SerializeField] int timesHit; //TODO only for debug purposes;

    private void Start()
    {
        score = FindObjectOfType<GameStatus>();
        CountBreakableBlocks();

    }

    private void CountBreakableBlocks()
    {
        //level = FindObjectOfType<Level>();

        level = GameObject.Find("Level").GetComponent<Level>();
        if (tag == "Breakable")

        {
            level.CountBreakableBlocks();

        }
    }

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (tag == "Breakable")
        {
            HandleHits();
        }
    }

    private void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprits.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            showNextHitSpritse();
        }
    }

    private void showNextHitSpritse()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprits[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprits[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite"+gameObject+ "is missing from array!");
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
      
        
            OnSparkles();
            Destroy(gameObject);
            level.CountBrokenBlocks();
            score.AddToScore();
        
    }


    private void OnSparkles()
    {
        GameObject sparkle= Instantiate(blockSparleFX,transform.position, transform.rotation);
        Destroy(sparkle, .1f);
    }
}
