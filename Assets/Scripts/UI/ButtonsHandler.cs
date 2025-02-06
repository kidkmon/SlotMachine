using UnityEngine;

public class ButtonsHandler : MonoBehaviour
{
    public void OnSpinClicked() => GameManager.Instance.StartSpin();  
    public void OnCashoutClicked() => CreditSystem.Instance.Cashout();  
}
