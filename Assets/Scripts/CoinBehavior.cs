using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour, ICollectable
{
    public bool Collected = false;
    public int Value => 5;
    public CollectableType Type => CollectableType.Money;
    private SpriteRenderer spriteRenderer;

    public int Collect()
    {
        if (Collected)
        {
            return 0;
        }
        else
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.3f);
            Collected = true;
            return Value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
