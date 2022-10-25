using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    private SpriteRenderer spriteRenderer;
    private int currentSprite = 0;
    public float gravity = -9.8f;
    public float strength = 5f;
    public Sprite[] sprites = new Sprite[3];

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        InvokeRepeating("ChangeSprite", 0.15f, 0.15f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction = Vector3.up * strength;
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void ChangeSprite()
    {
        currentSprite++;
        if (currentSprite >= sprites.Length)
        {
            currentSprite = 0;
        }
        spriteRenderer.sprite = sprites[currentSprite];

    }

    private void OnEnable(){
        Vector3 position = transform.position;
        position.y = 0;
        transform.position = position;
        direction = new Vector3(0,0,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hit"))
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (collision.CompareTag("Score"))
        {
            FindObjectOfType<GameManager>().IncrementScore();
        }
    }
}
