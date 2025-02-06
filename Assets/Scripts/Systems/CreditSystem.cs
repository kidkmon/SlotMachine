using UnityEngine;
using UnityEngine.Events;

public class CreditSystem : Singleton<CreditSystem> {
    int _credits;
    int _betValue;

    [HideInInspector] public UnityEvent<int> OnCreditUpdated;

    public void Initialize()
    {
        _betValue = EnvironmentConfigs.Instance.GameConfig.BetValue;
        SetCredits(EnvironmentConfigs.Instance.GameConfig.InitialCredits);
    }

    public bool TryDeductBet() {
        if (_credits <= 0) return false;
        SetCredits(_credits - _betValue);
        return true;
    }
    void SetCredits(int value) {
        _credits = value;
        OnCreditUpdated?.Invoke(_credits);
    }

    public void AddCredits(int value) => SetCredits(_credits + value);

    public void Cashout()
    {
        SetCredits(EnvironmentConfigs.Instance.GameConfig.InitialCredits);
        //LogSystem.Instance.LogCashout(_credits);
    } 
}
