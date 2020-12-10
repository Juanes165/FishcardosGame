using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxigenCounter : MonoBehaviour
{
    private Animator animator;
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
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] animationClip = animator.GetCurrentAnimatorClipInfo(0);
        AnimatorStateInfo animationInfo = animator.GetCurrentAnimatorStateInfo(0);
        time = animationClip[0].clip.length * animationInfo.normalizedTime * animationDuration;
        if(time > animationDuration){
            //Debug.Log("Se acabo el oxigeno");
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
            oxigen = 0.8f - (animationPlayed / animationDuration);
        }
        Debug.Log("Oxigeno: ");
        Debug.Log(oxigen);
        animator.Play("Oxigen", 0, oxigen);
        animationDuration = 5 * (oxigen);
        Debug.Log("Animacion: ");
        Debug.Log(animationDuration);
    }
}
