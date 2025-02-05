using System;
using System.Collections.Generic;
using UnityEngine;

public class ReelColumnView : View<ReelColumnViewController, ReelColumnView>
{
    [SerializeField] GameObject _container;
    [SerializeField] GameObject _symbolCardPrefab;

    List<SymbolCardView> _symbolCards = new();

    public IList<SymbolCardView> SymbolCards => _symbolCards;
    public event Func<SymbolAssetConfig> OnGetCenterSymbolConfig;

    protected override void Start() {
        base.Start();
    }

    public void AddSymbolCard(SymbolAssetConfig symbolAssetConfig) {
        var symbolCard = Instantiate(_symbolCardPrefab, _container.transform).GetComponent<SymbolCardView>();
        symbolCard.Setup(symbolAssetConfig);
        _symbolCards.Add(symbolCard);
    }

    public SymbolAssetConfig GetCenterSymbolConfig() {
        return OnGetCenterSymbolConfig?.Invoke();
    }
}