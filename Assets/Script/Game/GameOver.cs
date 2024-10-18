using UnityEngine;
public class GameOver : MonoBehaviour
{
    //キャンバス用
    private static Canvas gameOverCanvas;

    private void Awake()
    {
        //Canvasコンポーネント取得
        gameOverCanvas = GetComponent<Canvas>();
    }
    public static void GameOverShowPanel()
    {
        //ゲーム内の時間を止める
        Time.timeScale = 0f;
    }
    public static void ReStartGame()
    {
        //止めたゲーム内の時間を戻す
        Time.timeScale = 1f;
    }
}