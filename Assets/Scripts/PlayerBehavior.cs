using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public PlayerStatus playerStatus;
    
    // Start is called before the first frame update
    void Start()
    {
        playerStatus = new PlayerStatus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.GetComponent<ICollectable>() != null)
        {
            ICollectable collectable = collision.GetComponent<ICollectable>();
            switch (collectable.Type)
            {
                case CollectableType.None:
                    break;
                case CollectableType.Money:
                    playerStatus.score += collectable.Collect();
                    break;
                case CollectableType.Key:
                    break;
                case CollectableType.Gem:
                    break;
                case CollectableType.Checkpoint:
                    playerStatus.checkpoint = collectable.Collect();
                    break;
                default:
                    break;
            }
        }
    }
}

public class PlayerStatus
{
    public int score { get; set; }
    public int checkpoint { get; set; }
    public int level { get; set; }
    public int HP { get; set; }

    public PlayerStatus()
    {
        score = 0;
        checkpoint = 0;
        level = 0;
        HP = 0;
    }
}
