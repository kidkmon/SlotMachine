using UnityEngine;

[CreateAssetMenu]  
public class GameConfig : ScriptableObject {  
    
    [Header("Reel Settings")]
    [SerializeField] int _reelsCount = 3;
    [SerializeField] int _symbolsPerReel = 3;
    [SerializeField] float _reelSpinDuration = 1.0f;

    [Header("Game Settings")]
    [SerializeField] int _betValue = 1;
    [SerializeField] int _initialCredits = 100;

    [Header("Jackpot Settings")]
    [SerializeField] int _jackpotDefaultValue = 300;
    [SerializeField] float _jackpotIncrementMultiplier = 0.01f;

    [Tooltip("Chance of winning the jackpot, 1/200 by default")]
    [SerializeField] float _jackpotChance = 0.005f;

    public int ReelsCount => _reelsCount;
    public int SymbolsPerReel => _symbolsPerReel;
    public float ReelSpinDuration => _reelSpinDuration;

    public int BetValue => _betValue;
    public int InitialCredits => _initialCredits;

    public int JackpotDefaultValue => _jackpotDefaultValue;
    public float JackpotIncrementMultiplier => _jackpotIncrementMultiplier;
    public float JackpotChance => _jackpotChance;
}  