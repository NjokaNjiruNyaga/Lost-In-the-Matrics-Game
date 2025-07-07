using UnityEngine;

public class CharacterRun : MonoBehaviour
{
    public float playerspeed = 20.0f;
    public float gravity = 9f;
    public float verticalspeed = 0;
    public float mousesensitivity = 2f;
    public float uplimit = 60f;
    public float downlimit = -45f;

    private Animator anim;
    private CharacterController controller;
    private PlayerAudio audioHandler;

    public Transform mycam;
    public AudioClip wallThump;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        audioHandler = GetComponent<PlayerAudio>();
    }

    void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(0, mouseX * mousesensitivity, 0);

        Vector3 currentRotation = mycam.localEulerAngles;
        currentRotation.x -= mouseY * mousesensitivity;

        if (currentRotation.x > 180f) currentRotation.x -= 360f;
        currentRotation.x = Mathf.Clamp(currentRotation.x, downlimit, uplimit);

        mycam.localRotation = Quaternion.Euler(currentRotation);
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * vertical + transform.right * horizontal;
        move.Normalize();

        if (controller.isGrounded)
        {
            verticalspeed = 0;
        }
        else
        {
            verticalspeed -= gravity * Time.deltaTime;
        }

        Vector3 gravityMove = new Vector3(0, verticalspeed, 0);
        Vector3 fullMove = (move * playerspeed + gravityMove) * Time.deltaTime;

        controller.Move(fullMove);

        bool isMoving = move.magnitude > 0.1f;

        if (anim != null)
        {
            anim.SetBool("canrun", isMoving);
        }

        if (audioHandler != null)
        {
            if (isMoving)
                audioHandler.StartRunning();
            else
                audioHandler.StopRunning();
        }
    }

    void Update()
    {
        Rotate();
        Move();

        // DEBUG input
        Debug.Log("H: " + Input.GetAxis("Horizontal"));
        Debug.Log("V: " + Input.GetAxis("Vertical"));

        // DEBUG key input
        if (Input.GetKey(KeyCode.Home)) Debug.Log("HOME is pressed");
        if (Input.GetKey(KeyCode.End)) Debug.Log("END is pressed");
        if (Input.GetKey(KeyCode.PageUp)) Debug.Log("PAGE UP is pressed");
        if (Input.GetKey(KeyCode.PageDown)) Debug.Log("PAGE DOWN is pressed");
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Wall"))
        {
            if (AudioManager.Instance != null && wallThump != null)
            {
                AudioManager.Instance.PlaySoundEffect(wallThump);
            }
        }
    }

   

}
