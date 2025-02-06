using UnityEngine;
using UnityEngine.Events;

public class CreditSystem : Singleton<CreditSystem> {
    [HideInInspector] public UnityEvent<int> OnCreditUpdated;

    int _credits;
    int _betValue;

    public void Initialize()
    {
        _betValue = EnvironmentConfigs.Instance.GameConfig.BetValue;
        SetCredits(EnvironmentConfigs.Instance.GameConfig.InitialCredits);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            AddCredits(100);
        }
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

    public int Credits => _credits;
    public void AddCredits(int value) => SetCredits(_credits + value);

    public void Cashout()
    {
        Debug.Log("Cashout");
        SetCredits(EnvironmentConfigs.Instance.GameConfig.InitialCredits);
        //LogSystem.Instance.LogCashout(_credits);
    } 
}
