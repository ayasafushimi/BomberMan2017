using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExplosionController : MonoBehaviour
{

    public GameObject BreakableWall;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 0.4f);
    }

    // Update is called once per frame
    void Update()
    {


    }

    // 壊れるブロックを破壊。
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "BreakableWall")
        {
            Destroy(other.gameObject);
        }

    }
}
