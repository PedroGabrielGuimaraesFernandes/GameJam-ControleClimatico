using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchyPlataform : MonoBehaviour
{

    [SerializeField] private float speed = 1;
    [SerializeField] private float maxLength = 1;
    [SerializeField] private float timeLimit = 5;
    [SerializeField] private float unitValue = 2.5f;
    [SerializeField] private GameObject ponta;
    [SerializeField] private bool growToThRight = true;
    [SerializeField] private bool worksOnSun = true;
    [SerializeField] private bool worksOnRain;

    private bool canGrow = true;
    private float timer;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameController.instance.isSunny && worksOnSun) || (GameController.instance.isRainy && worksOnRain))
        {
            if (canGrow)
            {
                Stretch();
            }
            else if(!canGrow && (timer + timeLimit) < Time.time )
            {
                ReturnToNormal();
            }
        }
        else
        {
            ReturnToNormal();
        }
    }



    void Stretch()
    {
        if (growToThRight)
        {
            if (spriteRenderer.size.x < maxLength * unitValue)
            {
                //transform.localScale = new Vector3(transform.localScale.x + (speed * Time.deltaTime), transform.localScale.y, transform.localScale.z);
                spriteRenderer.size = new Vector2(spriteRenderer.size.x + (speed * Time.deltaTime), spriteRenderer.size.y);
                boxCollider.size = new Vector2(spriteRenderer.size.x , boxCollider.size.y);
                boxCollider.offset = new Vector2(spriteRenderer.size.x / 2, boxCollider.offset.y);
                if (transform.rotation.y == 0)
                    ponta.transform.position = new Vector3(ponta.transform.position.x + (speed * Time.deltaTime * spriteRenderer.gameObject.transform.localScale.x), ponta.transform.position.y, ponta.transform.position.z);
                else
                    ponta.transform.position = new Vector3(ponta.transform.position.x - (speed * Time.deltaTime * spriteRenderer.gameObject.transform.localScale.x), ponta.transform.position.y, ponta.transform.position.z);
            }
            else
            {
                canGrow = false;
                timer = Time.time;
            }
        }
        else
        {
            if (spriteRenderer.size.x > -maxLength)
            {
                //transform.localScale = new Vector3(transform.localScale.x - (speed * Time.deltaTime), transform.localScale.y, transform.localScale.z);
            }
        }
    }

    void ReturnToNormal()
    {
        if (growToThRight)
        {
            if (spriteRenderer.size.x > 0)
            {
                //transform.localScale = new Vector3(transform.localScale.x - (speed/2 * Time.deltaTime), transform.localScale.y, transform.localScale.z);
                spriteRenderer.size = new Vector2(spriteRenderer.size.x - (speed * Time.deltaTime), spriteRenderer.size.y);
                boxCollider.size = new Vector2(spriteRenderer.size.x, boxCollider.size.y);
                boxCollider.offset = new Vector2(spriteRenderer.size.x / 2, boxCollider.offset.y);
                if(transform.rotation.y == 0)
                ponta.transform.position = new Vector3(ponta.transform.position.x - (speed * Time.deltaTime * spriteRenderer.gameObject.transform.localScale.x), ponta.transform.position.y, ponta.transform.position.z);
                else
                    ponta.transform.position = new Vector3(ponta.transform.position.x + (speed * Time.deltaTime * spriteRenderer.gameObject.transform.localScale.x), ponta.transform.position.y, ponta.transform.position.z);
            }
            else
            {
                canGrow = true;
            }
        }
        else
        {            
            if (transform.localScale.x < 0)
            {
                //transform.localScale = new Vector3(transform.localScale.x + (speed/2 * Time.deltaTime), transform.localScale.y, transform.localScale.z);
            }
        }
    }

   
}
