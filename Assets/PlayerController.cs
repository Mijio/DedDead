using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;

    [SerializeField, ReadOnly] private Rigidbody2D rb; 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.MovePosition(transform.position + Vector3.up * speed);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.MovePosition(transform.position + Vector3.down * speed);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.MovePosition(transform.position + Vector3.left * speed);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.MovePosition(transform.position + Vector3.right * speed);
        }
    }

    private void OnValidate()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }
}
