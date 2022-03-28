using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class CharacterController : MonoBehaviour
{
    //  referência universal
    public static GameObject playerObj;

private
    //  Componentes e Variáveis
    Rigidbody2D body;

    float movementSpeed = 5f;
    public static readonly string _MOVE = "Move";
    


public
//          Capturação do Mouse
    /*Pega a posição do mouse na câmera*/
    Vector2 mousePos()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }
    /*Pega a diração que o mouse está apontando*/
    Vector2 mouseDirection()
    {
        Vector2 mouseDir = mousePos() - (Vector2)transform.position;
        return (mouseDir.normalized);
    }


private
        //Capturação do Teclado
    /*Detectar uma tecla pressionada*/
    void keyboardDetect()
    {
        
    }

    private
        //Movimentação e animação
        void movementAndAnimation(){
            Vector2 movDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            gameObject.GetComponent<IsometricRenderer>().SetDirection(movDir, _MOVE, movementSpeed * 2);
            body.MovePosition(body.position + movDir * movementSpeed * Time.deltaTime);
            
        }


            //Funções da Unity




    /*Awake (Iniciada assim que o objeto é instanciado)*/
    void Awake() {
        body = GetComponent<Rigidbody2D>();
        playerObj = this.gameObject;
    }

    /*FixedUpdate (Função iniciada a cada frame, mas utilizado em conjunto da física)*/
    void FixedUpdate() {
        movementAndAnimation();
    }

    /*Update (Função iniciada a cada frame)*/
    void Update() {
        keyboardDetect();
    }

}
