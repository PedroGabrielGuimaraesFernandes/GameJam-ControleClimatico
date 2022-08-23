using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int health;
    public float speed;
    public float jumpForce;

    //public GameObject arrow;
    //public Transform firePoint;

    private bool isJumping;
    private bool doubleJump;
    private bool isFiring;
    private Rigidbody2D rig;
    //private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        //GameController.instance.UpdateLives(health);
        rig = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {        
        Jump();
        //BowFire();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        //andando pra direita
        if(movement > 0)
        {
            if(!isJumping)
                //anim.SetInteger("Transition", 1);

            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        
        //andando pra esquerda
        if(movement < 0)
        {
            if (!isJumping)
                //anim.SetInteger("Transition", 1);

            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if(movement == 0 && !isJumping && !isFiring)
        {
            //anim.SetInteger("Transition", 0);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                //anim.SetInteger("Transition", 2);
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isJumping = true;
                doubleJump = true;
            }
            else if(doubleJump)
            {
                //anim.SetInteger("Transition", 2);
                rig.AddForce(new Vector2(0, jumpForce * 1), ForceMode2D.Impulse);                
                doubleJump = false;
            }
        }
    }

    //void BowFire()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        StartCoroutine("Fire");
    //    }
    //}

    //IEnumerator Fire()
    //{
    //    isFiring = true;
    //    anim.SetInteger("Transition", 3);
    //    Instantiate(arrow, firePoint.position, firePoint.rotation);
    //    yield return new WaitForSeconds(.2f);
    //    isFiring = false;
    //    anim.SetInteger("Transition", 0);
    //}

    public void Damage(int dmg)
    {
        health -= dmg;
        GameController.instance.UpdateLives(health);
        //anim.SetTrigger("Hit");

        if (transform.rotation.y == 0)
        {
            //rig.AddForce(Vector2.left * 5, ForceMode2D.Impulse);
            transform.position += new Vector3(-1f, 0, 0);
        }
        else if (transform.rotation.y == 180)
        {
            //rig.AddForce(Vector2.right * 5, ForceMode2D.Impulse);
            transform.position += new Vector3(1f, 0, 0);
        }

        if (health <= 0)
        {
            //chama game over
            GameController.instance.GameOver();
        }
    }

    public void IncreaseLife(int value)
    {
        health += value;
        GameController.instance.UpdateLives(health);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == 6)
        {
            isJumping = false;
        }

        if (other.gameObject.layer == 7)
        {
            GameController.instance.GameOver();
        }
    }
}
