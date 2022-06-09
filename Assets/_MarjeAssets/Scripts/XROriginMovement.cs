using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class XROriginMovement : MonoBehaviour
{
    [SerializeField] InputActionAsset playerControls;
    InputAction movement;

    CharacterController character;
    Vector3 moveVector;
    [SerializeField] float speed = 5f;
    // Start is called before the first frame update
    private void Start()
    {
        var gameplayActionMap = playerControls.FindActionMap("Default"); //call it the name of the action (in this case Default)

        movement = gameplayActionMap.FindAction("Move");

        movement.performed += OnMovementChanged;
        movement.canceled += OnMovementChanged;
        movement.Enable();

        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        character.Move(moveVector * speed * Time.fixedDeltaTime);
    }

    public void OnMovementChanged(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        moveVector = new Vector3(direction.x, 0, direction.y);
    }
}
