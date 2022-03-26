using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public GameObject inventoryMenu;

    private void Start()
    {
        inventoryMenu.gameObject.SetActive(false);
    }

    private void Update() {
        InventoryControl();
    }

    private void InventoryControl (){
        if (Input.GetKeyDown(KeyCode.Escape)){        
            if (GameManager.instance.isPaused){
                Resume(); //Se o jogo estiver pausado, presione esc para resumir
            }else{
                Pause();  //Se o jogo estiver rodando, presione esc para pausar
            }
           
        }
    }
    private void Resume(){
        inventoryMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;//Tempo real é 1.0f
        GameManager.instance.isPaused = false;
    }
     private void Pause(){
        inventoryMenu.gameObject.SetActive(true);
        Time.timeScale = 0.0f;//TEMPO PARADO
        GameManager.instance.isPaused = true;
    }
  
}
