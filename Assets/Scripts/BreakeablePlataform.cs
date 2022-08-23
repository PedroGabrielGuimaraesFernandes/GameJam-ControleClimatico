using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakeablePlataform : MonoBehaviour
{

    [SerializeField] private bool worksOnSun;
    [SerializeField] private bool worksOnRain = true;
    [SerializeField] private BoxCollider2D colisor;
    [SerializeField] private float resetTime = 5;

    private Animator anim;
    private int activeIndex;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D BoxCollider2D;
    private float timer;
    private bool isActive;
    private bool isBroken;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        activeIndex = Animator.StringToHash("Active");
        spriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if ((GameController.instance.isSunny && worksOnSun) || (GameController.instance.isRainy && worksOnRain))
        {
            if (!isActive)
            {
                anim.SetTrigger(activeIndex);
            }
            isActive = true;
            timer = Time.time;
        }

        if (isActive && isBroken)
        {
            if (timer + resetTime < Time.time)
            {
                Fixed();
            }
        }
    }


    public void Broken()
    {
        isBroken = true;
        spriteRenderer.enabled = false;
        BoxCollider2D.enabled = false;
        timer = Time.time;
    }

    public void Fixed()
    {
        isActive = false;
        isBroken = false;
        spriteRenderer.enabled = true;
        BoxCollider2D.enabled = true;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isActive)
        {
            isActive = true;
            anim.SetTrigger(activeIndex);
        }
    }

}
