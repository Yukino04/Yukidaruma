using UnityEngine;
using static GameDirector;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    //Plkayerはマス目の最大値を超えて移動はしない
    public static int Left = -7; //左のマス目の最大値
    public static int Right = 7; //右のマス目の最大値
    public static int CourseMax = -Left + Right + 1; //動けるマス目の全体の範囲
    public static int Move = 1; //プレイヤーの1回移動量
    public static float MoveSpeed = 15.0f; // プレイヤーの移動速度（1秒間に移動する距離）

    [SerializeField]
    GameDirector director;

    [SerializeField]
    float keynum = 3.5f;
    float key = 0;

    //SE用
    AudioSource SE;
    public AudioClip Buy;
    public AudioClip Fail;

    void Start()
    {
        Application.targetFrameRate = 60;
        animator = GetComponent<Animator>();
        SE = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Itme01"))
        {
            director.Itme01();
            SE.PlayOneShot(Buy);
        }
        else if (other.CompareTag("Itme02"))
        {
            director.Itme02();
            SE.PlayOneShot(Buy);
        }
        else if (other.CompareTag("Itme03"))
        {
            director.Itme03();
            SE.PlayOneShot(Buy);
        }
        else
        {
            director.Itme00();
            SE.PlayOneShot(Fail);
        }
        Destroy(other.gameObject);
    }

    void Update()
    {
        // コントローラーの入力を取得
        float horizontalInput = Input.GetAxis("Horizontal");

        // プレイヤーの移動
        if (horizontalInput != 0)
        {
            // 移動量を計算
            float moveAmount = horizontalInput * MoveSpeed * Time.deltaTime;
            // 新しい位置を計算
            float newX = transform.position.x + moveAmount;

            // 左右の範囲内に制限
            newX = Mathf.Clamp(newX, Left, Right);

            // 位置を更新
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            // 移動方向に応じて反転
            key = horizontalInput;
            transform.localScale = new Vector3(key * keynum, keynum, 1);
        }

        // アニメーション速度の設定
        animator.speed = Mathf.Abs(horizontalInput) / 2.0f; // 絶対値を取ることで、左右どちらに動いても速度が変わらないようにする
    }
}
