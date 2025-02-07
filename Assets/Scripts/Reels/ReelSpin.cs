using System.Collections;
using UnityEngine;

public class ReelSpin : MonoBehaviour
{
    [SerializeField] ReelColumnView _reelColumnView;
    [SerializeField] RectTransform _reelTransform;

    float _timeInterval = 0.025f;
    bool _reelStopped;

    public bool ReelStopped => _reelStopped;
    
    void Start()
    {
        _reelColumnView.OnSpinButtonClicked += SpinReel;
    }

    public void SpinReel()
    {
        StartCoroutine(Rotate());
    }

    void OnDestroy()
    {
        _reelColumnView.OnSpinButtonClicked -= SpinReel;
    }
    
    #region Reel Animation
    IEnumerator Rotate()
    {
        _reelStopped = false;

        for (int i = 0; i < 30; i++)
        {
            if (_reelTransform.offsetMax.y >= 700f)
            {
                _reelTransform.offsetMax = new Vector2(_reelTransform.offsetMax.x, 0f);
            }
            else
            {
                _reelTransform.offsetMax = new Vector2(_reelTransform.offsetMax.x, _reelTransform.offsetMax.y + 100f);
            }
            
            yield return new WaitForSeconds(_timeInterval);
        }

        int randomValue = Random.Range(30, 50);

        for (int i = 0; i < randomValue; i++)
        {
            if (_reelTransform.offsetMax.y >= 700f)
            {
                _reelTransform.offsetMax = new Vector2(_reelTransform.offsetMax.x, 0f);
            }
            else
            {
                _reelTransform.offsetMax = new Vector2(_reelTransform.offsetMax.x, _reelTransform.offsetMax.y + 100f);
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
