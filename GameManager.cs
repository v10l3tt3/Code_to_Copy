using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToCopyVidas : MonoBehaviour
{
    public static int vida = 3; 

    public static bool estoyVivo = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(vida == 3);

        if(vida <= 0){
            estoyVivo =  false;
        }
    }

    // copiar en Movimiento, seccion Update 
    // if(GameManager.estiyVivo == false){
        //return;
    //}
}
