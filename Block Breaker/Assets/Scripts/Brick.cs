using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public Sprite[] hitSprite;
    public AudioClip crack;
    public GameObject smoke;
    public ParticleSystem ps;

    private LevelManager levelManager;
    public static int breakableCount = 0;
    private int maxHit;
    private int timesHit;

    public bool isBreakable = false;


    void Start()
    {
        isBreakable = (this.CompareTag("Breakable"));
        if(isBreakable) { breakableCount++; }
        Debug.Log(breakableCount);
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;
    }
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isBreakable) {
            AudioSource.PlayClipAtPoint(crack, transform.position);
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        maxHit = hitSprite.Length + 1;
        if (timesHit >= maxHit)
        {
            breakableCount--;
            Debug.Log(breakableCount);
            levelManager.BrickDestroyed();
            GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
            smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color; 
            
            Destroy(gameObject);
        }
        else
        {
            loadSprite();
        }
    }

    void loadSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprite[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprite[spriteIndex];
        }
    }

    // TODO Simulate Win when all bricks destroyed
    void SimulateWin()
    {
        levelManager.LoadNextLevel(); 

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
