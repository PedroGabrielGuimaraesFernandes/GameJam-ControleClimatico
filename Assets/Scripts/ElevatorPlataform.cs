using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPlataform : MonoBehaviour
{
    [SerializeField] private int startingPoint;
    private int currentWaypoint;
    public int CurrentWaypoint { get => currentWaypoint; set => currentWaypoint = value; }

    private void Start()
    {
        currentWaypoint = startingPoint;
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
}
