using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene(targetIndex);
        }
    }
}
