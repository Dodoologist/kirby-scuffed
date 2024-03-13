using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float x;
    public int score = 0;
    public TMP_Text text;
    public float speed, jumpforce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myInput();
        if(score == 5)
        {
            StartCoroutine("Win");
            FindObjectOfType<audio_manager>().Play("Saved");
        }
    }
    private void FixedUpdate() {
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
        text.text = ""+score;
    }

    private void myInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up*jumpforce*2, ForceMode2D.Impulse);
            FindObjectOfType<audio_manager>().Play("Jump");
        }
    }

    IEnumerator Win()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);        
    }
}
