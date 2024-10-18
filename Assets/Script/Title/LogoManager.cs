using UnityEngine;
using UnityEngine.UI; // Text�R���|�[�l���g�p

public class LogoManager : MonoBehaviour
{
    // �_�ł�����Ώۂ̃e�L�X�g�R���|�[�l���g
    [SerializeField] private Text logoText; // Image����Text�ɕύX

    // �_�Ŏ����i�b�P�ʁj
    [SerializeField] private float cycle = 1f;

    private float time;

    void Update()
    {
        // �����������o�߂�����
        time += Time.deltaTime;

        // ���� 'cycle' �ŌJ��Ԃ��l�̎擾
        float repeatValue = Mathf.Repeat(time, cycle);

        // �������� 'time' �ɂ����閾�ŏ�Ԃ𔽉f
        logoText.enabled = repeatValue >= cycle * 0.5f;
    }
}
