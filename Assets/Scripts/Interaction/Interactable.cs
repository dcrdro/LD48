using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public InteractorBase[] interactors;
    public bool disableAfterInteract;
    //public Text interactText;
    //public GameObject interactMessage;
    
    bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        // interactText.text += interactors[0].Name;
        // interactMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            print("interacted");
            foreach (var additionalInteractor in interactors)
            {
                Debug.Log("additionalInteractor = " + additionalInteractor);
                additionalInteractor.OnInteract();
            }
            GetComponent<Collider2D>().enabled = !disableAfterInteract;
            enabled = !disableAfterInteract;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var x = other.GetComponentInChildren<Player>();
        if (x != null && x.TryGetComponent<Player>(out var chel))
        {
            inRange = true;
            // interactMessage.SetActive(true);

            print("enter interact");
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        var x = other.GetComponentInChildren<Player>();
        if (x != null && x.TryGetComponent<Player>(out var chel))
        {
            inRange = false;
            // interactMessage.SetActive(false);

            print("exit interact");
        }
    }
}
