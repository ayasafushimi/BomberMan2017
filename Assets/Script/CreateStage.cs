using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CreateStage : MonoBehaviour
{

    public GameObject UnBreakableWall;
    public GameObject BreakableWall;
    public GameObject PowerUpItem;

    int[,] map = new int[21, 14];





    private void Start()
    {
        NotPlaced();
        InstantiateUnBreakableWall();
        InstantiateBreakableWall();
        ItemGenerator();


    }
    // 壊れないブロックの生成。
    void InstantiateUnBreakableWall()
    {
        //上の壁を作る
        for (int i = 0; i < 20; i++)
        {
            Vector3 createPos = new Vector3(i, 0.5f, 0);
            Instantiate(UnBreakableWall, createPos, Quaternion.identity);
            map[i, 0] = 1;
        }
        //下の壁を作る
        for (int i = 0; i < 20; i++)
        {
            Vector3 createPos = new Vector3(i, 0.5f, 12);
            Instantiate(UnBreakableWall, createPos, Quaternion.identity);
            map[i, 12] = 1;
        }
        //左の壁を作る
        for (int j = 1; j < 12; j++)
        {
            Vector3 createPos = new Vector3(0, 0.5f, j);
            Instantiate(UnBreakableWall, createPos, Quaternion.identity);
            map[0, j] = 1;
        }
        //右の壁を作る
        for (int j = 0; j < 13; j++)
        {
            Vector3 createPos = new Vector3(20, 0.5f, j);
            Instantiate(UnBreakableWall, createPos, Quaternion.identity);
            map[20, j] = 1;
        }



        //１マス空きずつの壊れないブロックを作る

        for (int i = 2; i < 20; i += 2)
        {
            Vector3 createPos = new Vector3(i, 0.5f, 2);
            Instantiate(UnBreakableWall, createPos, Quaternion.identity);
            map[i, 2] = 1;
        }
        for (int i = 2; i < 20; i += 2)
        {
            Vector3 createPos = new Vector3(i, 0.5f, 4);
            Instantiate(UnBreakableWall, createPos, Quaternion.identity);
            map[i, 4] = 1;
        }
        for (int i = 2; i < 20; i += 2)
        {
            Vector3 createPos = new Vector3(i, 0.5f, 6);
            Instantiate(UnBreakableWall, createPos, Quaternion.identity);
            map[i, 6] = 1;
        }
        for (int i = 2; i < 20; i += 2)
        {
            Vector3 createPos = new Vector3(i, 0.5f, 8);
            Instantiate(UnBreakableWall, createPos, Quaternion.identity);
            map[i, 8] = 1;
        }
        for (int i = 2; i < 20; i += 2)
        {
            Vector3 createPos = new Vector3(i, 0.5f, 10);
            Instantiate(UnBreakableWall, createPos, Quaternion.identity);
            map[i, 10] = 1;
        }
    }

    public int maxCountOfBreakableWall;
    int countOfBreakableWall;

    // 壊れるブロックの生成。
    void InstantiateBreakableWall()
    {
        int x;
        int z;
        //壊れる壁を作る
        while (countOfBreakableWall != maxCountOfBreakableWall)
        {
            x = UnityEngine.Random.Range(0, 20);
            z = UnityEngine.Random.Range(0, 13);

            if (map[x, z] == 0)
            {
                Instantiate(BreakableWall, new Vector3(x, 0.5f, z), Quaternion.identity);
                countOfBreakableWall += 1;
                map[x, z] = 2;
            }
        }
    }

    // 初期位置の情報取得。初期位置以外にブロックを生成させる。
    void NotPlaced()
    {
        map[1, 11] = 3;
        map[2, 11] = 3;
        map[1, 10] = 3;
        map[1, 2] = 3;
        map[1, 1] = 3;
        map[2, 0] = 3;
        map[18, 1] = 3;
        map[19, 1] = 3;
        map[19, 2] = 3;
        map[19, 10] = 3;
        map[19, 11] = 3;
        map[18, 11] = 3;
    }

    public int maxCountOfPowerUpItem;
    int countOfPowerUpItem;
    // アイテムの生成。
    void ItemGenerator()
    {

        while (countOfPowerUpItem != maxCountOfPowerUpItem)
        {
            int x;
            int z;

            x = UnityEngine.Random.Range(0, 20);
            z = UnityEngine.Random.Range(0, 13);


            if (map[x, z] == 2)
            {

                Instantiate(PowerUpItem, new Vector3(x, 0.5f, z), Quaternion.identity);
                countOfPowerUpItem += 1;
            }
        }
    }
}


