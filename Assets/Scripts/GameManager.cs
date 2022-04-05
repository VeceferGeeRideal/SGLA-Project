using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public static GameManager instance; //MARKER SINGLETON PATTERN
   public bool isPaused;

    public List<Item> items = new List<Item>();//OS ITENS QUE POSSUI
    public List<int> itemNumbers = new List<int>();//QUANTOS ITENS POSSUI
    public int Coins;//DINHEIRO

    
    public GameObject[] slots;

    public GameObject CoinCounter;
    

    //public Dictionary<Item, int> itemDict = new Dictionary<Item, int>();//OPCIONAL

    public Item addItem_01;
    public Item removeItem_01;

    private void Awake() {
       if (instance == null){
           instance = this;
       } else {
           if (instance != this){
               Destroy(gameObject);
           }
       }
       DontDestroyOnLoad(gameObject);
   }

    private void Start(){
        DisplayItems();
    }

    private void Update (){
        if(Input.GetKeyDown(KeyCode.M))
            AddItem(addItem_01);

        if(Input.GetKeyDown(KeyCode.N))
            RemoveItem(removeItem_01);
   
    }

    private async void DisplayItems (){
        for(int i =0; i< slots.Length; i++){
            if (i < items.Count){
            //UPDATE IMAGEM DOS SLOTS
            slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

            //UPDATE CONTAGEM DOS SLOTS
            slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
            slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();

            //UPDATE ICONE X
            slots[i].transform.GetChild(2).gameObject.SetActive(true);
            } else{ //REMOVER ITEM
            //UPDATE IMAGEM DOS SLOTS
            slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;

            //UPDATE CONTAGEM DOS SLOTS
            slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 0);
            slots[i].transform.GetChild(1).GetComponent<Text>().text = null;

            //UPDATE ICONE X
            slots[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    public void AddItem(Item _item){
        //JÁ POSSUI O ITEM
        if(!items.Contains(_item)){
            items.Add(_item);
            itemNumbers.Add(1); //ADICIONA UM
        }else{ //NÃO POSSUI O ITEM
            Debug.Log("Já tem esse item");
            for(int i = 0; i < items.Count; i++){
                if(_item == items[i]){
                    itemNumbers[i]++;
                }
            }
        }
        DisplayItems();
               
    }
    public void AddCoin(){
        Coins++;
        CoinCounter.GetComponent<Text>().text = Coins.ToString();
        Debug.Log(Coins);
    }

    public void RemoveItem(Item _item){

        if (items.Contains(_item)){ //SE O ITEM JÁ ESTÁ NO IVENTÁRIO
            for(int i = 0;i < items.Count; i++){
                if(_item == items[i]){
                    itemNumbers[i]--; // DIMINUI EM 1 A QUANTIDADE DO ITEM (QUE JÁ ESTÁ NO INV)
                    if (itemNumbers[i]==0){ //SE A QUANTIDADE DO ITEM CHEGAR A ZERO
                        //REMOVER ITEM DO INVENTÁRIO
                        items.Remove(_item); 
                        itemNumbers.Remove(itemNumbers[i]);
                    }
                }
            }
        } else{
            Debug.Log(_item + "não está no inventário!"); //DEBUG PARA TESTES, NÃO IRÁ ACONTECER NO GAMEPLAY
        }
        DisplayItems();
    }

}
