using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryEnd : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReturnToMenu()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameSceneManager>().menuType = MenuType.Normal;
        SceneManager.LoadScene(0);
    }
}
