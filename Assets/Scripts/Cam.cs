using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{

    private Transform player;
    [SerializeField]private Vector2 horizontalLimits = new Vector2(-1,30) ;
    [SerializeField]private Vector2 verticalLimits = new Vector2(-1,30) ;
    [SerializeField]private Vector2 cameraWidthLimit = new Vector2(0,30) ;
    [SerializeField]private Vector2 cameraHeightLimit = new Vector2(0,30) ;

    public float smooth;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player.position.x >= horizontalLimits.x && player.position.x <= horizontalLimits.y) {
            Vector3 following = new Vector3(Mathf.Clamp(player.position.x, cameraWidthLimit.x, cameraWidthLimit.y), transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, following, smooth * Time.deltaTime);
        }

        if (player.position.y >= verticalLimits.x && player.position.y <= verticalLimits.y) {
            Vector3 following = new Vector3(transform.position.x,Mathf.Clamp(player.position.y, cameraHeightLimit.x, cameraHeightLimit.y), transform.position.z);
            transform.position = Vector3.Lerp(transform.position, following, smooth * Time.deltaTime);
        }
    }
}
