using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myController : MonoBehaviour
{
    // Move user character

    public float speed = 10.0f;
    private float _verticalMovement;
    private float _horizontalMovement;
    
    void Start()
    {
    }

    void Update()
    {
        //  We move the character 
        _verticalMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        _horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(_horizontalMovement, 0, _verticalMovement);


    }
}