using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
    public int Value { get; }
    public int Collect();
    public CollectableType Type { get; }
}
public enum CollectableType
{
    None = 0,
    Money = 1,
    Key = 2,
    Gem = 4,
    Special = Money | Gem,
}