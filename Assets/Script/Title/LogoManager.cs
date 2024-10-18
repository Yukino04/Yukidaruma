using UnityEngine;
using UnityEngine.UI; // Textコンポーネント用

public class LogoManager : MonoBehaviour
{
    // 点滅させる対象のテキストコンポーネント
    [SerializeField] private Text logoText; // ImageからTextに変更

    // 点滅周期（秒単位）
    [SerializeField] private float cycle = 1f;

    private float time;

    void Update()
    {
        // 内部時刻を経過させる
        time += Time.deltaTime;

        // 周期 'cycle' で繰り返す値の取得
        float repeatValue = Mathf.Repeat(time, cycle);

        // 内部時刻 'time' における明滅状態を反映
        logoText.enabled = repeatValue >= cycle * 0.5f;
    }
}
