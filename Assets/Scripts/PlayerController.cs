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
    [SerializeField] private AudioSource digSound;
    [SerializeField] private AudioSource digSideSound;
    [SerializeField] private AudioSource dieSound;
    
    bool isCanMove = true;
    bool isAlive = true;
    private static readonly int DigUpHash = Animator.StringToHash("DIG");
    private static readonly int DigSideHash = Animator.StringToHash("DigSide");
    private static readonly int DieHash = Animator.StringToHash("Die");
    private static readonly int WinHash = Animator.StringToHash("Win");
    private static readonly int dedHash = Animator.StringToHash("DED");
    public bool IsAlive => isAlive;
    float dir = 0;

    private void Start()
    {
        dir = transform.localScale.x;
    }
    
    public void SetSkin(int skin)
    {
        animator.SetInteger(dedHash, skin);
    }
    
    public void PlayDigSound()
    {
        digSound.Play();
    }
    public void PlayDigSideSound()
    {
        digSideSound.Play();
    }
    public void PlayDieSound()
    {
        dieSound.Play();
    }

    void Update()
    {
        if (!isCanMove) return;
        if (!isAlive) return;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(transform.position + Vector3.up * speed);
            animator.SetTrigger(DigUpHash);
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
            animator.SetTrigger(DigSideHash);
            transform.localScale = new Vector3(dir, transform.localScale.y, transform.localScale.z);
            StartCoroutine(WaitForMove());
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(-dir, transform.localScale.y, transform.localScale.z);
            rb.MovePosition(transform.position + Vector3.right * speed);
            animator.SetTrigger(DigSideHash);
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
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }
}
