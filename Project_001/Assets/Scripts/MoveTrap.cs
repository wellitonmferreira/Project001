using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrap : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject point1, point2;
    [SerializeField] private Vector2 nextPos;

    void Update()
    {
        MovingTrap();
    }

    private void MovingTrap()
    {
        if(transform.position == point1.transform.position)
        {
            nextPos = point2.transform.position;
        }

        if (transform.position == point2.transform.position)
        {
            nextPos = point1.transform.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

}
