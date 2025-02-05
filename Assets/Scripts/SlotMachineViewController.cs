using UnityEngine;

public class SlotMachineViewController : ViewController<SlotMachineView>
{
    protected override void OnInitialized()
    {
        for (int i = 0; i < EnvironmentConfigs.Instance.GameConfig.ReelsCount; i++)
        {
            View.AddReelColumnView();
        }
    }

    protected override void SetupEventHandlers()
    {
        View.SpinButton.onClick.AddListener(OnSpinButtonClicked);
        View.PrizeButton.onClick.AddListener(OnPrizeButtonClicked);
    }
    protected override void RemoveEventHandlers()
    {
        View.SpinButton.onClick.RemoveListener(OnSpinButtonClicked);
        View.PrizeButton.onClick.RemoveListener(OnPrizeButtonClicked);
    }

    void OnSpinButtonClicked()
    {
        foreach (var reelColumnView in View.ReelColumnViews)
        {
           reelColumnView.SpinButtonClicked();
        }
    }

    void OnPrizeButtonClicked()
    {
        foreach (var reelColumnView in View.ReelColumnViews)
        {
            Debug.Log("Center symbol: " + reelColumnView.GetCenterSymbolConfig().Id);
        }
    }
}