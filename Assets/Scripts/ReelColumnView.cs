using System.Collections.Generic;
using UnityEngine;

public class ReelColumnView : View<ReelColumnViewController, ReelColumnView>
{
    [SerializeField] GameObject _container;
    [SerializeField] GameObject _symbolCardPrefab;

    public List<SymbolCardView> _symbolCards;

    protected override void Start() {
        base.Start();
        _symbolCards = new List<SymbolCardView>();
    }

    public void AddSymbolCard(SymbolAssetConfig symbolAssetConfig) {
        var symbolCard = Instantiate(_symbolCardPrefab, _container.transform).GetComponent<SymbolCardView>();
        symbolCard.Setup(symbolAssetConfig);
        _symbolCards.Add(symbolCard);
    }
}