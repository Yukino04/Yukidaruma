using UnityEngine;
public class TimeOver : MonoBehaviour
{
    //�L�����o�X�p
    private static Canvas timeOverCanvas;

    private void Awake()
    {
        //Canvas�R���|�[�l���g�擾
        timeOverCanvas = GetComponent<Canvas>();
    }
    public static void TimeOverShowPanel()
    {
        //�Q�[�����̎��Ԃ��~�߂�
        Time.timeScale = 0f;
    }
}
