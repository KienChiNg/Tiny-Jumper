using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefs 
{
    public static int bestScore {
        set {
            if(PlayerPrefs.GetInt(PreCounts.BEST_SCORE,0) < value){
                PlayerPrefs.SetInt(PreCounts.BEST_SCORE, value);
            }
        }
        get => PlayerPrefs.GetInt(PreCounts.BEST_SCORE,0);
    }
    public static int sound {
        set => PlayerPrefs.SetInt(PreCounts.SOUND,value);
        get => PlayerPrefs.GetInt(PreCounts.SOUND,1);
    }
}
