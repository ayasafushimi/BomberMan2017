using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public GameObject explosionPrefab;
    public LayerMask levelMask;
    public bool isExploded;
    public GameObject BreakableWall;
	BombManager BM = new BombManager();
    GameObject explosion;


    // Use this for initialization
    void Start()
    { 
        Invoke("Explode", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Explode()
    {
        // 爆弾の位置に爆発エフェクトを作成
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // 爆弾の設置数を制限する。
        GameObject.Find("unitychan").GetComponent<Player>().bombBallCount--;


        // 爆弾を非表示
        gameObject.SetActive(false);



    }

}