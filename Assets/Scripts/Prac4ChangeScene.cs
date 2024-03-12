using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Prac4ChangeScene : MonoBehaviour
{

    public int scene = 1;
    public GameObject Scenes;
    public Camera GameCamera;
    public Light GameLight;
    public GameObject CanvasObject;

    public void nextScene()
    {
        if(scene < 4){
            scene++;
        }else{
            scene = 1;
        }
    }

    public void previousScene()
    {
        if(scene > 1){
            scene--;
        }else{
            scene = 4;
        }
    }

    void ChangeColor(Color colorBtn){
        foreach(Transform child in CanvasObject.transform){
            Button button = child.GetComponent<Button>();
            if(button != null){
                button.GetComponent<Image>().color = colorBtn;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Scenes.transform.localPosition = new Vector3(29.0f, 1.0f, 557.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Obtenemos la rotacion actual de la camara
        //La obtenemos con eulerAngles porque la rotacion se maneja con cuateriones
        float cameraYRotation = GameCamera.transform.eulerAngles.y;

        //El limite negativo en -25 se evalua en 335, ya que Unity no maneja angulos negativos (360 - 25 = 335)
        if (cameraYRotation <= 17.0f || cameraYRotation >= 335.0f)
        {
            ChangeColor(Color.green);
        }
        else
        {
            ChangeColor(Color.red);
        }
    
        //La luz direccional apunta a donde esta mirando la camara
        GameLight.transform.rotation = GameCamera.transform.rotation;

        //El cilindro, esfera y cilindro de fotos se desactivan cuando se reproduce el video
        if(scene != 4) {
            Scenes.SetActive(true); 
        } else{
            Scenes.SetActive(false);
        }

        switch(scene){
            case 1:
                Scenes.transform.localPosition = new Vector3(29.0f, 1.0f, 557.0f);
                break;
            case 2:
                Scenes.transform.localPosition = new Vector3(400.0f, 1.0f, 557.0f);
                break;
            case 3:
                Scenes.transform.localPosition = new Vector3(800.0f, 1.0f, 557.0f);
                break;
            default:
                Scenes.transform.localPosition = new Vector3(29.0f, 1.0f, 557.0f);
                break;
            
        }
    }
}
