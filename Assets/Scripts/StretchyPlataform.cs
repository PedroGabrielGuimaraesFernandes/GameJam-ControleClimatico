using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchyPlataform : MonoBehaviour
{

    [SerializeField] private float speed = 1;
    [SerializeField] private float maxLength = 1;
    [SerializeField] private float timeLimit = 5;
    [SerializeField] private bool growToThRight = true;
    [SerializeField] private bool worksOnSun = true;
    [SerializeField] private bool worksOnRain;

    private bool canGrow = true;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
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
            if (transform.localScale.x < maxLength)
            {
                transform.localScale = new Vector3(transform.localScale.x + (speed * Time.deltaTime), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                canGrow = false;
                timer = Time.time;
            }
        }
        else
        {
            if (transform.localScale.x > -maxLength)
            {
                transform.localScale = new Vector3(transform.localScale.x - (speed * Time.deltaTime), transform.localScale.y, transform.localScale.z);
            }
        }
    }

    void ReturnToNormal()
    {
        if (growToThRight)
        {
            if (transform.localScale.x > 1)
            {
                transform.localScale = new Vector3(transform.localScale.x - (speed/2 * Time.deltaTime), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                canGrow = true;
            }
        }
        else
        {            
            if (transform.localScale.x < 1)
            {
                transform.localScale = new Vector3(transform.localScale.x + (speed/2 * Time.deltaTime), transform.localScale.y, transform.localScale.z);
            }
        }
    }

   
}
