using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Salto : MonoBehaviour
{

    public int miEdad = 23;

    public float miAltura = 5.0f;

    public string miNombre = "Violette";

    public bool tengoMelena = true; 

    public GameObject miCubo; 

    public int numero1 = 10;
    public int numero2 = 80;

    public Vector3 posInicial; 
    public Color miColor;

    public float velocidad = 0.01f; 


    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("Hola. Mi nombre es "+miNombre+". Y tengo "+miEdad+" años.");

       this.GetComponent<Transform>().position = posInicial;

       this.GetComponent<SpriteRenderer>().flipX = true;
       
       
    }

    void Awake()
    {
       // Debug.Log("Soy Awake, soy preferente ante void Start")
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("Hola. Mi nombre es "+miNombre+". Y tengo "+miEdad+" años.");  

       // float positionActual = this.GetComponent<Transform>().position.x;
       // transform.position = new Vector3(positionActual-0.001f,0,0); 

       // transform.Translate(velocidad,0,0); 

       // Debug.Log(transform.rotation); pero funciona con quaternions = 0.00, 0.00, 0.00, 1.00
       // transform.Rotate(0,0,velocidad);
       // transform.localScale = new Vector3(velocidad,0,0);

         // para ir a la izquierda con la A
         if(Input.GetKey(KeyCode.A)){
            transform.Translate(velocidad*-1, 0, 0);
         }

         // para ir a la derecha con la D
         if(Input.GetKey(KeyCode.D)){
            transform.Translate(velocidad, 0, 0);
         }
    }

   // void OnGUI(){
     // if(Event.current.isMouse == true){
       //  Debug.Log(Event.current.type.ToString());
     // }
   // }
}
