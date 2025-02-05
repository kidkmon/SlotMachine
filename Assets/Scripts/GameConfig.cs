using UnityEngine;

[CreateAssetMenu]  
public class GameConfig : ScriptableObject {  
    
    [Header("Reel Settings")]
    [SerializeField] int _reelsCount = 3;
    [SerializeField] int _symbolsPerReel = 3;
    [SerializeField] float _reelSpinDuration = 1.0f;

    [Header("Game Settings")]
    [SerializeField] float _jackpotChance = 0.005f; // 1/200
    [SerializeField] int _initialCredits = 100;

    public int ReelsCount => _reelsCount;
    public int SymbolsPerReel => _symbolsPerReel;
    public float ReelSpinDuration => _reelSpinDuration;
    public float JackpotChance => _jackpotChance;
    public int InitialCredits => _initialCredits;
}  