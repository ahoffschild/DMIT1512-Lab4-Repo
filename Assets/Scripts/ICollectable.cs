using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
    public int value { get; set; }
    public bool Collect();
}
