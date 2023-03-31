using System.IO;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    string savePath;
    public PlayerStatus save;

    // Start is called before the first frame update
    void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "pirateSave.txt");
    }

    // Update is called once per frame
    void Start()
    {
        save = null;
    }

    public void LoadSave()
    {
        if (File.Exists(savePath))
        {
            using (StreamReader sr = File.OpenText(savePath))
            {
                save = new PlayerStatus();
                string jsonSave = sr.ReadToEnd();
                JsonUtility.FromJsonOverwrite(jsonSave, save);
            }
        }
        else
        {
            save = null;
        }
    }

    public void SaveGame()
    {
        string jsonSave = JsonUtility.ToJson(save);
        using (StreamWriter sw = File.CreateText(savePath))
        {
            sw.WriteLine(jsonSave);
        }
    }

    public void RemoveSave()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
        }
    }
}
