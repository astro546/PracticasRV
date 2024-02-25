using System;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Variables publicas de estado y movimiento
    public int state = 1;
    public float rotationSpeed = 15.0f;
    public float moveSpeed = 15.0f;
    Quaternion initialRot = Quaternion.identity;

    //Enumerador de niveles del cilindro
    public enum levels{
        up,
        center,
        down
    }

    public levels level = levels.up;

    //Seteamos la posicion y rotacion inicial de la camara
    private void Start(){
        Vector3 initialPos = new Vector3(0.0f, 17.0f, 0.0f);
        transform.localPosition = initialPos;
        transform.rotation = initialRot;
    }

    //Update se ejecuta cada frame
    private void Update()
    {
        //Variable que registra la posicion actual de la camara cada frame
        Vector3 currentPos = transform.localPosition;

        //Estados:
        // 0.- Camara en reposo
        // 1.- Rotacion de la camara 360 grados
        // 2.- Movimiento hacia abajo
        // 3.- Movimiento hacia arriba
        switch(state){
            case 0:
                transform.localPosition = new Vector3(0.0f, 2.0f, 0.0f);
                break;

            case 1:
                if (!(transform.rotation.y > -0.1f && transform.rotation.y < 0.0f)){
                    transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
                } else {
                    transform.rotation = initialRot;
                    switch(level){
                        case levels.up:
                            state = 2;
                            break;
                        case levels.down:
                            state = 3;
                            break;
                        case levels.center:
                            state = 0;
                            break;
                        default:
                            state = 0;
                            break;
                    }
                }
                break;

            case 2:
                float downPos = -13.0f;
                if (currentPos.y > downPos){
                    transform.position += Vector3.down * Time.deltaTime * moveSpeed;
                }
                else{
                    level = levels.down;
                    state = 1;
                }
                break;

            case 3:
                float centerPos = 2.0f;
                if (currentPos.y < centerPos){
                    transform.position += Vector3.up * Time.deltaTime * moveSpeed;
                } else {
                    level = levels.center;
                    state = 1;
                }
                break;

            default:
                transform.localPosition = Vector3.zero;
                break;
        }
    }
}