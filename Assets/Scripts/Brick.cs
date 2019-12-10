using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
    public AudioClip pop;
    private LevelManager levelmanager;
    public static int breakableBrick;
    private int timesHit;
    public Sprite[] hitSprites;
    private bool isBreakable;
    

    void OnLevelWasLoaded()
    {
        breakableBrick = 0;
    }

    // Use this for initialization
    void Start()
    {
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            breakableBrick++;
            print(breakableBrick);
        }
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(pop, transform.position);
        if (isBreakable)
        {
            hitHandler();
        }
    }

    void hitHandler()
    {
        int maxHits;
        timesHit++;
        maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableBrick--;
            print(breakableBrick);
            levelmanager.brickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            loadSprite();
        }
    }

    void loadSprite()
    {
        int spriteCount = timesHit - 1;
        if (hitSprites[spriteCount])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteCount];
        }
        else
        {
            Debug.LogError("Missing Brick Sprite!!");
        }

    }

}