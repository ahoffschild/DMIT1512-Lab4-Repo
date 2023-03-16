using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.GetComponent<ICollectable>() != null)
        {
            ICollectable collectable = collision.GetComponent<ICollectable>();
            switch (collectable.Type)
            {
                case CollectableType.None:
                    break;
                case CollectableType.Money:
                    collectable.Collect();
                    break;
                case CollectableType.Key:
                    break;
                case CollectableType.Gem:
                    break;
                default:
                    break;
            }
        }
    }
}
