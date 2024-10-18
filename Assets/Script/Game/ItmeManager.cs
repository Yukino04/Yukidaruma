using UnityEngine;
public class TunaGenerator : MonoBehaviour
{
    public GameObject ItmePrefab00;
    public GameObject ItmePrefab01;
    public GameObject ItmePrefab02;
    public GameObject ItmePrefab03;

    //次にツナ缶が出現するまでの時間
    [SerializeField]
    public float span;
    [SerializeField]
    public float span_bonus;

    //待ち時間計測
    float delta;
    
    //ツナ缶の出現量調整用タイム
    [SerializeField]
    float maxTime; //最大タイム
    float time;

    //ダイスの条件
    [SerializeField]
    int ratio;

    void Start()
    {
        time = maxTime;
    }
    void Update()
    {
        //過時間を足す
        this.delta += Time.deltaTime;
        this.time -= Time.deltaTime;

        if (this.time > (maxTime/2))
        {
            if (this.delta >= this.span)
            {
                this.delta = 0;
                GameObject item;
                //15個の目のダイス
                int dice = Random.Range(1, 15);
                if (dice <= this.ratio) //ダイスがratio未満なら
                {
                    item = Instantiate(ItmePrefab01);
                }
                else if (dice <= (this.ratio + 3)) //ダイスがratio以下
                {
                    item = Instantiate(ItmePrefab02);
                }
                else if (dice <= (this.ratio + 5)) //ダイスがratio以下なら
                {
                    item = Instantiate(ItmePrefab00);
                }
                else //ダイスがそれ以外なら
                {
                    item = Instantiate(ItmePrefab03);
                }
                //PLayerの移動できる範囲に合わせてItmeを生成できる範囲を決める
                int random = Random.Range(PlayerController.Left, PlayerController.Right + 1);
                float px = random * PlayerController.Move;
                item.transform.position = new Vector3(px, 7, 0);
            }
        }
        //残り時間が半分になったら
        else
        {
            if (this.delta >= this.span_bonus)
            {
                this.delta = 0;
                GameObject item;
                //15個の目のダイス
                int dice = Random.Range(1, 15);
                if (dice <= this.ratio) //ダイスがratio未満なら
                {
                    item = Instantiate(ItmePrefab01);
                }
                else if (dice <= (this.ratio + 3)) //ダイスがratio以下
                {
                    item = Instantiate(ItmePrefab02);
                }
                else if (dice <= (this.ratio + 5)) //ダイスがratio以下なら
                {
                    item = Instantiate(ItmePrefab00);
                }
                else //ダイスがそれ以外なら
                {
                    item = Instantiate(ItmePrefab03);
                }
                //PLayerの移動できる範囲に合わせてItmeを生成できる範囲を決める
                int random = Random.Range(PlayerController.Left, PlayerController.Right + 1);
                float px = random * PlayerController.Move;
                item.transform.position = new Vector3(px, 7, 0);
            }
        }
    }
}