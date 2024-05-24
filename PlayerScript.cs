using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(CharacterController))]
public class PlayerScript : MonoBehaviour
{
    [Header("GameOver")]
    public GameObject gameOverUi;

    [Header("Health")]
    public float playersMaxHealth;
    public float playersHealth;
    public Image playersHealthBar;

    [Header("Script References")]
    public Crosshair crosshair;
    public SMScript SMSscript;

    [Header("Stamina")]
    public Image staminaBar;
    public float stamina;
    public float maxStamina;
    public float runningCost;
    public float rechargeRate;

    [Header("Player")]
    public Camera playerCamera;
    public float walkSpeed = 3f;
    public float runSpeed = 3f;
    public float jumpPower = 0f;
    public float gravity = 7f;
    public float lookSpeed = 2;
    public float lookXLimit = 45f;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;

    public Transform player;

    public bool isMouseVisible;

    public bool canMove = true;

    public GameState gameState;

    public Transform lastCheckpoint;
    void Start()
    {
        SMSscript = FindObjectOfType<SMScript>();
        crosshair = FindObjectOfType<Crosshair>();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GamePaused();
        Invoke("GameRunning",13f);
    }

    void Update()
    {
        if(gameState == GameState.GAME_RUNNING)
        {
            CharactherMovement();
        }
        
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 3f, Color.red);

        // ------------ Players Health Bar -------
        if (playersHealth > playersMaxHealth) playersHealth = playersMaxHealth;
        playersHealthBar.fillAmount = playersHealth / playersMaxHealth;

        // ------ Player reset/last checkpoint ----
        if (playersHealth <= 0)
        {
            characterController.enabled = false;
            canMove = false;
            gameOverUi.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ResetStatsLoadLastCheckpoint()
    {
        player.position = lastCheckpoint.position; Debug.Log("Go to LastCheckpoint");
        characterController.enabled = true;
        gameOverUi.SetActive(false);
        canMove = true;
        MouseVisual();
        Time.timeScale = 1;
        playersHealth = playersMaxHealth;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EmptyVillage"))
        {
            crosshair.PlayerSubAnimation();
            Invoke("ClearPlayerSub", 4.0f);
            GameManager.instance.playerSub.text = "I wonder where the villagers are...";
        }

        if (other.gameObject.CompareTag("HostileArea"))
        {
            GameManager.instance.objectiveText.text = "Find the boat's helm somewhere in the area.";
            crosshair.PlayerSubAnimation();
            Invoke("ClearPlayerSub", 4.0f);
            GameManager.instance.playerSub.text = "This must be where these bastards are living.";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("EmptyVillage"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("HostileArea"))
        {
            Destroy(other.gameObject);
        }

    }

    public void ClearPlayerSub()
    {
        crosshair.playerSubAnim.SetBool("isSub", false);
        crosshair.playerSub.text = "";
    }


    public void CharactherMovement()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift); 

        //conditions for movements (WASD)
        //if ? then : else
        float currentSpeedX;
        float currentSpeedY;

        if (isRunning && stamina > 0) // If running and stamina is not empty
        {
            currentSpeedX = canMove ? runSpeed * Input.GetAxis("Vertical") : 0;
            currentSpeedY = canMove ? runSpeed * Input.GetAxis("Horizontal") : 0;

            // Stamina
            stamina -= runningCost * Time.deltaTime;
            if (stamina < 0) stamina = 0;
            staminaBar.fillAmount = stamina / maxStamina;
            // Stamina Recharge
            if (recharge != null) StopCoroutine(recharge);
            recharge = StartCoroutine(RechargeStamina());

        }
        else
        {
            currentSpeedX = canMove ? walkSpeed * Input.GetAxis("Vertical") : 0;
            currentSpeedY = canMove ? walkSpeed * Input.GetAxis("Horizontal") : 0;
        }

        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * currentSpeedX) + (right * currentSpeedY);


        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && canMove && characterController.isGrounded)
        {
            walkSpeed = 7f;
            player.transform.localScale = new Vector3(1, 0.83f, 1);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            walkSpeed = 10f;
            player.transform.localScale = new Vector3(1, 1.4f, 1);
        }
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    public void MouseVisual()
    {
        if (Cursor.visible == false || Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isMouseVisible = true;
        }
        else if (Cursor.visible == true || Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isMouseVisible = false;
        }
    }
    public void GameRunning()
    {
        gameState = GameState.GAME_RUNNING;
    }

    public void GamePaused()
    {
        gameState = GameState.PAUSED;
    }

    public void GameOver()
    {
        gameState = GameState.GAME_OVER;
        //Time.deltaTime = 0;
    }

    public void CanMoveIt()
    {
        canMove = true;
    }

    private Coroutine recharge;
    private IEnumerator RechargeStamina()
    {
        yield return new WaitForSeconds(1f);
        while (stamina < maxStamina)
        {
            stamina += rechargeRate / 10f;
            if (stamina > maxStamina) stamina = maxStamina;
            staminaBar.fillAmount = stamina / maxStamina;
            yield return new WaitForSeconds(.1f);
        }
    }

  
}