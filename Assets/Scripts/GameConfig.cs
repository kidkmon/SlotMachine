using UnityEngine;

[CreateAssetMenu]  
public class GameConfig : ScriptableObject {  
    
    [Header("Reel Settings")]
    public int ReelCount = 3;
    public int SymbolsPerReel = 3;
    public float ReelSpinDuration = 1.0f;

    [Header("Game Settings")]
    public float JackpotChance = 0.005f; // 1/200
    public int InitialCredits = 100;
}  