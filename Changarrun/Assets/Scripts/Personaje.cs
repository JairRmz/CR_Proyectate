using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    
    [SerializeField] private float velocidad;
    [SerializeField] private BoxCollider2D colEspada;
    
    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer  spritePersonaje; 
    private float posColX=1;
    private float posColY=0;

    private int vidaPersonaje = 3;

    [SerializeField] UIManager uIManager;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        spritePersonaje = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

          anim.SetTrigger("Ataca");

        }
        if (Input.GetKeyDown(KeyCode.K))
        {
          CausaHerida();
        }
    }

    private void FixedUpdate()
    {

      Movimiento();

    }


    private void Movimiento()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rig.velocity = new Vector2 (horizontal,vertical)*velocidad;
        anim.SetFloat ("Camina", Mathf.Abs(rig.velocity.magnitude));

        if(horizontal > 0){
          colEspada.offset = new Vector2(posColX,posColY);
          spritePersonaje.flipX = false; 

        }else if(horizontal < 0){

          colEspada.offset = new Vector2(-posColX,posColY);
          spritePersonaje.flipX = true; 
         } 


    }


    private void CausaHerida()
    {
      if (vidaPersonaje > 0)
      {
        vidaPersonaje--;  
        uIManager.RestaCorazones(vidaPersonaje); 

        if (vidaPersonaje == 0)
        {
          Debug.Log("Hemos Muerto"); 
        }

      }
    }
}
