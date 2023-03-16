using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour, ICollectable
{
    public int Value => 1;
    public CollectableType Type => CollectableType.Money;
    private SpriteRenderer spriteRenderer;

    public int Collect()
    {
        spriteRenderer.enabled = false;
        return Value;
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
