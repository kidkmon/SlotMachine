using System;
using System.Collections.Generic;
using UnityEngine;

public class ReelColumnView : View<ReelColumnViewController, ReelColumnView>
{
    [SerializeField] GameObject _container;
    [SerializeField] GameObject _symbolCardPrefab;
    [SerializeField] ReelSpin _reelSpin;

    List<SymbolCardView> _symbolCards = new();

    //Getters
    public IReadOnlyList<SymbolCardView> SymbolCards => _symbolCards;
    public ReelSpin ReelSpin => _reelSpin;

    //Events
    public event Func<SymbolAssetConfig> OnGetCenterSymbolConfig;
    public event Action OnSpinButtonClicked;

    protected override void Start() {
        base.Start();
    }

    public void AddSymbolCard(SymbolAssetConfig symbolAssetConfig) {
        var symbolCard = Instantiate(_symbolCardPrefab, _container.transform).GetComponent<SymbolCardView>();
        symbolCard.Setup(symbolAssetConfig);
        _symbolCards.Add(symbolCard);
    }

    public void UpdateSymbolCard(int index, SymbolAssetConfig symbolAssetConfig) {
        _symbolCards[index].Setup(symbolAssetConfig);
    }

    public SymbolAssetConfig GetCenterSymbolConfig() {
        return OnGetCenterSymbolConfig?.Invoke();
    }

    public void SpinButtonClicked() => OnSpinButtonClicked?.Invoke();
}