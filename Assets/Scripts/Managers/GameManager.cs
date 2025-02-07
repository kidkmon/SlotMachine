using System.Collections;
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
                if (IsJackpotTriggered())
                {
                    StartCoroutine(PlayJackpot());
                    return;
                }

                slotMachine.SpinMachine();
            }
        }
    }

    IEnumerator PlayJackpot()
    {
        int jackpotValue = (int)JackpotSystem.Instance.GetCurrentJackpot();
        AudioManager.Instance.PlayJackpotSound();
        CreditSystem.Instance.AddCredits(jackpotValue);
        LogSystem.Instance.LogJackpotWin(jackpotValue);
        yield return new WaitForSeconds(3f);
        JackpotSystem.Instance.ResetJackpot();
    }

    bool IsJackpotTriggered() => Random.Range(0f, 1f) <= EnvironmentConfigs.Instance.GameConfig.JackpotChance;
}
