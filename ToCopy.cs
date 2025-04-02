using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToCopy : MonoBehaviour
{

    //para reaparecer al morir
    GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.Find("spawner");
        transform.position = spawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
}
