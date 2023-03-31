using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    private PlayerBehavior playerBehavior;
    private GameSaveManager gameSaveManager;
    public int savedScore;
    private bool load;
    private bool carryingScore;
    public MenuType menuType = MenuType.Normal;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        gameSaveManager = GetComponent<GameSaveManager>();
        savedScore = 0;
        playerBehavior = null;
        load = false;
        carryingScore = false;
    }

    private void Start()
    {
        if(GameObject.FindGameObjectsWithTag("GameController").Length > 1)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0 && playerBehavior == null)
        {
            playerBehavior = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>();
        }
        if (load && playerBehavior != null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().LoadSave(gameSaveManager.save);
            load = false;
        }
        if (carryingScore && playerBehavior != null)
        {
            playerBehavior.playerStatus.score = savedScore;
            gameSaveManager.save = playerBehavior.playerStatus;
            gameSaveManager.SaveGame();
            carryingScore = false;
        }
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadScene(int sceneIndex, bool save)
    {
        if (playerBehavior != null && save)
        {
            carryingScore = true;
        }
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadScene(int sceneIndex, MenuType type)
    {
        savedScore = playerBehavior.playerStatus.score;
        SceneManager.LoadScene(sceneIndex);
        menuType = type;
    }

    public void LoadPlayerSave()
    {
        gameSaveManager.LoadSave();
        if (gameSaveManager.save != null)
        {
            switch (gameSaveManager.save.level)
            {
                case 1:
                    LoadScene(1, false);
                    break;
                case 2:
                    LoadScene(2, false);
                    break;
                default:
                    break;
            }
            load = true;
        }
    }
}

public enum MenuType
{
    Normal,
    Victory
}
