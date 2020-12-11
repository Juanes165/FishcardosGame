using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxigenCounter : MonoBehaviour
{
    public GameObject player;

    private Animator animator;
    private AnimatorClipInfo[] animationClip;
    private float animationDuration;
    private float animationPlayed;
    private float speed = 0.2f;
    private float time;
    private float oxigen;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = speed;
        animationDuration = 1 / speed;
        animationClip = animator.GetCurrentAnimatorClipInfo(0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("OxigenFinished"))
        {
            player.transform.GetComponent<Respawn>().PlayerRespawn();
        }
        
    }

    public void dropCollected()
    {
        animationPlayed = animationDuration - time;
        if(animationPlayed / animationDuration + 0.2f >= 1f)
        {
            oxigen = 1f;
        }
        else
        {
            oxigen = 1f;
        }
        animator.Play("Oxigen", 0, oxigen);
        animationDuration = 5 * (oxigen);

        
        
    }
}
