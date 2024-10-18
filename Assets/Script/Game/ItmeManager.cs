using UnityEngine;
public class TunaGenerator : MonoBehaviour
{
    public GameObject ItmePrefab00;
    public GameObject ItmePrefab01;
    public GameObject ItmePrefab02;
    public GameObject ItmePrefab03;

    //���Ƀc�i�ʂ��o������܂ł̎���
    [SerializeField]
    public float span;
    [SerializeField]
    public float span_bonus;

    //�҂����Ԍv��
    float delta;
    
    //�c�i�ʂ̏o���ʒ����p�^�C��
    [SerializeField]
    float maxTime; //�ő�^�C��
    float time;

    //�_�C�X�̏���
    [SerializeField]
    int ratio;

    void Start()
    {
        time = maxTime;
    }
    void Update()
    {
        //�ߎ��Ԃ𑫂�
        this.delta += Time.deltaTime;
        this.time -= Time.deltaTime;

        if (this.time > (maxTime/2))
        {
            if (this.delta >= this.span)
            {
                this.delta = 0;
                GameObject item;
                //15�̖ڂ̃_�C�X
                int dice = Random.Range(1, 15);
                if (dice <= this.ratio) //�_�C�X��ratio�����Ȃ�
                {
                    item = Instantiate(ItmePrefab01);
                }
                else if (dice <= (this.ratio + 3)) //�_�C�X��ratio�ȉ�
                {
                    item = Instantiate(ItmePrefab02);
                }
                else if (dice <= (this.ratio + 5)) //�_�C�X��ratio�ȉ��Ȃ�
                {
                    item = Instantiate(ItmePrefab00);
                }
                else //�_�C�X������ȊO�Ȃ�
                {
                    item = Instantiate(ItmePrefab03);
                }
                //PLayer�̈ړ��ł���͈͂ɍ��킹��Itme�𐶐��ł���͈͂����߂�
                int random = Random.Range(PlayerController.Left, PlayerController.Right + 1);
                float px = random * PlayerController.Move;
                item.transform.position = new Vector3(px, 7, 0);
            }
        }
        //�c�莞�Ԃ������ɂȂ�����
        else
        {
            if (this.delta >= this.span_bonus)
            {
                this.delta = 0;
                GameObject item;
                //15�̖ڂ̃_�C�X
                int dice = Random.Range(1, 15);
                if (dice <= this.ratio) //�_�C�X��ratio�����Ȃ�
                {
                    item = Instantiate(ItmePrefab01);
                }
                else if (dice <= (this.ratio + 3)) //�_�C�X��ratio�ȉ�
                {
                    item = Instantiate(ItmePrefab02);
                }
                else if (dice <= (this.ratio + 5)) //�_�C�X��ratio�ȉ��Ȃ�
                {
                    item = Instantiate(ItmePrefab00);
                }
                else //�_�C�X������ȊO�Ȃ�
                {
                    item = Instantiate(ItmePrefab03);
                }
                //PLayer�̈ړ��ł���͈͂ɍ��킹��Itme�𐶐��ł���͈͂����߂�
                int random = Random.Range(PlayerController.Left, PlayerController.Right + 1);
                float px = random * PlayerController.Move;
                item.transform.position = new Vector3(px, 7, 0);
            }
        }
    }
}