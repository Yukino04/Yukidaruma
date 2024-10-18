using UnityEngine;
using static GameDirector;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    //Plkayer�̓}�X�ڂ̍ő�l�𒴂��Ĉړ��͂��Ȃ�
    public static int Left = -7; //���̃}�X�ڂ̍ő�l
    public static int Right = 7; //�E�̃}�X�ڂ̍ő�l
    public static int CourseMax = -Left + Right + 1; //������}�X�ڂ̑S�͈̂̔�
    public static int Move = 1; //�v���C���[��1��ړ���
    public static float MoveSpeed = 15.0f; // �v���C���[�̈ړ����x�i1�b�ԂɈړ����鋗���j

    [SerializeField]
    GameDirector director;

    [SerializeField]
    float keynum = 3.5f;
    float key = 0;

    //SE�p
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
        // �R���g���[���[�̓��͂��擾
        float horizontalInput = Input.GetAxis("Horizontal");

        // �v���C���[�̈ړ�
        if (horizontalInput != 0)
        {
            // �ړ��ʂ��v�Z
            float moveAmount = horizontalInput * MoveSpeed * Time.deltaTime;
            // �V�����ʒu���v�Z
            float newX = transform.position.x + moveAmount;

            // ���E�͈͓̔��ɐ���
            newX = Mathf.Clamp(newX, Left, Right);

            // �ʒu���X�V
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            // �ړ������ɉ����Ĕ��]
            key = horizontalInput;
            transform.localScale = new Vector3(key * keynum, keynum, 1);
        }

        // �A�j���[�V�������x�̐ݒ�
        animator.speed = Mathf.Abs(horizontalInput) / 2.0f; // ��Βl����邱�ƂŁA���E�ǂ���ɓ����Ă����x���ς��Ȃ��悤�ɂ���
    }
}
