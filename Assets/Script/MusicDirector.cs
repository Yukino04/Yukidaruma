using UnityEngine;

public class MusicDirector : MonoBehaviour
{
    public AudioSource bgmSource;   // BGM�p��AudioSource
    public AudioSource seSource;    // SE�p��AudioSource
    public AudioClip seClip;        // SE�p��AudioClip

    private void Start()
    {
        // �^�C�g���V�[����BGM���Đ���������
        bgmSource.loop = true;
        bgmSource.Play();
    }

    // SE��炷�֐�
    public void PlaySE()
    {
        seSource.PlayOneShot(seClip);
    }
}