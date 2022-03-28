using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisionBlocker : MonoBehaviour
{
    /*Awake é uma função proveniente da própria Unity que é inicializada assim que o objeto no qual possuí este objeto é instanciado*/
    private void Awake()
    {
        //Pega o componente de colisão do pai e do filho e as armazena em variáveis diferentes
        PolygonCollider2D characterCollider = GetComponent<PolygonCollider2D>();
        PolygonCollider2D characterBlockCollider = transform.Find("CharacterCollisionBlocker").gameObject.GetComponent<PolygonCollider2D>();

        //Ignora a colisão entre os dois para que um não afete o outro
        Physics2D.IgnoreCollision(characterCollider, characterBlockCollider, true);
    }
}
