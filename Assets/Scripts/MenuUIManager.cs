using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    GameSceneManager gameSceneManager;
    [SerializeField] GameObject[] gameObjects;

    // Update is called once per frame
    private void Start()
    {
        gameSceneManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameSceneManager>();
        foreach (GameObject go in gameObjects)
        {
            go.SetActive(false);
        }
        switch (gameSceneManager.menuType)
        {
            case MenuType.Normal:
                gameObjects[0].SetActive(true);
                break;
            case MenuType.Victory:
                gameObjects[1].SetActive(true);
                break;
        }
    }
}
