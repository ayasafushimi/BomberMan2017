using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{

    public GameObject explosionPrefab;
    public LayerMask levelMask;
    public bool isExploded;
    public GameObject BreakableWall;
    GameObject bomb;
    Player player = new Player();
    //Bomb bm = new Bomb();



    // Use this for initialization
    void Start()
    {
       
        print(player.bombBallCount);
 //       if(bomb)
        {
            Explode();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Explode()
    {


        // 爆風を広げる
        StartCoroutine(CreateExplosions(Vector3.forward)); // 上に広げる
        StartCoroutine(CreateExplosions(Vector3.right)); // 右に広げる
        StartCoroutine(CreateExplosions(Vector3.back)); // 下に広げる
        StartCoroutine(CreateExplosions(Vector3.left)); // 左に広げる


    }

    public IEnumerator CreateExplosions(Vector3 direction)
    {
        // 2 マス分ループする
        for (int i = 1; i < 3; i++)
        {
            // ブロックとの当たり判定の結果を格納する変数
            RaycastHit hit;

            // 爆風を広げた先に何か存在するか確認
            Physics.Raycast
            (
                transform.position + new Vector3(0, 0.5f, 0),
                direction,
                out hit,
                i,
                levelMask
            );



            // 爆風を広げた先に何も存在しない場合            
            if (!hit.collider)
            {

                // 爆風を広げるために、
                // 爆発エフェクトのオブジェクトを作成
                Instantiate
                (
                    explosionPrefab,
                    transform.position + (i * direction),
                    explosionPrefab.transform.rotation
                );
            }
            // 爆風の先がBreakableWallの場合
            if (hit.collider && hit.collider.tag == "BreakableWall")
            {

                // 爆発エフェクトのオブジェクトを作成 
                Instantiate
                (
                explosionPrefab,
                transform.position + (i * direction),
                explosionPrefab.transform.rotation
                );
                // 爆風はこれ以上広げない
                //break;


            }
            // 爆風を広げた先がUnBreakableWall以外の場合
            // 爆風はこれ以上広げない
            else
            {
                break;
            }




            // 0.05 秒待ってから、次のマスに爆風を広げる
            yield return new WaitForSeconds(0.05f);

            print(i);

        }


    }
}