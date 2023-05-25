using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;
    public float rotationSped=10f;
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v=Input.GetAxis("Vertical");

        Vector3 directionVector = new Vector3(-v, 0, h);//���� ������������ 
        if(directionVector.magnitude >Mathf.Abs( 0.05f) ) 
        transform.rotation= Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(directionVector),Time.deltaTime+10);

        animator.SetFloat("Speed",Vector3.ClampMagnitude(directionVector,1).magnitude);
        rigidbody.velocity =Vector3.ClampMagnitude( directionVector,1)*speed;
    }
}
