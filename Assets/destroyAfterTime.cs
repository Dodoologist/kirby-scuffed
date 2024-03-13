using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfterTime : MonoBehaviour
{
    public float Time = 5;
    void Start()
    {
        StartCoroutine("destroyAfterTimeOrSomething");
    }
    IEnumerator destroyAfterTimeOrSomething()
    {
        yield return new WaitForSeconds(Time);
        Destroy(gameObject);
    }
}
