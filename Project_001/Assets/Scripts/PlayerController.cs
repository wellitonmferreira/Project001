using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject beginPoint;
    Vector2 moveInput;

    void Start()
    {
        transform.position = beginPoint.transform.position;
    }

    void Update()
    {       
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        transform.Translate(moveInput * Time.deltaTime * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Trap") == true)
        {
            transform.position = beginPoint.transform.position;
        }
    }
}
