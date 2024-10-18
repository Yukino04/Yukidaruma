using UnityEngine;

public class ItemController : MonoBehaviour
{
    void Update()
    {
        // フレームごとに等速でアイテムを落下させる
        transform.Translate(0, -0.05f, 0);

        // 画面外に出たらアイテムを破棄する
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }
    }
}