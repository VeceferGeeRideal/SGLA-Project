using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject pauseMenu;

    

    private void Start()
    {
        inventoryMenu.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
    }

    private void Update() {
        InventoryControl();
    }

    private void InventoryControl (){
        bool inv = false;
        bool pse = false;

        if (Input.GetKeyDown(KeyCode.Tab)){        
            if (GameManager.instance.isPaused){
                Resume(); //Se o jogo estiver pausado, presione esc para resumir
            }else{
                inv = true;
                Pause(inv);  //Se o jogo estiver rodando, presione esc para pausar
            }                      
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
          
             if (GameManager.instance.isPaused){
                Resume(); //Se o jogo estiver pausado, presione esc para resumir
            }else{
                pse = true;
                Pause(pse);  //Se o jogo estiver rodando, presione esc para pausar
            }
            
        }
        
    }
    private Pause(){
        Time.timeScale = 0.0f;//TEMPO PARADO
        GameManager.instance.isPaused = true;
        if (inv == true){
            pauseMenu.gameObject.SetActive(true);
        }else if (pse == true){
            inventoryMenu.gameObject.SetActive(true);
        }
    }
    private void Resume(){
        inventoryMenu.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;//Tempo real é 1.0f
        GameManager.instance.isPaused = false;
        
    }
  
}
