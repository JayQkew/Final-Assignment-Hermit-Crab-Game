using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelProperties", menuName = "Game/Level Unlock Data")]
public class LevelProperties : ScriptableObject
{
    [SerializeField]
    private int maxUnlockedLevel = 1;

    public int MaxUnlockedLevel
    {
        get { return maxUnlockedLevel; }
    }

    public bool CanUnlockNextLevel(int currentLevel)
    {
        return currentLevel < maxUnlockedLevel;
    }

    public void UnlockNextLevel()
    {
        maxUnlockedLevel++;
    }

    public void ResetProgress()
    {
        maxUnlockedLevel = 1;
    }
}
