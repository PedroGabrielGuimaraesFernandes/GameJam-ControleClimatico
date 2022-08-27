using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            if (!isActive)
            {
                isActive = true;
                Player player = other.GetComponent<Player>();
                if (player.LastCheckpoint != null)
                {
                    player.LastCheckpoint.isActive = false;
                }
                player.LastGroundedPosition = transform.position;
                player.LastCheckpoint = this;
            }
        }
    }
}
