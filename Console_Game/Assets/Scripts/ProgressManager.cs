using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ CreateAssetMenu (fileName = "Debug Progress")]
public class ProgressManager : ScriptableObject
{
    [Header("HUB")]
    //int that determines last level: 0=default 1=level 1, 2=level 2, 3=BOSS used for spawn point 
    public int lastLevel;

    [Header("Level 1")]
    public bool level1Complete;

    [Header("Level 2")]
    public bool level2Complete;
    public int coins;
}
