using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalMove;
    private Vector3 playerInput;
    public float verticalMove;
    public CharacterController player;

    public float playerSpeed;
    private Vector3 movePlayer;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    public Animator PlayerAnimatorController;

    void Start()
    {
        player = GetComponent<CharacterController>();
        PlayerAnimatorController = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        PlayerAnimatorController.SetFloat("PlayerWalk", playerInput.magnitude * playerSpeed);

        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        player.transform.LookAt(player.transform.position + movePlayer);

        player.Move(movePlayer * playerSpeed * Time.deltaTime);
    }

    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
}