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
    public GameObject[] slots;

    //public Dictionary<Item, int> itemDict = new Dictionary<Item, int>();//OPCIONAL

    public Item addItem_01;

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
    }

    private async void DisplayItems (){
        for(int i = 0; i < items.Count; i++){
            //UPDATE IMAGEM DOS SLOTS
            slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

            //UPDATE CONTAGEM DOS SLOTS
            slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
            slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();

            //UPDATE ICONE X
            slots[i].transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    private void AddItem(Item _item){
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

    private void RemoveItem(Item _item){

    }

}
