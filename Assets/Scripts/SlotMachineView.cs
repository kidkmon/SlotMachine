using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachineView : View<SlotMachineViewController, SlotMachineView>
{
    [Header("Reels")]
    [SerializeField] ReelColumnView _reelColumnViewPrefab;
    [SerializeField] Transform _reelContainer;

    [Header("UI")]
    [SerializeField] Button _spinButton;
    [SerializeField] Button _prizeButton;
    
    List<ReelColumnView> _reelColumnViews = new();

    public IEnumerable<ReelColumnView> ReelColumnViews => _reelColumnViews;
    public Button SpinButton => _spinButton;
    public Button PrizeButton => _prizeButton;

    protected override void Start()
    {
        base.Start();
    }

    public void AddReelColumnView()
    {
        var reelColumnView = Instantiate(_reelColumnViewPrefab, _reelContainer);
        _reelColumnViews.Add(reelColumnView);
    }
}