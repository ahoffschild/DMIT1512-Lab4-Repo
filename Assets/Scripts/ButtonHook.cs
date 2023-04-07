using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHook : MonoBehaviour
{
    GameSceneManager gameSceneManager;
    GameSaveManager gameSaveManager;
    // Start is called before the first frame update
    void Start()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        gameSceneManager = controller.GetComponent<GameSceneManager>();
        gameSaveManager = controller.GetComponent <GameSaveManager>();
    }

    public void StartGame()
    {
        gameSceneManager.savedScore = 0;
        gameSceneManager.LoadScene(1);
    }

    public void LoadGame() => gameSceneManager.LoadPlayerSave();

    public void DeleteGame() => gameSaveManager.RemoveSave();
}
