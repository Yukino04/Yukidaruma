using UnityEngine;

public class MusicDirector : MonoBehaviour
{
    public AudioSource bgmSource;   // BGM用のAudioSource
    public AudioSource seSource;    // SE用のAudioSource
    public AudioClip seClip;        // SE用のAudioClip

    private void Start()
    {
        // タイトルシーンでBGMを再生し続ける
        bgmSource.loop = true;
        bgmSource.Play();
    }

    // SEを鳴らす関数
    public void PlaySE()
    {
        seSource.PlayOneShot(seClip);
    }
}