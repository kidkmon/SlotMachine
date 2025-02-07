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
        if (Input.GetKeyDown(KeyCode.Space)) { // Simulate coin insertion
            AddCredits(_insertedCredits);
            LogSystem.Instance.LogCreditInsertion(_insertedCredits);
        }
    }

    void SetCredits(int value) {
        _credits = value;
        OnCreditUpdated?.Invoke(_credits);
    }

    #region Public Methods

    public int Credits => _credits;
    public void AddCredits(int value) => SetCredits(_credits + value);

    public bool TryDeductBet() {
        if (_credits <= 0) return false;
        SetCredits(_credits - _betValue);
        return true;
    }

    public void Cashout()
    {
        SetCredits(0);
        LogSystem.Instance.LogCashout(_credits);
    }

    #endregion
}
