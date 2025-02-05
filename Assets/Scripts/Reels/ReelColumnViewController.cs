using UnityEngine;

public class ReelColumnViewController : ViewController<ReelColumnView> {

    protected override void OnInitialized()
    {
        UpdateView();
    }

    private void UpdateView()
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
        return View.symbolCards[View.symbolCards.Count / 2].GetConfig();
    }

    protected override void SetupEventHandlers(){}
    protected override void RemoveEventHandlers(){}
    
}