using UnityEngine;

public class GameManager : Singleton<GameManager> {

    void Start() => CreditSystem.Instance.Initialize();

    public void StartSpin() {
        foreach (var slotMachine in SlotMachineManager.Instance.GetActiveSlotMachines()) {
            if (slotMachine.IsSpinning) return; // Prevent multiple spins

            if (CreditSystem.Instance.TryDeductBet()) {
                LogSystem.Instance.LogSpinStart(EnvironmentConfigs.Instance.GameConfig.BetValue);

                JackpotSystem.Instance.AddToJackpot();

                // Check if a jackpot was triggered
                if (IsJackpotTriggered()) {
                    int jackpotValue = (int)JackpotSystem.Instance.GetCurrentJackpot();
                    CreditSystem.Instance.AddCredits(jackpotValue);
                    JackpotSystem.Instance.ResetJackpot();
                    LogSystem.Instance.LogJackpotWin(jackpotValue);
                }

                slotMachine.SpinMachine();
            }
        }
    }
  
    bool IsJackpotTriggered() {  
        return Random.Range(0f, 1f) <= EnvironmentConfigs.Instance.GameConfig.JackpotChance;
    }  
}
