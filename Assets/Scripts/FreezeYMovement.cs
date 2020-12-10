using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeYMovement : MonoBehaviour
{
    Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
    }

    void Update()
    {
        //figuring out when to save position when attached to BOX
        if(gameObject.transform.parent == null)
        {
            initPos = transform.position;
        }
    }
    void LateUpdate () {
        //If attached to box do not translate do not rotate
        if (gameObject.transform.parent != null)
        {
            transform.position = new Vector3(transform.position.x, initPos.y, transform.position.z);
        }
    }
}
