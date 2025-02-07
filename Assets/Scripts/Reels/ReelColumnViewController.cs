using UnityEngine;

public class ReelColumnViewController : ViewController<ReelColumnView> {

    protected override void OnInitialized()
    {
        UpdateView();
    }

    protected override void SetupEventHandlers()
    {
        View.OnGetCenterSymbolConfig += GetCenterSymbolConfig;
        View.OnSpinButtonClicked += SpinButtonClicked;
    }
    protected override void RemoveEventHandlers()
    {
        View.OnGetCenterSymbolConfig -= GetCenterSymbolConfig;
        View.OnSpinButtonClicked -= SpinButtonClicked;
    }

    void UpdateView()
    {
        for (int i = 0; i < EnvironmentConfigs.Instance.SymbolsAssetCollection.Size; i++)
        {
            var symbolConfig = GenerateRandomSymbol();
            View.AddSymbolCard(symbolConfig);
        }
    }

    SymbolAssetConfig GenerateRandomSymbol() {  
        int symbolsSize = EnvironmentConfigs.Instance.SymbolsAssetCollection.Size + 1;
        return EnvironmentConfigs.Instance.SymbolsAssetCollection.GetConfig(Random.Range(1, symbolsSize));
    }

    public SymbolAssetConfig GetCenterSymbolConfig()
    {
        return View.SymbolCards[View.SymbolCards.Count / 2].GetConfig();
    }

    public void SpinButtonClicked()
    {
        for (int i = 0; i < View.SymbolCards.Count; i++)
        {
            View.UpdateSymbolCard(i, GenerateRandomSymbol());
        }
    }
}