using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField] private int statingPoint;
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float speed;    
    [SerializeField] private bool fullLoop;
    [SerializeField] private bool worksOnSun = true;
    [SerializeField] private bool worksOnRain;

    private int currentWaypoint;
    private bool inverse;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[statingPoint].position;
        currentWaypoint = statingPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameController.instance.isSunny && worksOnSun) || (GameController.instance.isRainy && worksOnRain)) {
            if (fullLoop)
            {
                MoveFullLoop();
            }
            else
            {
                Move();
            }
        }
    }

    private void MoveFullLoop()
    {
        if (Vector2.Distance(transform.position, waypoints[currentWaypoint].position) < 0.02f)
        {
                currentWaypoint++;
            if (currentWaypoint >= waypoints.Count)
            {
                    currentWaypoint = 0;                
            }

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
        }
    }


    private void Move()
    {
        if (Vector2.Distance(transform.position, waypoints[currentWaypoint].position) < 0.02f)
        {
            if ((currentWaypoint + 1 >= waypoints.Count && !inverse) ||(currentWaypoint -1 < 0 && inverse))
            {                
                    inverse = !inverse;
                
            }
            

            if (!inverse)
            {
                currentWaypoint++;
            }
            else
            {
                currentWaypoint--;
            }

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < waypoints.Count - 1; i++)
        {
            Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);

        }
    }
}
