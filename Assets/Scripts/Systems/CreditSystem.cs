using UnityEngine;
using UnityEngine.Events;

public class CreditSystem : Singleton<CreditSystem> {
    [HideInInspector] public UnityEvent<int> OnCreditUpdated;

    int _betValue;
    int _credits;
    int _insertedCredits;

    public void Initialize()
    {
        _betValue = EnvironmentConfigs.Instance.GameConfig.BetValue;
        _insertedCredits = EnvironmentConfigs.Instance.GameConfig.InsertedCredits;
        SetCredits(EnvironmentConfigs.Instance.GameConfig.InitialCredits);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            AddCredits(_insertedCredits);
            Logger.Instance.LogCreditInsertion(_insertedCredits);
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
        SetCredits(0);
        Logger.Instance.LogCashout(_credits);
    } 
}
