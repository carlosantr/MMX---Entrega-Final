using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float firerate;
    [SerializeField] int jumforce;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject point;
    AudioSource sound;
    [SerializeField] AudioClip shoot;
    [SerializeField] AudioClip kill;
    [SerializeField] AudioClip jump;

    Rigidbody2D mybody;
    Animator myanim;
    bool IsGrounded = true;
    float nextbullet = 0;
    float dirH = 0;

    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
        myanim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 1.3f, LayerMask.GetMask("Ground"));

        IsGrounded = (ray.collider != null);
        Jump();
        Fire();

    }

    void Fire()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            myanim.SetLayerWeight(1, 1);
            if (Time.time >= nextbullet)
            {
                nextbullet = Time.time + firerate;
                Instantiate(bullet, point.transform.position, transform.rotation);
                sound.PlayOneShot(shoot, 1f);
            }
            
        }
        else
        {
            myanim.SetLayerWeight(1, 0);
        }

    }


    void Jump()
    {
        if (IsGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                sound.PlayOneShot(jump, 1f);
                mybody.AddForce(new Vector2(0, jumforce), ForceMode2D.Impulse);
            }
        }
        
        if (mybody.velocity.y != 0 && !IsGrounded) { 
            myanim.SetBool("Jumping", true);
        }else {
            myanim.SetBool("Jumping", false);
        }

    }

    private void FixedUpdate()
    {
        dirH = Input.GetAxis("Horizontal");
                
        if (dirH != 0)
        {
            myanim.SetBool("Running", true);
            if (dirH < 0)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                transform.localScale = new Vector2(1, 1);            
            }             
        }
        else
        {
            myanim.SetBool("Running", false);
        }          

        mybody.velocity = new Vector2(dirH * speed, mybody.velocity.y);
    }

    IEnumerator Perder()
    {
        myanim.SetBool("Death", true);
        yield return new WaitForSeconds(2);
        sound.PlayOneShot(kill, 2f);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Juego");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            mybody.bodyType = RigidbodyType2D.Static;
            StartCoroutine(Perder());
        }
    }
}
