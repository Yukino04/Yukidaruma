using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleDirector : MonoBehaviour
{
    MusicDirector musicDirector;

    private void Start()
    {
        // MusicDirectorの参照を取得
        musicDirector = FindObjectOfType<MusicDirector>();
    }

    void Update()
    {
        // ゲームシーンへ
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Button1"))
        {
            StartCoroutine(PlaySEAndChangeScene());
        }

        // エスケープキーでゲームを強制終了
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // GameOverの静的メソッドを呼び出す
        GameOver.ReStartGame();
    }

    IEnumerator PlaySEAndChangeScene()
    {
        if (musicDirector != null)
        {
            // SEを鳴らす
            musicDirector.PlaySE();

            // SEの再生が終わるまで待つ
            yield return new WaitForSeconds(musicDirector.seClip.length);
        }

        // シーンを変更
        SceneManager.LoadScene("SelectScene");
    }
}
