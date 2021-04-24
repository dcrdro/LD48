using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public InteractorBase interactor;
    public bool disableAfterInteract;
    public Text interactText;
    public GameObject interactMessage;

    public InteractorBase[] additionalInteractors;
    
    bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        interactText.text += interactor.Name;
        interactMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            print("interacted");
            interactor.OnInteract();
            foreach (var additionalInteractor in additionalInteractors)
            {
                additionalInteractor.OnInteract();
            }
            GetComponent<Collider2D>().enabled = !disableAfterInteract;
            enabled = !disableAfterInteract;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out var chel))
        {
            inRange = true;
            interactMessage.SetActive(true);

            print("enter interact");
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out var chel))
        {
            inRange = false;
            interactMessage.SetActive(false);

            print("exit interact");
        }
    }
}
