using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyV : MonoBehaviour
{
    [SerializeField] GameObject Player;
    AIPath mypath;
    [SerializeField] float PuntosVida;
    Animator myAnim;
    float NextPuntoVida = 0;
    AudioSource sound;
    [SerializeField] AudioClip death;


    // Start is called before the first frame update
    void Start()
    {
        mypath = GetComponent<AIPath>();
        myAnim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 6.2f);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, 5.5f, LayerMask.GetMask("Player"));
        Collider2D colBul = Physics2D.OverlapCircle(transform.position, 1f, LayerMask.GetMask("BP"));

        if (col != null)
        {
            mypath.isStopped = false;
        } else
        {
            mypath.isStopped = true;
        }

        if (colBul != null && Time.time>NextPuntoVida)
        {
            PuntosVida = PuntosVida - 1;
            Debug.Log(PuntosVida);
            NextPuntoVida = Time.time + 1.5f;

        }
        if (PuntosVida == 0)
        {
            myAnim.SetBool("Destroy", true);
            Destroy(gameObject, 0.5f);
        }



    }




}
