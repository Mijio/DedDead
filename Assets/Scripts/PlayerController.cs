using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;

    [SerializeField, ReadOnly] private Rigidbody2D rb;
    [SerializeField, ReadOnly] private Animator animator;
    bool isCanMove = true;
    bool isAlive = true;
    private static readonly int DieHash = Animator.StringToHash("Die");
    private static readonly int WinHash = Animator.StringToHash("Win");
    public bool IsAlive => isAlive;
    void Update()
    {
        if (!isCanMove) return;
        if (!isAlive) return;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(transform.position + Vector3.up * speed);
            StartCoroutine(WaitForMove());
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(transform.position + Vector3.down * speed);
            StartCoroutine(WaitForMove());
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(transform.position + Vector3.left * speed);
            StartCoroutine(WaitForMove());
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(transform.position + Vector3.right * speed);
            StartCoroutine(WaitForMove());
        }
    }

    public void Die()
    {
        isAlive = false;
        animator.SetTrigger(DieHash);
    }
    public void Win()
    {
        isAlive = false;
        animator.SetTrigger(WinHash);
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
