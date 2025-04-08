using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class ToCopy : MonoBehaviour
{
    //pre-codigo para enemigo fantasma 
    public int vidaFantasma = 10;
    public float velocidad = 1;
    public float limiteDcha = 5;
    public float limiteIzda = 5;

    private Vector3 posInicial;
    private Vector3 posLimitDcha;
    private Vector3 posLimitIzda;
    public bool dirFantasmaDerecha = true; 
    private string estadoFantasma = "Patrol";

    private GameObject player; 

    private float distancia;

    public float distanciaAtaque = 5;
    public float distanciaPatrol = 15;

    public float velocidadAtaque = 2;

    //para reaparecer al morir
    GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {
        //posicion y mov limite de fantasma
        posInicial = transform.position;
        posLimitDcha = new Vector3 (posInicial.x+limiteDcha,posInicial.y,0);
        posLimitIzda = new Vector3 (posInicial.x-limiteIzda,posInicial.y,0);
        //flip fantasma
        this.GetComponent<SpriteRenderer>().flipX = true;

        //encontrar al personaje mediante el Tag 
        player = GameObject.Find("Player");

        
        //encontrar el gameObject del tag spawner 
        spawn = GameObject.Find("spawner");
        transform.position = spawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {   
        //parala muerte del fantasma 
         if(vidaFantasma <= 0){
        Destroy(this.gameObject);
        }

        ////bloque comportamiento patrulla
        if( estadoFantasma == "Patrol"){
            
            //direccion, velocidad FLOTANDO fantasma -->
            if(dirFantasmaDerecha == true){
            transform.Translate(velocidad*Time.deltaTime,0,0);
             }
             //direccion, velocidad FLOTANDO fantasma <--
            if(dirFantasmaDerecha == false){
            transform.Translate((velocidad*Time.deltaTime)*-1,0,0);
             }
            //comprobar transpaso limite fantasma -->
            if(transform.position.x >= posLimitDcha.x){
            dirFantasmaDerecha= false;
            }
         //comprobar transpaso limite fantasma <--
            if(transform.position.x <= posLimitDcha.x){
            dirFantasmaDerecha= true;
            }
        }

        //distancia entre jugador-player y enemigo-fantasma
        distancia = Vector3.Distance(transform.position, player.transform.position);
        if(distancia <= distanciaAtaque ){
            estadoFantasma = "Ataque";
        }
        if(distancia >= distanciaPatrol ){
            estadoFantasma = "Patrol";
        }

        //Modo de patrulla, aun no ha visto al personaje 
        if(estadoFantasma == "Patrol"){}

        //Modo de ataque, ya ha visto al personaje y lo va a perseguir
        if(estadoFantasma == "Ataque"){
            transform.position = Vector3.MoveTowards(
                transform.position, player.transform.position, velocidadAtaque*Time.deltaTime
                );

                //flip de sprite del fantasma
            if(player.transform.position.x <= transform.position.x){
                this.GetComponent<SpriteRenderer>().flipX = false;
            }else{
                this.GetComponent<SpriteRenderer>().flipX = true;
            }

        }
        
        
        //y (altura)
        if(transform.position.y <= 10){
            transform.position = spawn.transform.position;
        }

        /* (movido a otro Script de Spikes)
    void CollisionEnter2D(Collision2D col)
    {
       // if(col.gameObject.name == "Square"){
            //col.gameObject.GetComponent<SpriteRenderer>().color; //no completo, falta poner el color al que cambia
        //}
        if(col.gameObject.name.StartsWith("Spikes")){
            //quitar vida
            transform.position = spawn.transform.position;

        }*/

    }

    void OnCollisionEnter2D(Collision2D col)
    {   //para que el fastame dañe al personaje (las vidas en GameManager siempre)
        if(col.gameObject.tag == "Player"){
            GameManager.vida -=1;
        }
    }
        //TAREAS PERDIDAS: 1. Poner monedas que se puedan pillar (animación al colisionar y desaparecer) 
        //                                     (beneficio en contador, pero también en rojo para restar)
        //               + 2. Enemigo/Fantasma con movimiento propio (rigidbody en Kinematic)
        //               + 3. Animacion Ataque del personaje a los enemigos (en mago son proyectiles)
        //               + 4. Introducir recurso de "Nubes", slice, nuevo Script "Parallax":
        /*  GameObject player; (este no)
            GameObject camera;
            public float velocidadParallax = 1;
            - void Start-
                player = GameObject.FindWithTag("Player"); (este no)
                camera = GameObject.FindWithTag("MainCamera");
            - void Update-
                transform.position = player.transform.position * velocidadParallax;   (este no)(* un 0. es una division)
                transform.position = camera.transform.position * velocidadParallax; (+aplicar diferentes valores a cada decorado segun la distancia, + lejos = + lento)
        */
}
