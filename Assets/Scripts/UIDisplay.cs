using TMPro;
using UnityEngine;

public class UIDisplay : MonoBehaviour
{
    TextMeshProUGUI tmp;
    PlayerBehavior player;
    [SerializeField] UIType type;
    [SerializeField] GameObject[] gemDisplays = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        switch(type)
        {
            case UIType.Score:
                tmp.text = $"Score: {player.playerStatus.score}";
                break;
            case UIType.HP:
                tmp.text = $"HP: {player.playerStatus.HP}";
                break;
            case UIType.Gems:
                break;
            default:
                break;
        }
    }
}

public enum UIType
{
    Score,
    HP,
    Gems
}
