using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool isInRange = false;
    private KeyCode InteractableKey = KeyCode.F;
    public Dialogue dialogue;
    public GameObject DialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
    public void TriggerDialogue() {
        DialogueBox.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(InteractableKey))
            {
                TriggerDialogue();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player"))
        {
            isInRange = true;
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.CompareTag("Player"))
        {
            isInRange = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
