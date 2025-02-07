using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager> {
    public UnityEvent OnSpinStarted;
    public UnityEvent OnSpinEnded;

    void Start() => CreditSystem.Instance.Initialize();

    public void StartSpin() {
        foreach (var slotMachine in SlotMachineManager.Instance.GetActiveSlotMachines()) {
            if (CreditSystem.Instance.TryDeductBet()) {
                Logger.Instance.LogSpinStart(EnvironmentConfigs.Instance.GameConfig.BetValue);

                JackpotSystem.Instance.AddToJackpot();

                // Check if a jackpot was triggered
                if (IsJackpotTriggered()) {
                    int jackpotValue = (int)JackpotSystem.Instance.GetCurrentJackpot();
                    CreditSystem.Instance.AddCredits(jackpotValue);
                    JackpotSystem.Instance.ResetJackpot();
                    Logger.Instance.LogJackpotWin(jackpotValue);
                }

                slotMachine.SpinMachine();
            }
        }
    }
  
    bool IsJackpotTriggered() {  
        return Random.Range(0f, 1f) <= EnvironmentConfigs.Instance.GameConfig.JackpotChance;  
    }  
}
