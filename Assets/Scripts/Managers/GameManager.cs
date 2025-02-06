using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager> {
    public UnityEvent OnSpinStarted;
    public UnityEvent OnSpinEnded;

    void Start() => CreditSystem.Instance.Initialize();

    public void StartSpin() {
        foreach (var slotMachine in SlotMachineManager.Instance.GetActiveSlotMachines()) {
            if (CreditSystem.Instance.TryDeductBet()) {
                JackpotSystem.Instance.AddToJackpot();

                // Check if a jackpot was triggered
                if (IsJackpotTriggered()) {
                    Debug.Log("Jackpot triggered!");
                    int jackpotValue = (int)JackpotSystem.Instance.GetCurrentJackpot();
                    CreditSystem.Instance.AddCredits(jackpotValue);
                    JackpotSystem.Instance.ResetJackpot();
                    //LogSystem.Instance.LogJackpotWon(jackpotValue);
                }

                slotMachine.SpinMachine();
            }
        }
    }
  
    bool IsJackpotTriggered() {  
        return Random.Range(0f, 1f) <= EnvironmentConfigs.Instance.GameConfig.JackpotChance;  
    }  
}
