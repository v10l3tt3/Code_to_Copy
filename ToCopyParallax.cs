using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToCopyParallax : MonoBehaviour
{   
    //GameObject player; 
    GameObject maincamera;
    public float velocidadParallax = 1; 
    // (+aplicar diferentes valores a cada decorado segun la distancia, + lejos = + lento)
    // (* un 0. es una division + un num. negativo cambia de -> a <-)
    public Vector3 posInicial;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindWithTag("Player");
        maincamera = GameObject.FindWithTag("MainCamera");
        posInicial = transform.position;
    
    }
    // Update is called once per frame
    void Update()
    {
        //transform.position = player.transform.position * velocidadParallax;
        transform.position = new Vector3(
            posInicial.x+(maincamera.transform.position.x*velocidadParallax), //X
            posInicial.y+(maincamera.transform.position.y*velocidadParallax), //Y
            0 //Z
            );
    }
    //void FixedUpdate()
}
