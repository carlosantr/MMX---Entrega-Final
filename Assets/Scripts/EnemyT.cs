using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyT : MonoBehaviour
    
{

        [SerializeField] GameObject Player;
        [SerializeField] GameObject Bullet;
        [SerializeField] GameObject point;
        [SerializeField] float firerate;
        [SerializeField] float PuntosVida;
        AudioSource sound;
        Animator myAnim;
        Vector2 Dir;
        float Dire;
        float NF = 0.0f;
        float NextPuntoVida = 0;
        [SerializeField] AudioClip death;


    void Start()
    {
            myAnim = GetComponent<Animator>();
            if (point.transform.position.x < transform.position.x)
            {
                Dir = Vector2.left;
                Dire = -1;
            }
            else if (point.transform.position.x > transform.position.x) {
                Dir = Vector2.right;
                Dire = 1;
            }   

            sound = GetComponent<AudioSource>();
    }



        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + Dire*9f, transform.position.y, transform.position.z));
        }

    void Update()
    {
        Collider2D colBul = Physics2D.OverlapCircle(transform.position, 1.4f, LayerMask.GetMask("BP"));

        if (colBul != null && Time.time > NextPuntoVida)
        {
            PuntosVida = PuntosVida - 1;
            NextPuntoVida = Time.time + 1.5f;
            
        }
        if (PuntosVida == 0)
        {
            myAnim.SetBool("Destroy", true);
            Destroy(gameObject, 0.5f);
        }
        Shootting();

    }

    void Shootting()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Dir, 9f, LayerMask.GetMask("Player"));

        if (ray != false)
        {
            if (Time.time > NF)
            {
                NF = Time.time + firerate;
                Instantiate(Bullet, point.transform.position, transform.rotation);
            }
        }
    }
}