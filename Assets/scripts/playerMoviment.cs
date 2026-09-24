using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMoviment : MonoBehaviour
{
    public CharacterController controller;
    float initialSpeed;
    public float speed = 6f;
    public float runningSpeed = 12f;

    public float gravity = -10f;
    public float jumpHeight;

    public int lifePlayer = 100;
    public int lifePlayerMax = 100;
    [SerializeField] private vida barraDeVida;

    public GameObject blooInScreen;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    bool isDead = false;

    private Animator anim;

    public GameObject parabens;

    private Vector3 diraction;

    public GameObject attack;
    public float attackDuration = 0.3f;

    private bool isAttacking = false;


    public GameObject painelConfiguracoes;

    void Start()
    {
        anim = GetComponent<Animator>();
        initialSpeed = speed;
        lifePlayerMax = lifePlayer;
        blooInScreen.SetActive(false);
        parabens.SetActive(false);


        if (attack != null)
        {
            attack.SetActive(false);
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        barraDeVida.alterarBarradeVida(lifePlayer, lifePlayerMax);
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        float moveRun = Input.GetAxis("run");

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        diraction = new Vector3(moveX, 0, moveZ);
        if (moveX != 0 || moveZ != 0) 
        {
            anim.SetBool("walk", true);
            transform.Translate(0, 0, speed * Time.deltaTime);

            if (moveRun != 0)
            {
                anim.SetBool("run", true);
                speed = runningSpeed;
            }
            else 
            {
                anim.SetBool("run", false);
                speed = initialSpeed;
            }
        }
        else if (moveX == 0 && moveZ == 0)
        {
            anim.SetBool("run", false);
            anim.SetBool("walk", false);
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            if (anim != null)
            {
                anim.SetBool("jump", true);
                anim.SetBool("walk", false);
                anim.SetBool("run", false);
            }
        }

        if (isGrounded && velocity.y < 0)
        {
            if (anim != null)
            {
                anim.SetBool("jump", false);
            }
        }

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity*Time.deltaTime);

        if (lifePlayer <= 0 && !isDead)
        {
            isDead = true;

            speed = 0;

            if (anim != null)
            {
                anim.SetBool("deth", true);
            }

            StartCoroutine(deth());
        }

        if (powerPlayer.peguei) 
        { 
            parabens.SetActive(true);
            StartCoroutine(apagar());
        }
        else
        {
            parabens.SetActive(false);
        }

        if (Input.GetButtonDown("attack") && !isAttacking && !isDead)
        {
            StartCoroutine(Attack());
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            painelConfiguracoes.SetActive(!painelConfiguracoes.activeSelf);

            if (painelConfiguracoes.activeSelf)
            {
                Time.timeScale = 0f;

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1f;

                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            painelConfiguracoes.SetActive(!painelConfiguracoes.activeSelf);

            if (painelConfiguracoes.activeSelf)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("monster"))
        {
            lifePlayer -= 10;

            barraDeVida.alterarBarradeVida(lifePlayer, lifePlayerMax);

            blooInScreen.SetActive(true);
        }
    }

    IEnumerator deth()
    {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("gameOver");

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    IEnumerator apagar() 
    {
        yield return new WaitForSeconds(3);
        parabens.SetActive(false);
    }

    IEnumerator Attack()
    {
        isAttacking = true;

        if (anim != null)
        {
            anim.SetBool("attack", true);
        }

        attack.SetActive(true);

        yield return new WaitForSeconds(attackDuration);

        attack.SetActive(false);

        if (anim != null)
        {
            anim.SetBool("attack", false);
        }

        isAttacking = false;
    }
}


