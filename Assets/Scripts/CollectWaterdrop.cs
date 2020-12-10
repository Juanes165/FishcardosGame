using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectWaterdrop : MonoBehaviour
{
    public Animator animator;
    Animation animation;
    AnimatorClipInfo[] animatorClipInfo;

    public Image image;


    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 0f);
            FindObjectOfType<OxigenCounter>().dropCollected();
        }
    }
}
