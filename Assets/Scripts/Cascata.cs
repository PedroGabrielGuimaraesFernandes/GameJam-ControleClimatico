using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cascata : MonoBehaviour
{

    [SerializeField] private bool worksOnSun;
    [SerializeField] private bool worksOnRain = true;

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
            Activate();
        }
        else
        {
            Deactivate();
        }
    }

    void Activate()
    {
        spriteRenderer.enabled = true;
        boxCollider.enabled = true;
    }

    void Deactivate()
    {
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
    }
}
