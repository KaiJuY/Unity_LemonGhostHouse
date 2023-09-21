using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motion : MonoBehaviour
{
    Vector3 movement;
    Animator anim;
    float rotationspeed = 20f;
    Quaternion rotation;
    Rigidbody rb;
    AudioSource footstep;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        footstep = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
    
        movement.Set(horizontal, 0f, vertical);
        movement.Normalize();

        bool hasHorInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerInput = !Mathf.Approximately(vertical, 0f);

        bool iswalking = hasHorInput | hasVerInput;
        anim.SetBool("iswalking", iswalking);

        if(iswalking)
        {
            if(!footstep.isPlaying)
                footstep.Play();
        }
        else
        {
            footstep.Stop();
        }


        Vector3 rotateDirection = Vector3.RotateTowards(transform.forward, movement, rotationspeed * Time.deltaTime, 0f);
        rotation = Quaternion.LookRotation(rotateDirection);
    }

    void OnAnimatorMove()
    {
        rb.MovePosition(rb.position + movement * anim.deltaPosition.magnitude);
        rb.MoveRotation(rotation);        
    }
}
