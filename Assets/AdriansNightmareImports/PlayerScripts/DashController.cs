using UnityEngine;

public class DashController : MonoBehaviour
{
    public bool isDashing;
    public float dashSpeed = 150f;
    public float cooldownTime = 2f;

    private float nextDashTime = 0f;
    private float dashStartTime;

    // [SerializeField] ParticleSystem forwardDashparticleSystem;
    // [SerializeField] ParticleSystem backwardDashparticleSystem;
    // [SerializeField] ParticleSystem leftDashparticleSystem;
    // [SerializeField] ParticleSystem rightDashparticleSystem;

    PlayerMoveScript playerController;
    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerMoveScript>();
        characterController = GetComponent<CharacterController>();
        nextDashTime = cooldownTime;
    }

    // Update is called once per frame
    void Update()
    {
        HandleDash();
    }

    void HandleDash()
    {
        bool isTryingToDash = Input.GetKeyDown(KeyCode.LeftControl);
        
        if(Time.time > nextDashTime)
        {
            if (isTryingToDash && !isDashing)
            {
                OnStartDash();
                nextDashTime = Time.time + cooldownTime;
            }
        }

        if (isDashing)
        {
            if(Time.time - dashStartTime <= 0.3f)
            {
                if (playerController.movementVector.Equals(Vector3.zero))
                {
                    // player is not giving any input, just dash forward
                    characterController.Move(transform.forward * dashSpeed * Time.deltaTime);
                }
                else
                {
                    characterController.Move(playerController.movementVector.normalized * dashSpeed * Time.deltaTime);
                }
            }
            else
            {
                OnEndDash();
            }
        }
    }

    void OnStartDash()
    {
        isDashing = true;
        dashStartTime = Time.time;

        //PlayDashParticles();
    }

    void OnEndDash()
    {
        isDashing = false;
        dashStartTime = 0f;
    }

    // void PlayDashParticles()
    // {
    //     Vector3 inputVector = playerController.inputVector;

    //     if (inputVector.z > 0  && Mathf.Abs(inputVector.x) <= inputVector.z)
    //     {
    //         //forward & forward-diagonal
    //         forwardDashparticleSystem.Play();
    //         return;
    //     }

    //     if (inputVector.z < 0 && Mathf.Abs(inputVector.x) <= Mathf.Abs(inputVector.z))
    //     {
    //         //backward & backward-diagonal
    //         backwardDashparticleSystem.Play();
    //         return;
    //     }

    //     if (inputVector.x < 0)
    //     {
    //         leftDashparticleSystem.Play();
    //         return;
    //     }

    //     if (inputVector.x > 0)
    //     {
    //         rightDashparticleSystem.Play();
    //         return;
    //     }

    //     forwardDashparticleSystem.Play();
    // }
}
