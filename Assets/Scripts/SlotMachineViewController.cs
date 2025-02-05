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
        // Spin all reels
        foreach (var reelColumnView in View.ReelColumnViews)
        {
           reelColumnView.SpinButtonClicked();
        }

        //Check if center symbols are the same
        Debug.Log(CheckCenterSymbols());
    }

    bool CheckCenterSymbols()
    {
        if (View.ReelColumnViews.Count == 0) return false;

        var centerSymbol = View.ReelColumnViews[0].GetCenterSymbolConfig();
        for (int i = 1; i < View.ReelColumnViews.Count; i++)
        {
            var symbolConfig = View.ReelColumnViews[i].GetCenterSymbolConfig();
            if (centerSymbol.IsWild && !symbolConfig.IsWild)
            {
                centerSymbol = symbolConfig;
            }
            
            if (symbolConfig.Id != centerSymbol.Id && !symbolConfig.IsWild)
            {
                return false;
            }
        }

        return true;
    }

    void OnPrizeButtonClicked()
    {
        foreach (var reelColumnView in View.ReelColumnViews)
        {
            Debug.Log("Center symbol: " + reelColumnView.GetCenterSymbolConfig().Id);
        }
    }
}