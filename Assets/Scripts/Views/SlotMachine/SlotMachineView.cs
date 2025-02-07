using System;
using System.Collections;
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
    
    bool _isSpinning;
    List<ReelColumnView> _reelColumnViews = new();

    //Getters
    public bool IsSpinning => _isSpinning;
    public IReadOnlyList<ReelColumnView> ReelColumnViews => _reelColumnViews;

    //Events
    public event Action OnSpinButtonClicked;

    public void AddReelColumnView()
    {
        var reelColumnView = Instantiate(_reelColumnViewPrefab, _reelContainer);
        _reelColumnViews.Add(reelColumnView);
    }

    #region Spin Methods

    public void SpinMachine() => StartCoroutine(SpinReels());

    IEnumerator SpinReels()
    {
        _isSpinning = true;

        foreach (var reelColumnView in _reelColumnViews)
        {
            reelColumnView.SpinButtonClicked();
        }

        yield return new WaitUntil(() => _reelColumnViews.TrueForAll(reelColumnView => reelColumnView.ReelSpin.ReelStopped));

        _isSpinning = false;
        OnSpinButtonClicked?.Invoke();
    }

    #endregion

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