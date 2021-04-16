using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject exp;
   void OnTriggerEnter(Collider col) { 
        var tempExp = Instantiate(exp, transform.position, transform.rotation);
        Destroy(gameObject,0.5f);
        Destroy(tempExp, 1);
        FindObjectOfType<AudioManager>().playAudio("explostion");
    }
}
