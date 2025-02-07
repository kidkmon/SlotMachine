
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
        View.OnSpinButtonClicked += OnSpinButtonClicked;
    }
    protected override void RemoveEventHandlers()
    {
        View.OnSpinButtonClicked -= OnSpinButtonClicked;
    }

    void OnSpinButtonClicked()
    {
        //Check if center symbols are the same
        var (isCenterSymbolsMatch, symbolConfig) = CheckCenterSymbols();
        if(isCenterSymbolsMatch)
        {
            GivePrizeReward(symbolConfig);
        }
    }

    (bool, SymbolAssetConfig) CheckCenterSymbols()
    {
        if (View.ReelColumnViews.Count == 0) return (false, null);

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
                return (false, null);
            }
        }

        return (true, centerSymbol);
    }

    void GivePrizeReward(SymbolAssetConfig symbolConfig)
    {
        CreditSystem.Instance.AddCredits(symbolConfig.Payout);
        LogSystem.Instance.LogSpinResult(symbolConfig.Payout);
    }
}