using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSprict : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    public GameObject ClearText;

    private void DestroySelf(){
        Destroy(gameObject);
        ClearText.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
    animator.SetTrigger("Get");
    audioSource.Play();
        
    }

    // Start is called before the first frame update
     void Start()
     {
     animator = GetComponent<Animator>();
     audioSource = gameObject.GetComponent<AudioSource>();
     ClearText.SetActive(false);
     }

     // Update is called once per frame
     void Update()
     {
       
     }
}