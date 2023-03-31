using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIEndDisplay : MonoBehaviour
{
    GameSceneManager gameSceneManager;
    TextMeshProUGUI textMeshProUGUI;
    [SerializeField] bool isButton;

    private void Start()
    {
        gameSceneManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameSceneManager>();
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (!isButton)
        {
            textMeshProUGUI.text = $"Your score was: {gameSceneManager.savedScore}";
        }
    }
}
