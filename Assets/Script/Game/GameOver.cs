using UnityEngine;
public class GameOver : MonoBehaviour
{
    //�L�����o�X�p
    private static Canvas gameOverCanvas;

    private void Awake()
    {
        //Canvas�R���|�[�l���g�擾
        gameOverCanvas = GetComponent<Canvas>();
    }
    public static void GameOverShowPanel()
    {
        //�Q�[�����̎��Ԃ��~�߂�
        Time.timeScale = 0f;
    }
    public static void ReStartGame()
    {
        //�~�߂��Q�[�����̎��Ԃ�߂�
        Time.timeScale = 1f;
    }
}