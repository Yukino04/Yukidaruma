using UnityEngine;

public class ItemController : MonoBehaviour
{
    void Update()
    {
        // �t���[�����Ƃɓ����ŃA�C�e���𗎉�������
        transform.Translate(0, -0.05f, 0);

        // ��ʊO�ɏo����A�C�e����j������
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }
    }
}