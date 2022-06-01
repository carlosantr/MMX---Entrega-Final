using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletT : MonoBehaviour
{

    [SerializeField] float speed;
    Animator myanim;
    float zzz = 0;
    float direction;
    Vector2 dirBala;
    Animator myAnim;
    bool Impact = false;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();

        GameObject bullet = GameObject.Find("EnemyTorreta");
 
        if (transform.position.x < bullet.transform.position.x)
        {
            dirBala = Vector2.left;
            direction = -1;
        }
        else
        {
            dirBala = Vector2.right;
            direction = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, dirBala, 0.5f, LayerMask.GetMask("Ground", "Player"));
        Impact = (ray.collider != null);
        if (zzz != 0)
        {
            transform.position = new Vector3(zzz, transform.position.y, 0);
        }
        else if (Impact)
        {
            zzz = transform.position.x;
            myAnim.SetBool("Impact", true);
            Object.Destroy(gameObject, 0.5f);
        }
        else
        {
            transform.Translate(new Vector3(direction * speed * Time.deltaTime, 0, 0));
            myAnim.SetBool("Impact", false);
        }
    }
}