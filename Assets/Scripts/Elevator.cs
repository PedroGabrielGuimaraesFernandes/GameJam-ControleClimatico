using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private List<ElevatorPlataform> plataforms;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool worksOnSun;
    [SerializeField] private bool worksOnRain = true;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameController.instance.isSunny && worksOnSun) || (GameController.instance.isRainy && worksOnRain))
        {            
                Move();
        }
    }

    //tem que fazer mover cada uma das plataformas
    private void Move()
    {
        foreach (var plataform in plataforms)
        {
            if (Vector2.Distance(plataform.transform.position, waypoints[plataform.CurrentWaypoint].position) < 0.02f)
            {
                plataform.CurrentWaypoint++;
                if (plataform.CurrentWaypoint >= waypoints.Count)
                {
                    plataform.CurrentWaypoint = 0;
                }
            }
            else
            {
                plataform.transform.position = Vector2.MoveTowards(plataform.transform.position, waypoints[plataform.CurrentWaypoint].position, speed * Time.deltaTime);
                //plataform.transform.localRotation = Quaternion.RotateTowards(plataform.transform.localRotation, waypoints[plataform.CurrentWaypoint].localRotation, rotationSpeed * Time.deltaTime) ;
                plataform.transform.localRotation =  waypoints[plataform.CurrentWaypoint].localRotation;
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < waypoints.Count; i++)
        {
            if (i < waypoints.Count - 1)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
            }
            else
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[0].position);
            }

        }
    }
}
