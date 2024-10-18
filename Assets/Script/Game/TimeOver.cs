using UnityEngine;
public class TimeOver : MonoBehaviour
{
    //キャンバス用
    private static Canvas timeOverCanvas;

    private void Awake()
    {
        //Canvasコンポーネント取得
        timeOverCanvas = GetComponent<Canvas>();
    }
    public static void TimeOverShowPanel()
    {
        //ゲーム内の時間を止める
        Time.timeScale = 0f;
    }
}
