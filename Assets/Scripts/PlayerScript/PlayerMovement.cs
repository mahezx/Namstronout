using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;
    public IInteractable Interactable { get; set; }
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public VectorValue startingPosition;

    // Start is called before the first frame update
    private void Start()
    {
        Application.targetFrameRate = 60;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    private void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();

        if (dialogueUI.IsOpen) return;

        if(Input.GetKeyDown(KeyCode.E) && dialogueUI.IsOpen == false)
        {
            if(Interactable != null )
            {
                Interactable.Interact(this);
            }
        }
    }

    private void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    private void MoveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + change.normalized * speed * Time.fixedDeltaTime
        );
    }
}
