using UnityEngine;
using UnityEngine.InputSystem;

public class GoalManager : MonoBehaviour
{
    [SerializeField] GameObject VictoryMessage;
    PlayerInput internalInput;
    [SerializeField] int targetIndex;

    private void Start()
    {
        VictoryMessage.SetActive(false);
        internalInput = GetComponent<PlayerInput>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>().enabled = false;
        VictoryMessage.SetActive(true);
        internalInput.enabled = true;
    }

    public void Continue(InputAction.CallbackContext context)
    {
        if (context.action.WasPerformedThisFrame())
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameSceneManager>().LoadScene(targetIndex);
        }
    }

    public void GoToMenu(InputAction.CallbackContext context)
    {
        if (context.action.WasPerformedThisFrame())
        {
            MenuType type = MenuType.Victory;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameSceneManager>().LoadScene(targetIndex, type);
        }
    }
}
