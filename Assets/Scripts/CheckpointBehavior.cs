using UnityEngine;

public class CheckpointBehavior : MonoBehaviour, ICollectable
{
    public bool Collected = false;
    public int Value => 0;
    public CollectableType Type => CollectableType.Checkpoint;
    private SpriteRenderer spriteRenderer;

    [SerializeField] int checkpointID;

    public int Collect()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.3f);
        Collected = true;
        return checkpointID;
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
