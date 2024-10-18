using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleDirector : MonoBehaviour
{
    MusicDirector musicDirector;

    private void Start()
    {
        // MusicDirector�̎Q�Ƃ��擾
        musicDirector = FindObjectOfType<MusicDirector>();
    }

    void Update()
    {
        // �Q�[���V�[����
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Button1"))
        {
            StartCoroutine(PlaySEAndChangeScene());
        }

        // �G�X�P�[�v�L�[�ŃQ�[���������I��
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // GameOver�̐ÓI���\�b�h���Ăяo��
        GameOver.ReStartGame();
    }

    IEnumerator PlaySEAndChangeScene()
    {
        if (musicDirector != null)
        {
            // SE��炷
            musicDirector.PlaySE();

            // SE�̍Đ����I���܂ő҂�
            yield return new WaitForSeconds(musicDirector.seClip.length);
        }

        // �V�[����ύX
        SceneManager.LoadScene("SelectScene");
    }
}
