using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    private PlayerStatus playerStatus;
    private GameSaveManager gameSaveManager;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        gameSaveManager = GetComponent<GameSaveManager>();
    }

    private void Start()
    {
        if(GameObject.FindGameObjectsWithTag("GameController").Length > 1)
        {
            Destroy(gameObject);
        }
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().playerStatus;
        }
    }

    private void Update()
    {
    }

    public void LoadMainMenu() => SceneManager.LoadScene(0);

    public void LoadLevelOne() => SceneManager.LoadScene(1);

    public void LoadLevelTwo() => SceneManager.LoadScene(2);

    public void LoadPlayerSave()
    {
        gameSaveManager.LoadSave();
        if (gameSaveManager.save != null)
        {
            switch (gameSaveManager.save.level)
            {
                case 1:
                    LoadLevelOne();
                    break;
                case 2:
                    LoadLevelTwo();
                    break;
                default:
                    break;
            }
        }
    }
}
