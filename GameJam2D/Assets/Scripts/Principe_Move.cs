using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Principe_Move : MonoBehaviour
{
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Prince_Move", true);

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Prince_Move", true);
    }
}
