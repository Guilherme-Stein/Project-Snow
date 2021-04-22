using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Animations : MonoBehaviour
{
    private Animator playerAnimator;
    public Transform groundCheck,playerInclinado;
    public Rigidbody2D playerRB;
    public bool ground, lookLeft, doubJump,atiInclinar;
    public int idAnimation;
    public float speed, jumpForce, h, v, tempo = 0;
    public Text EstrelaTxt, TempoTxt;
    public int estrelas = 0;
    public GameObject[] panel;
    public GameObject[] estrela;

    public GameObject Spawn,Player;
    public GameObject barreira;
    private D2FogsPE D3;

    //Código Teste
    public int vida =3;
    public Text vidaTxt;

    //Static variable
    static int empurrar = 2;

    void Start()
    {       
        
        playerAnimator = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();
        D3 = FindObjectOfType(typeof(D2FogsPE)) as D2FogsPE;

    }
    private void FixedUpdate()
    {
        ground = Physics2D.OverlapCircle(groundCheck.position, 0.02f);
        playerRB.velocity = new Vector2(h * speed, playerRB.velocity.y);
        if(atiInclinar == true)
        {
            playerRB.velocity = new Vector2(empurrar * speed, playerRB.velocity.y);
        }
    }

    void Update()
    {
        tempo += Time.deltaTime;
        TempoTxt.text = tempo.ToString(format:"F0") + " Segundos";
        vidaTxt.text = vida.ToString();
        EstrelaTxt.text = estrelas.ToString();

        if (atiInclinar != true)
        {
            h = Input.GetAxisRaw("Horizontal");

            v = Input.GetAxisRaw("Vertical");

            transform.Rotate(0f, 0f, 0f);
        }
       

        if (h > 0 && lookLeft == true)
        {
            Flip();
        }
        if (h < 0 && lookLeft == false)
        { 
            Flip();
        }
        
        playerAnimator.SetBool("ground", ground);

        playerAnimator.SetInteger("idAnimation", idAnimation);

        playerAnimator.SetFloat("speedY", playerRB.velocity.y);

    
        if (h != 0)
        {
            idAnimation = 1;
        }
        else
        {
            idAnimation = 0;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (ground == true)
            {
                playerRB.AddForce(new Vector2(0, jumpForce));
                doubJump = true;
            }
            else
            {
                if(doubJump)
                {
                    playerRB.AddForce(new Vector2(0, jumpForce));
                    doubJump = false;
                }

            }
        }

        if (atiInclinar == true)
        {
            h = 0;
            if (h == 0)
            {
                idAnimation = 2;
            }
        }
        if (atiInclinar == false)
        {
            transform.Rotate(0f, 0f, 0f);
            groundCheck.Rotate(0f, 0f, 0f);
        }
    }
    void Flip()
    {
        lookLeft = !lookLeft;
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "barreira")
        {
            
            playerRB.transform.position = new Vector3(Spawn.transform.position.x,Spawn.transform.position.y);
            vida--;
        }

        if (collision.gameObject.tag == "Estrela")
        {
            Destroy(collision.gameObject);
            estrela[0].SetActive(true);
            estrela[1].SetActive(false);
            estrelas++;
        }

        if (collision.gameObject.tag == "Parede" && estrelas >= 10)
        {
            panel[0].SetActive(true);
            Time.timeScale = 0f;
            D3.Density = 0f;
        }
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Inimigo")
        {
            vida = -1;
            D3.Density = 0f;
        }
        if (vida <= 0)
        {
            panel[1].SetActive(true);
            Time.timeScale = 0;
        }
        //Dano espinho
        if (collision.gameObject.tag == "EspinhoMove")
        {
            vida--;
            D3.Density = 0f;
        }
        //Verificação de ladeira
        if (collision.gameObject.tag =="Escorregar")
        {
            atiInclinar = true;
            transform.Rotate(0f, 0f, -30f);
            groundCheck.Rotate(0f, 0f, -30f);
        }
        if (collision.gameObject.tag == "Chao")
        {
            Player.transform.Rotate(playerInclinado.rotation.x, playerInclinado.rotation.y, playerInclinado.rotation.z);
        }
        if (collision.gameObject.tag =="Pulao")
        {
            jumpForce = 1000;
            playerRB.AddForce(new Vector2(0, jumpForce));
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
     
        atiInclinar = false;
        jumpForce = 200;
    }


    public void carregaCena (string nCena)
    {
        SceneManager.LoadScene(nCena);
        Time.timeScale = 1f;
    }


}
