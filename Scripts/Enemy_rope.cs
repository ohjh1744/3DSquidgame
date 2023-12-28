using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_rope : MonoBehaviour
{
    Rigidbody rigid;
    public Rigidbody player;
    public Rigidbody enemy_2;
    public Rigidbody enemy_3;
    public Rigidbody rope;
    public int num;
    public float power;

    public bool g_start;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        player = player.GetComponent<Rigidbody>();
        enemy_2 = enemy_2.GetComponent<Rigidbody>();
        enemy_3 = enemy_3.GetComponent<Rigidbody>();
        rope = rope.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (g_start)
        {
            Pullrope();
        }
    }

    void Pullrope()
    {
        rigid.velocity = new Vector3(0, 0, 1) * power;
        player.velocity = new Vector3(0, 0, 1) * power;
        enemy_2.velocity = new Vector3(0, 0, 1) * power;
        enemy_3.velocity = new Vector3(0, 0, 1) * power;
        rope.velocity = new Vector3(0, 0, 1) * power;
        num = Random.Range(1, 3);
        Invoke("Pullrope", num);
    }
}
