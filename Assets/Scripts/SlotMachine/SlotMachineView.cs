using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlotMachineView : View<SlotMachineViewController, SlotMachineView>
{
    [Header("Reels")]
    [SerializeField] ReelColumnView _reelColumnViewPrefab;
    [SerializeField] Transform _reelContainer;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI _jackpotText;
    
    List<ReelColumnView> _reelColumnViews = new();

    public IReadOnlyList<ReelColumnView> ReelColumnViews => _reelColumnViews;
    public event Action OnSpinButtonClicked;

    protected override void Start()
    {
        base.Start();
    }

    public void AddReelColumnView()
    {
        var reelColumnView = Instantiate(_reelColumnViewPrefab, _reelContainer);
        _reelColumnViews.Add(reelColumnView);
    }

    public void SpinMachine() => OnSpinButtonClicked?.Invoke();

    #region UI

    void OnEnable() {
        UpdateJackpotUI(JackpotSystem.Instance.GetCurrentJackpot());
        JackpotSystem.Instance.OnJackpotUpdated.AddListener(UpdateJackpotUI);
    }

    void OnDisable() {
        JackpotSystem.Instance.OnJackpotUpdated.RemoveListener(UpdateJackpotUI);
    }

    void UpdateJackpotUI(float jackpot) => _jackpotText.text = jackpot.ToString("F2");

    #endregion
}