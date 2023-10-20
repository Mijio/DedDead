using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;

    [SerializeField, ReadOnly] private Rigidbody2D rb; 
    bool isCanMove = true;
    // Update is called once per frame
    void Update()
    {
        if (!isCanMove) return;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.MovePosition(transform.position + Vector3.up * speed);
            StartCoroutine(WaitForMove());
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.MovePosition(transform.position + Vector3.down * speed);
            StartCoroutine(WaitForMove());
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.MovePosition(transform.position + Vector3.left * speed);
            StartCoroutine(WaitForMove());
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.MovePosition(transform.position + Vector3.right * speed);
            StartCoroutine(WaitForMove());
        }
    }

    IEnumerator WaitForMove()
    {
        isCanMove = false;
        yield return new WaitForSeconds(0.2f);
        isCanMove = true;
    }

    private void OnValidate()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }
}
