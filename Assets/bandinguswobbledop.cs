using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class bandinguswobbledop : MonoBehaviour
{
    public GameObject particle;
    private void OnTriggerEnter2D(Collider2D other) {
        other.GetComponent<playerMovement>().score ++;
        Instantiate(particle, transform.position, quaternion.identity);
        FindObjectOfType<audio_manager>().Play("Nom");
        Destroy(this.gameObject);
    }
}
