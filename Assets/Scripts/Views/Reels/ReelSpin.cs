using System.Collections;
using UnityEngine;

public class ReelSpin : MonoBehaviour
{
    [SerializeField] ReelColumnView _reelColumnView;
    [SerializeField] RectTransform _reelTransform;

    float _timeInterval = 0.025f;
    int _middleIndex = 1;
    bool _reelStopped;

    public int MiddleIndex => _middleIndex;
    public bool ReelStopped => _reelStopped;
    
    void Start()
    {
        _reelColumnView.OnSpinButtonClicked += SpinReel;
    }

    public void SpinReel()
    {
        StartCoroutine(Spin());
    }

    void OnDestroy()
    {
        _reelColumnView.OnSpinButtonClicked -= SpinReel;
    }
    
    #region Reel Animation
    
    IEnumerator Spin()
    {
        _reelStopped = false;

        int randomValue = Random.Range(15, 30);

        for (int i = 0; i < randomValue; i++)
        {
            if (_reelTransform.offsetMax.y >= 231f) // Reset to the top
            {
                _reelTransform.offsetMax = new Vector2(_reelTransform.offsetMax.x, 0f);
                _middleIndex = 1;
            }
            else
            {
                _reelTransform.offsetMax = new Vector2(_reelTransform.offsetMax.x, _reelTransform.offsetMax.y + 33f);
                _middleIndex += 1;
            }
         
            AdjustTimeInterval(i, randomValue);

            yield return new WaitForSeconds(_timeInterval);
        }

        _reelStopped = true;
    }

    // Adjust time interval based on the current iteration
    void AdjustTimeInterval(int i, int randomValue)
    {
        if (i > Mathf.RoundToInt(randomValue * 0.25f)) _timeInterval = 0.05f; // Quarter
        else if (i > Mathf.RoundToInt(randomValue * 0.5f)) _timeInterval = 0.1f; // Half
        else if (i > Mathf.RoundToInt(randomValue * 0.75f)) _timeInterval = 0.15f; // Three quarters
        else if (i > Mathf.RoundToInt(randomValue * 0.95f))_timeInterval = 0.2f; // Almost all
    }

    #endregion
}
