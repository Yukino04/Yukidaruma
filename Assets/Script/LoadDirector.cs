using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadDirector : MonoBehaviour
{
    //SE用
    AudioSource SE;
    public AudioClip SE_ketteion;
    void Start()
    {
        //止めたゲーム内の時間を戻す関数の呼び出し
        GameOver.ReStartGame();

        this.SE = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        //スペースキーでシーンをセレクトシーンに変換する
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonDown("Button1"))
        {
            //ロードシーンへ
            SceneManager.LoadScene("SelectScene");
        }
    }
}