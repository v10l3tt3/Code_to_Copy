using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPersonaje : MonoBehaviour
{
    public float multiplicador = 5f;
    
    public float multiplicadorSalto = 5f;

    private bool puedoSaltar = true;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        transform.position = new Vector3(-14.6f, 2.36f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        float movTeclas = Input.GetAxis("Horizontal"); //(a -1f - d 1f)
        //float MovTeclasY = Input.GetAxis("Vertical"); //(w -1f - s 1f)  por si tiene vuelo
        
        //Debug.Log(Input.GetAxis("Horizontal"));

        /*aproximacion1
            transform.position = new Vector3(
             transform.position.x+(MovTeclas/100),
             transform.position.y,
             transform.position.z
        );*/

        float miDeltaTime = Time.deltaTime; //tiempo que transcurre entre frames

        /*aproximacion2
            transform.Translate(
             MovTeclas*(Time.deltaTime*multiplicador),
             0, 
             0
        );*/

        //movimiento del personaje
        rb.velocity = new Vector2(movTeclas*multiplicador, rb.velocity.y);

        //FLIP
        //1flip <--
        /*if(Input.GetKeyDown(KeyCode.A)){
            //this.GetComponent<SpriteRenderer>().flipX = true;
            transform.localScale = new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z);
        }
        //1flip -->
        if(Input.GetKeyDown(KeyCode.D)){
            //this.GetComponent<SpriteRenderer>().flipX = false;
            transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);
        }*/
        //2flip
        if(movTeclas < 0){
            this.GetComponent<SpriteRenderer>().flipX = true;
        }else if(movTeclas > 0){
            this.GetComponent<SpriteRenderer>().flipX = false;
        }


        //salto
        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar){
            rb.AddForce(
                new Vector2 (0, multiplicadorSalto),
                ForceMode2D.Impulse
                );
            //puedoSaltar = false;
            
        //Mejora de salto
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
        Debug.DrawRay(transform.position, Vector2.down, Color.magenta);

        if(hit){
            puedoSaltar = true;
            Debug.Log(hit.collider.name);
        }else{
            puedoSaltar =false;
        }
        }
    }

    /*aproximacion deteccion de suelo para poder volver a saltar
        void OnCollisionEnter2D(){
            puedoSaltar = true;
        }*/



}
