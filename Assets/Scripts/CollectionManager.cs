using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollectionManager
{
    public static List<LevelGems> Levels = new List<LevelGems>();
    public static void ResetLevels()
    {
        Levels.Clear();
        for (int levelIndex = 0; levelIndex < Levels.Count - 1; levelIndex++)
        {
            LevelGems newLevel = new LevelGems();
            newLevel.Gems = new bool[] {false, false, false};
        }
    }
}

public struct LevelGems
{
    public int Level;
    private bool[] gems;
    public bool[] Gems { get => gems; set => gems = value; }
}
