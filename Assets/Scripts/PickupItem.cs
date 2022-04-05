using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Item itemData;
    public GameObject pickupEffect;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" & this.tag != "Coin"){
            if (GameManager.instance.items.Count < GameManager.instance.slots.Length){
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
                
                GameManager.instance.AddItem(itemData);
            }else{
                Debug.Log("O inventário está cheio!");
            }
        } 
        if (this.tag == "Coin"){
            Debug.Log("Você pegou uma moeda!");
            if (GameManager.instance.items.Count < 999999){
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);

                GameManager.instance.AddCoin();
            }
        }
            
    }
}
