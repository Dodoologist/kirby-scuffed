using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fly : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FindObjectOfType<audio_manager>().Play("Waddle");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg - 90;
        Debug.Log(angle);
        transform.localEulerAngles = new Vector3(0, 0, angle);
        rb.position += new Vector2((transform.up * Time.deltaTime * speed).x, (transform.up * Time.deltaTime * speed).y);
        speed += 0.1f * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.GetComponent<playerMovement>() != null)
        {
            Destroy(other.gameObject);
            FindObjectOfType<audio_manager>().Play("Death");
            StartCoroutine("Die");
        }
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);
    }
}
