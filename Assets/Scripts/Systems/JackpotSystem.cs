using UnityEngine;
using UnityEngine.Events;

public class JackpotSystem : Singleton<JackpotSystem> {
    [HideInInspector] public UnityEvent<float> OnJackpotUpdated;

    float _jackpotValue;
    float _incrementValue;

    void Start()
    {
        _incrementValue = EnvironmentConfigs.Instance.GameConfig.BetValue * EnvironmentConfigs.Instance.GameConfig.JackpotIncrementMultiplier;
        ResetJackpot();
    }

    public void AddToJackpot() {
        _jackpotValue += _incrementValue;
        OnJackpotUpdated?.Invoke(_jackpotValue);
    }

    public void ResetJackpot() {
        _jackpotValue = EnvironmentConfigs.Instance.GameConfig.JackpotDefaultValue;
        OnJackpotUpdated?.Invoke(_jackpotValue);
    }

    public float GetCurrentJackpot() => _jackpotValue;  
}