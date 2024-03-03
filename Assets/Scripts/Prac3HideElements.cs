using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prac3HideElements : MonoBehaviour
{
    //Variable de las escenas
    public int scene = 1;
    public float time = 0.0f;

    //Variable para el cilindro y la esfera. Estos se agregan desde Unity
    public GameObject cylinder;
    public GameObject sphere;

    // Update is called once per frame
    void Update()
    {

        //Si la escena actual es la del skybox, entonces desactivamos la esfera y el cilindro
        if(scene == 3){
            cylinder.SetActive(false);
            sphere.SetActive(false);
        } else {
            cylinder.SetActive(true);
            sphere.SetActive(true);
        }

        if(time < 5.0f){
            time += Time.deltaTime;
        } else {
        
            if (scene < 3){
                scene++;
            } else {
                scene = 1;
            }

            //Cambiamos la posicion de la esfera y el cilindro dependiendo de la escena actual
            if (scene == 1){
                cylinder.transform.position = new Vector3(50.0f, 0.0f, 0.0f);
                sphere.transform.position = new Vector3(0.0f, 2.6f, 0.0f);
            } else if (scene == 2){
                cylinder.transform.position = new Vector3(0.0f, -40.0f, 0.0f);
                sphere.transform.position = new Vector3(50.0f, 0.0f, 0.0f);
            }

            time = 0.0f;
        }
    }
}
