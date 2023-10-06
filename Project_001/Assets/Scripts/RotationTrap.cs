using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTrap : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    private float rotation;
    void Start()
    {
        
    }

    void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        rotation = rotation + Time.deltaTime * rotateSpeed;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}
