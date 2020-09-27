using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovimentoLobinho : MonoBehaviour
{
    public CharacterController controlePersonagem;
    public Animator animacao;
    public LayerMask groundMask;

    public Transform cam;
    public Transform groundCheck;

    public float speed = 6.0f;
    public float suavizar = 0.1f;
    public float groundDistance = 0.4f;
    public float pularAltura = 4f;
    public float gravidade = -9.81f;
    float suavizarVelocidade;

    Vector3 pular;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        if (animacao.GetBool("Uivar") == false)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direcao = new Vector3(horizontal, 0f, vertical).normalized;
            if (!NoChao() && pular.y < 0)
            {
                pular.y = 1.5f;
            }
            if (direcao.magnitude >= 0.1f)
            {
                float pontoAngulo = Mathf.Atan2(direcao.x, direcao.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, pontoAngulo, ref suavizarVelocidade, suavizar);
                transform.rotation = Quaternion.Euler(0f, angulo, 0f);
                Vector3 mover = Quaternion.Euler(0f, pontoAngulo, 0f) * Vector3.forward;
                controlePersonagem.Move(mover.normalized * speed * Time.deltaTime);
            }

            
            
            //if (Input.GetKeyUp(KeyCode.LeftShift))
            //{
            //    speed = 4f;
            //}

            if (NoChao())
            {
                if (Input.GetButtonDown("Jump")) {
                    animacao.SetTrigger("Pulando");
                    pular.y = Mathf.Sqrt(pularAltura * -2f * gravidade);
                }
                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W)) { // correndo pra frente
                    speed = 10f;
                    animacao.SetBool("Andando", false);
                    animacao.SetBool("Correndo", true);
                } else {
                    animacao.SetBool("Correndo", false);

                    if (Input.GetKey(KeyCode.W)) // andando pra frente
                    {
                        speed = 4f;
                        animacao.SetBool("Andando", true);

                    } else {

                        animacao.SetBool("Andando", false);
                    }
                }
                

                //animacao.SetBool("Pular", false);
                //if (Input.GetButtonDown("Jump"))
                
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    animacao.SetTrigger("Atacar");
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    animacao.SetBool("Uivar", true);
                }
            } 
            
            //if (!NoChao())
            //{
            //    animacao.SetBool("Pular", true);
            //}
            animacao.SetFloat("Velocidade", controlePersonagem.velocity.magnitude);
            pular.y += gravidade * Time.deltaTime;
            controlePersonagem.Move(pular * Time.deltaTime);
        }
    }

    private bool NoChao()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    private void TerminarUivo()
    {
        animacao.SetBool("Uivar", false);
    }
}
