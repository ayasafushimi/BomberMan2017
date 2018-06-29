using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



// プレイヤー
public class Player : MonoBehaviour
{

    [SerializeField] private Vector3 velocity;              // 移動方向
    [SerializeField] private float moveSpeed = 5.0f;        // 移動速度
    public GameObject BombBall;
    public int bombBallCount;
    public int maxBomb = 1;
    public List<GameObject> bombball = new List<GameObject>();



    void Update()
    {      
        playerMove();
        DropBomb();
    }

    void playerMove()
    {
        // WASD入力から、XZ平面(水平な地面)を移動する方向(velocity)を得ます
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            velocity.z += 1;
        if (Input.GetKey(KeyCode.A))
            velocity.x -= 1;
        if (Input.GetKey(KeyCode.S))
            velocity.z -= 1;
        if (Input.GetKey(KeyCode.D))
            velocity.x += 1;

        // 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整します
        velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        // いずれかの方向に移動している場合
        if (velocity.magnitude > 0)
        {
            // プレイヤーの位置(transform.position)の更新
            // 移動方向ベクトル(velocity)を足し込みます
            transform.position += velocity;
        }
    }

    void DropBomb()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            if (maxBomb > bombBallCount)
            {
               
                // X 座標と Y 座標を四捨五入
                var pos = new Vector3
                (
                    Mathf.RoundToInt(this.transform.position.x),
                    BombBall.transform.position.y,
                    Mathf.RoundToInt(this.transform.position.z)
                );
             
               
                // 爆弾のゲームオブジェクトを作成
                bombball.Add(Instantiate
                (
                    BombBall,
                    pos,
                    BombBall.transform.rotation
                ) as GameObject);
                bombBallCount++;

                bombball.Last<GameObject>().name = BombBall.name;
            }
                
 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            Destroy(other.gameObject);
        }
    }
}
