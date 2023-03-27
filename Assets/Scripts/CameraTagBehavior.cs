using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTagBehavior : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] int transitionTime;
    [SerializeField] float newSize;
    int internalTimer;
    float increase;
    float oldSize;
    bool transition;
    // Start is called before the first frame update
    void Start()
    {
        transition = false;
        internalTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transition)
        {
            CameraTransition();
        }
    }

    void CameraTransition()
    {
		internalTimer++;
		mainCamera.orthographicSize = oldSize + increase * ((float)internalTimer / (float)transitionTime);
		if (internalTimer >= transitionTime)
        {
            mainCamera.orthographicSize = newSize;
            internalTimer = 0;
            transition = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!transition && newSize != mainCamera.orthographicSize)
        {
            oldSize = mainCamera.orthographicSize;
            increase = newSize - oldSize;
            transition = true;
        }
    }
}
