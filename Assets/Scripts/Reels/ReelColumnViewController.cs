using UnityEngine;

public class ReelColumnViewController : ViewController<ReelColumnView> {

    protected override void OnInitialized()
    {
        UpdateView();
    }

    protected override void SetupEventHandlers()
    {
        View.OnGetCenterSymbolConfig += GetCenterSymbolConfig;
    }
    protected override void RemoveEventHandlers()
    {
        View.OnGetCenterSymbolConfig -= GetCenterSymbolConfig;
    }

    void UpdateView()
    {
        int symbolsPerReel = EnvironmentConfigs.Instance.GameConfig.SymbolsPerReel;
        for (int i = 0; i < symbolsPerReel; i++)
        {
            var symbolConfig = GenerateRandomSymbol();
            View.AddSymbolCard(symbolConfig);
        }
    }

     SymbolAssetConfig GenerateRandomSymbol() {  
        int symbolsSize = EnvironmentConfigs.Instance.SymbolsAssetCollection.Size;
        return EnvironmentConfigs.Instance.SymbolsAssetCollection.GetConfig(Random.Range(1, symbolsSize));
    }

    public SymbolAssetConfig GetCenterSymbolConfig()
    {
        return View.SymbolCards[View.SymbolCards.Count / 2].GetConfig();
    }
}