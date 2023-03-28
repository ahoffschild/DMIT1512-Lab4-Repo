using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public PlayerStatus playerStatus;
    public GameObject currentCheckpoint;
    
    // Start is called before the first frame update
    void Start()
    {
        playerStatus = new PlayerStatus();
        currentCheckpoint = GameObject.Find($"Checkpoint{playerStatus.checkpoint}");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerStatus.score);
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
                    if (!collision.GetComponent<CheckpointBehavior>().Collected)
                    {
                        playerStatus.checkpoint = collectable.Collect();
                        currentCheckpoint = GameObject.Find($"Checkpoint{playerStatus.checkpoint}");
                    }
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
    public bool[] gems { get; set; }
    public PlayerStatus()
    {
        score = 0;
        checkpoint = 0;
        level = 0;
        HP = 0;
        gems = new bool[3] { false, false, false };
    }
}
