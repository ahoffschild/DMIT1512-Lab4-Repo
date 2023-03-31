using TMPro;
using UnityEngine;

public class SaveFileDisplay : MonoBehaviour
{
    [SerializeField] GameObject levelDisplay;
    [SerializeField] GameObject checkpointDisplay;
    [SerializeField] GameObject scoreDisplay;
    GameSaveManager gameSaveManager;
    bool loaded;

    // Start is called before the first frame update
    void Start()
    {
        gameSaveManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameSaveManager>();
        loaded = false;
    }

    private void Update()
    {
        if (!loaded)
        {
            gameSaveManager.LoadSave();
            loaded = true;
        }
        else
        {
            if (gameSaveManager.save == null)
            {
                gameObject.SetActive(false);
            }
            else
            {
                levelDisplay.GetComponent<TextMeshProUGUI>().text = $"Level: {gameSaveManager.save.level}";
                checkpointDisplay.GetComponent<TextMeshProUGUI>().text = $"Checkpoint: {gameSaveManager.save.checkpoint}";
                scoreDisplay.GetComponent<TextMeshProUGUI>().text = $"Score: {gameSaveManager.save.score}";
            }
        }
    }
}
