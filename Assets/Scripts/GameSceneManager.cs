using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    private PlayerStatus playerStatus;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if(GameObject.FindGameObjectsWithTag("Manager").Length > 1)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (playerStatus == null)
        {
            playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().playerStatus;
        }
    }

    public void LoadMainMenu() => SceneManager.LoadScene(0);

    public void LoadLevelOne() => SceneManager.LoadScene(1);

    public void LoadLevelTwo() => SceneManager.LoadScene(2);
}
