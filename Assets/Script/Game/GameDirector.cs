using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameDirector : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI pointcount; // プレイ中得点表示

    [SerializeField]
    TextMeshProUGUI GameOverpoint; // ゲームオーバー時得点表示

    [SerializeField]
    TextMeshProUGUI GameClearpoint; // タイムオーバー時得点表示

    [SerializeField]
    Image[] hpGauges; // HPゲージの画像（複数）

    [SerializeField]
    Image timeGauge; // 時間経過ゲージ

    [SerializeField]
    TextMeshProUGUI clearUI, gameOverUI; // ゲームオーバーUI

    [SerializeField]
    GameObject timeOverCanvas; // タイムオーバー用キャンバス

    [SerializeField]
    GameObject gameOverCanvas; // ゲームオーバー用キャンバス

    [SerializeField]
    GameObject BonusTimeCanvas; // ボーナスタイム用キャンバス

    [SerializeField]
    float maxHP = 100; // 初期HP

    [SerializeField]
    float maxTime; // 初期タイム

    int point; // 初期ポイント
    int score;
    float hp; // 現在のHP
    float time; // 残り時間

    // BGM
    public AudioSource audioSource;

    // 構造体の定義
    public struct TunaPoint
    {
        public int point01;
        public int point02;
        public int point03;
    }

    // タイムとHPの初期化
    void Start()
    {
        hp = maxHP;
        time = maxTime;

        // リトライボタンを非表示にする
        gameOverCanvas.SetActive(false);
        timeOverCanvas.SetActive(false);
        BonusTimeCanvas.SetActive(false);

        // AudioSourceを取得
        audioSource = GetComponent<AudioSource>();
    }

    // ツナ缶の得点加算処理
    public void Itme01()
    {
        this.point += 10;
    }
    public void Itme02()
    {
        this.point += 20;
    }
    public void Itme03()
    {
        this.point += 30;
    }

    // HPが減少する処理
    public void Itme00()
    {
        hp -= 10;
        UpdateHPGauge(); // HPゲージの更新
    }

    // HPゲージの更新
    void UpdateHPGauge()
    {
        int hpSegments = Mathf.CeilToInt((hp / maxHP) * hpGauges.Length); // 表示するHPセグメントの数を計算
        for (int i = 0; i < hpGauges.Length; i++)
        {
            hpGauges[i].gameObject.SetActive(i < hpSegments); // セグメントを表示/非表示にする
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); // アプリケーションを終了
        }

        // 得点の表示更新
        pointcount.text = this.point.ToString() + " point";
        this.score = this.point;

        // 残り時間の計算
        this.time -= Time.deltaTime;
        this.timeGauge.fillAmount = time / maxTime;

        // ボーナスタイムの表示
        if (time <= 15)
        {
            BonusTimeCanvas.SetActive(true);
            if (time <= 13)
            {
                BonusTimeCanvas.SetActive(false);
            }
        }

        // ゲームオーバー処理
        if (hp <= 0)
        {
            HandleGameOver();
        }

        // タイムオーバー処理
        if (time <= 0.0f)
        {
            HandleTimeOver();
        }
    }

    // ゲームオーバー時の処理
    void HandleGameOver()
    {
        audioSource.Stop(); // BGMを停止
        GameOver.GameOverShowPanel(); // ゲームオーバーのパネルを表示
        gameOverCanvas.SetActive(true); // ゲームオーバーキャンバスを表示
        this.GameOverpoint.text = this.score.ToString() + " point"; // ゲームオーバー時の得点を表示

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonDown("Button1"))
        {
            SceneManager.LoadScene("TitleScene"); // スペースキーでタイトルシーンに移動
        }
    }

    // タイムオーバー時の処理
    void HandleTimeOver()
    {
        audioSource.Stop(); // BGMを停止
        TimeOver.TimeOverShowPanel(); // タイムオーバーのパネルを表示
        timeOverCanvas.SetActive(true); // タイムオーバーキャンバスを表示
        this.GameClearpoint.text = this.score.ToString() + " point"; // タイムオーバー時の得点を表示

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonDown("Button1"))
        {
            SceneManager.LoadScene("TitleScene"); // スペースキーでタイトルシーンに移動
        }
    }
}
