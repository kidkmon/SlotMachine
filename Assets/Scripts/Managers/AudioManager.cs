using UnityEngine;

public class AudioManager : Singleton<AudioManager> {
    [SerializeField] AudioClip spinSound;
    [SerializeField] AudioClip winSound;

    public void PlaySpinSound() => AudioSource.PlayClipAtPoint(spinSound, Camera.main.transform.position);
    public void PlayWinSound() => AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position);
}  
