using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDisplay : MonoBehaviour
{
    TextMeshProUGUI tmp;
    PlayerBehavior player;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = $"Score = {player.playerStatus.score}";
    }
}

public enum UIType
{
    Score,
    HP,
    Gems
}
