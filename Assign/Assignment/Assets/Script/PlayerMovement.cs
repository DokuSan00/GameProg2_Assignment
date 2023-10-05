using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerMovement Instance;
    //speed
    public float mouseSen = 2.0f;
    private float walkSpeed = 3.5f;
    private float runSpeed = 6.5f;

    public int maxJump;
    public bool isGround;
    public float gravityVal = -9.81f;


    //private
    private float jumpPower = 1.3f;
    private bool doubleJump;
    private Vector3 playerVector;
    private Vector3 verticalVector;
    private Vector3 horizontalVector;
    private bool jumpAni;
    
    //GetComponent
    private Animator animator;
    private CharacterController controller;
    public GameObject powerEffect;
    public GameObject center;

    private void Awake() {
        Instance = this;
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        doubleJump = false;
        jumpAni = false;
        
        powerEffect = Instantiate(powerEffect, center.transform.position, center.transform.rotation, gameObject.transform);
    }

    void EnableRootMotion() {
        animator.applyRootMotion = true;
    }
    void DisableRootMotion() {
        animator.applyRootMotion = false;
    }

    void Update()
    {
        ProcessGravity();
        if (!animator.applyRootMotion)
        {
            ProcessMovementInput();
        }
        ProcessMove();
    }

    void LateUpdate()
    {
        UpdateAnimation();
        UpdateEffect();
    }

    void UpdateEffect() {
        if (doubleJump)
            powerEffect.SetActive(true);
        else
            powerEffect.SetActive(false);
    }

    void UpdateAnimation() {
        
        // animator.ResetTrigger("JumpTrigger");
        if (isGround) 
        {
            animator.SetBool("isGround", true);
            //idle/walk/run
            if (horizontalVector != Vector3.zero)
            {   
                float curSpeed = GetSpeed() / runSpeed;
                float speedAni = animator.GetFloat("Speed") + curSpeed * Time.deltaTime;
                animator.SetFloat("Speed", Mathf.Clamp(speedAni, 0 , curSpeed));   
            } 
            else 
            {
                animator.SetFloat("Speed", 0.0f);
                
            }
        }
        else {
            animator.SetBool("isGround", false);
        }
        //to handle multi jump
        if (jumpAni) {
            animator.ResetTrigger("JumpTrigger");
            animator.SetTrigger("JumpTrigger");
            //set jumpAni back to false, allow next jump if available
            jumpAni = false;
        }
    }

    void ProcessMove()
    {
        playerVector = verticalVector * Time.deltaTime + horizontalVector;
         if (horizontalVector != Vector3.zero)
        {
            gameObject.transform.forward = horizontalVector;
        }
        controller.Move(playerVector);
    }

    void ProcessGravity()
    {
        isGround = controller.isGrounded;
        if (isGround)
        {
            verticalVector.y = -1.0f;
        }
        else
        {
            verticalVector.y += gravityVal * Time.deltaTime;
        }
    }

    void JumpInput() {
        bool isGrounded = controller.isGrounded;
        if (Input.GetButtonDown("Jump") && (isGrounded || doubleJump))
        {
            if (!isGrounded && doubleJump)
                doubleJump = false;
            verticalVector.y = Mathf.Sqrt(jumpPower * -3.0f * gravityVal);
            jumpAni = true;
        }
    }
    
    void ProcessMovementInput()
    {
        float speed = Mathf.Clamp(GetSpeed() * animator.GetFloat("Speed") + 0.5f, 0.2f, GetSpeed());

        //Get camera vector
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;

        // gameObject.transform.rotation = Quaternion.Euler(camForward + camRight);
        
        camForward.y = 0;
        camRight.y = 0;

        camForward.Normalize();
        camRight.Normalize();
        
        JumpInput();

        //Set dir according to cam dir
        Vector3 moveDir = (camForward * Input.GetAxis("Vertical")) + (camRight * Input.GetAxis("Horizontal"));
        horizontalVector = moveDir * speed * Time.deltaTime;
    }

    //add 1 jump count
    public void JumpIncrement()
    {
        doubleJump = (!doubleJump) ? true : doubleJump;
    }

    float GetSpeed()
    {
        if (Input.GetKey(KeyCode.Mouse1))
            return runSpeed;
        else return walkSpeed;
    }

}
