using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameDirector : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI pointcount; // �v���C�����_�\��

    [SerializeField]
    TextMeshProUGUI GameOverpoint; // �Q�[���I�[�o�[�����_�\��

    [SerializeField]
    TextMeshProUGUI GameClearpoint; // �^�C���I�[�o�[�����_�\��

    [SerializeField]
    Image[] hpGauges; // HP�Q�[�W�̉摜�i�����j

    [SerializeField]
    Image timeGauge; // ���Ԍo�߃Q�[�W

    [SerializeField]
    TextMeshProUGUI clearUI, gameOverUI; // �Q�[���I�[�o�[UI

    [SerializeField]
    GameObject timeOverCanvas; // �^�C���I�[�o�[�p�L�����o�X

    [SerializeField]
    GameObject gameOverCanvas; // �Q�[���I�[�o�[�p�L�����o�X

    [SerializeField]
    GameObject BonusTimeCanvas; // �{�[�i�X�^�C���p�L�����o�X

    [SerializeField]
    float maxHP = 100; // ����HP

    [SerializeField]
    float maxTime; // �����^�C��

    int point; // �����|�C���g
    int score;
    float hp; // ���݂�HP
    float time; // �c�莞��

    // BGM
    public AudioSource audioSource;

    // �\���̂̒�`
    public struct TunaPoint
    {
        public int point01;
        public int point02;
        public int point03;
    }

    // �^�C����HP�̏�����
    void Start()
    {
        hp = maxHP;
        time = maxTime;

        // ���g���C�{�^�����\���ɂ���
        gameOverCanvas.SetActive(false);
        timeOverCanvas.SetActive(false);
        BonusTimeCanvas.SetActive(false);

        // AudioSource���擾
        audioSource = GetComponent<AudioSource>();
    }

    // �c�i�ʂ̓��_���Z����
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

    // HP���������鏈��
    public void Itme00()
    {
        hp -= 10;
        UpdateHPGauge(); // HP�Q�[�W�̍X�V
    }

    // HP�Q�[�W�̍X�V
    void UpdateHPGauge()
    {
        int hpSegments = Mathf.CeilToInt((hp / maxHP) * hpGauges.Length); // �\������HP�Z�O�����g�̐����v�Z
        for (int i = 0; i < hpGauges.Length; i++)
        {
            hpGauges[i].gameObject.SetActive(i < hpSegments); // �Z�O�����g��\��/��\���ɂ���
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); // �A�v���P�[�V�������I��
        }

        // ���_�̕\���X�V
        pointcount.text = this.point.ToString() + " point";
        this.score = this.point;

        // �c�莞�Ԃ̌v�Z
        this.time -= Time.deltaTime;
        this.timeGauge.fillAmount = time / maxTime;

        // �{�[�i�X�^�C���̕\��
        if (time <= 15)
        {
            BonusTimeCanvas.SetActive(true);
            if (time <= 13)
            {
                BonusTimeCanvas.SetActive(false);
            }
        }

        // �Q�[���I�[�o�[����
        if (hp <= 0)
        {
            HandleGameOver();
        }

        // �^�C���I�[�o�[����
        if (time <= 0.0f)
        {
            HandleTimeOver();
        }
    }

    // �Q�[���I�[�o�[���̏���
    void HandleGameOver()
    {
        audioSource.Stop(); // BGM���~
        GameOver.GameOverShowPanel(); // �Q�[���I�[�o�[�̃p�l����\��
        gameOverCanvas.SetActive(true); // �Q�[���I�[�o�[�L�����o�X��\��
        this.GameOverpoint.text = this.score.ToString() + " point"; // �Q�[���I�[�o�[���̓��_��\��

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonDown("Button1"))
        {
            SceneManager.LoadScene("TitleScene"); // �X�y�[�X�L�[�Ń^�C�g���V�[���Ɉړ�
        }
    }

    // �^�C���I�[�o�[���̏���
    void HandleTimeOver()
    {
        audioSource.Stop(); // BGM���~
        TimeOver.TimeOverShowPanel(); // �^�C���I�[�o�[�̃p�l����\��
        timeOverCanvas.SetActive(true); // �^�C���I�[�o�[�L�����o�X��\��
        this.GameClearpoint.text = this.score.ToString() + " point"; // �^�C���I�[�o�[���̓��_��\��

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonDown("Button1"))
        {
            SceneManager.LoadScene("TitleScene"); // �X�y�[�X�L�[�Ń^�C�g���V�[���Ɉړ�
        }
    }
}
