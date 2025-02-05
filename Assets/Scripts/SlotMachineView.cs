using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachineView : View<SlotMachineViewController, SlotMachineView>
{
    [Header("Reels")]
    [SerializeField] ReelColumnView _reelColumnViewPrefab;
    [SerializeField] Transform _reelColumnContainer;

    [Header("UI")]
    [SerializeField] Button _spinButton;

    List<ReelColumnView> _reelColumnViews;

    public Button SpinButton => _spinButton;
    public List<ReelColumnView> ReelColumnViews => _reelColumnViews;

    protected override void Start()
    {
        base.Start();
        _reelColumnViews = new List<ReelColumnView>();
    }

    public void AddReelColumnView()
    {
        var reelColumnView = Instantiate(_reelColumnViewPrefab, _reelColumnContainer);
        _reelColumnViews.Add(reelColumnView);
    }
}