using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    public PlayerStatus playerStatus;
    private PlayerControls playerControls;
    public GameObject currentCheckpoint;
    public Rigidbody2D rBody;
    public PlayerInteraction playerInteraction;
    [SerializeField] int deathTime;
    GameSaveManager gameSaveManager;
    private int internalTimer;

    // Start is called before the first frame update
    void Start()
    {
        playerStatus = new PlayerStatus();
        playerStatus.level = SceneManager.GetActiveScene().buildIndex;
        playerControls = GetComponent<PlayerControls>();
        currentCheckpoint = GameObject.Find($"Checkpoint{playerStatus.checkpoint}");
        gameSaveManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameSaveManager>();
        rBody = GetComponent<Rigidbody2D>();
        playerInteraction = PlayerInteraction.Normal;
        internalTimer = 0;

        if (gameSaveManager.save != null)
        {
            LoadSave(gameSaveManager.save);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInteraction == PlayerInteraction.Dead)
        {
            DeathTimer();
        }
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
                        gameSaveManager.save = playerStatus;
                        gameSaveManager.SaveGame();
                    }
                    break;
                default:
                    break;
            }
        }
        if (collision.tag == "DeathZone" && playerInteraction == PlayerInteraction.Normal)
        {
            playerInteraction = PlayerInteraction.Dead;
            playerControls.enabled = false;
            rBody.velocity = Vector2.zero;
            rBody.AddForce(Vector2.up * 50, ForceMode2D.Impulse);
        }
    }
    public void CheckpointRespawn()
    {
        rBody.velocity = Vector2.zero;
        rBody.position = currentCheckpoint.transform.position;
        playerInteraction = PlayerInteraction.Normal;
        playerControls.enabled = true;
    }

    public void DeathTimer()
    {
        if (internalTimer >= deathTime)
        {
            internalTimer = 0;
            CheckpointRespawn();
        }
        internalTimer++;
    }

    public void LoadSave(PlayerStatus save)
    {
        playerStatus = save;
        currentCheckpoint = GameObject.Find($"Checkpoint{playerStatus.checkpoint}");
        CheckpointRespawn();
    }
}

public enum PlayerInteraction
{
    Normal,
    IFrames,
    Dead
}

public class PlayerStatus
{
    public int score;
    public int checkpoint;
    public int level;
    public int HP;
    public bool[] gems;
    public PlayerStatus(int score, int checkpoint, int level, int HP, bool[] gems)
    {
        this.score = score;
        this.checkpoint = checkpoint;
        this.level = level;
        this.HP = HP;
        this.gems = gems;
    }
    public PlayerStatus()
    {
        score = 0;
        checkpoint = 0;
        level = 0;
        HP = 0;
        gems = new bool[3] { false, false, false };
    }
}
