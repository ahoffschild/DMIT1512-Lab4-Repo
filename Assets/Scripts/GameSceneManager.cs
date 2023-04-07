using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    private PlayerBehavior playerBehavior;
    private GameSaveManager gameSaveManager;
    public int? savedScore;
    private bool load;
    public MenuType menuType = MenuType.Normal;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        gameSaveManager = GetComponent<GameSaveManager>();
        savedScore = 0;
        playerBehavior = null;
        savedScore = null;
        load = false;
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
            Debug.Log(gameSaveManager.save.score);
            Debug.Log(savedScore);
            load = false;
        }
        if (savedScore != null && playerBehavior != null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().playerStatus.score = (int)savedScore;
            savedScore = null;
        }
    }

    public void LoadScene(int sceneIndex)
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            savedScore = playerBehavior.playerStatus.score;
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }

    public void LoadSaveScene(int sceneIndex)
    {
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
                    LoadSaveScene(1);
                    break;
                case 2:
                    LoadSaveScene(2);
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
