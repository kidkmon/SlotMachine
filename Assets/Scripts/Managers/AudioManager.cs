using UnityEngine;

public class AudioManager : Singleton<AudioManager> {
    [SerializeField] AudioClip _insertCoinSound;
    [SerializeField] AudioClip _spinSound;
    [SerializeField] AudioClip _winSound;
    [SerializeField] AudioClip _jackpotSound;

    public void PlaySpinSound() => AudioSource.PlayClipAtPoint(_spinSound, Camera.main.transform.position, 0.1f);
    public void PlayInsertCreditSound() => AudioSource.PlayClipAtPoint(_insertCoinSound, Camera.main.transform.position, 0.5f);
    public void PlayWinSound() => AudioSource.PlayClipAtPoint(_winSound, Camera.main.transform.position, 0.5f);
    public void PlayJackpotSound() => AudioSource.PlayClipAtPoint(_jackpotSound, Camera.main.transform.position, 0.5f);
}  
