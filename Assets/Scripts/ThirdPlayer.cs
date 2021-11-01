using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdPlayer : MonoBehaviour
{
    public AudioSource footsteps;
    public CharacterController controller;
    private Animator anim;
    private Vector3 direction;

    public float speed = 5f;
    public float turnSmoothTime = 0.1f;
    private bool isMoving;
    private float turnSmoothVelocity;
    private bool canMove = true;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        footsteps = gameObject.GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (canMove)
        {
            MoveCheck();
            AnimationCheck();
        }
    }

    private void MoveCheck()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
            controller.Move(direction * speed * Time.deltaTime);
        }
    }

    private void AnimationCheck()
    {
        if(direction != Vector3.zero && !isMoving)
        {
            footsteps.Play();
            isMoving = true;
            anim.SetBool("isRunning", isMoving);
        } else if (direction == Vector3.zero && isMoving)
        {
            footsteps.Stop();
            isMoving = false;
            anim.SetBool("isRunning", isMoving);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("zombie"))
        {
            canMove = false;
            SceneManager.LoadScene(3);
            anim.SetTrigger("isDead");
        }
    }

}
