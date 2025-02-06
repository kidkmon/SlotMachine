using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager> {

    [SerializeField] TextMeshProUGUI _creditText;

    void OnEnable() {  
        CreditSystem.Instance.OnCreditUpdated.AddListener(UpdateCreditsUI);
    }

    void OnDisable() {
        CreditSystem.Instance.OnCreditUpdated.RemoveListener(UpdateCreditsUI);
    }

    void UpdateCreditsUI(int credits) => _creditText.text = credits.ToString();
}  
