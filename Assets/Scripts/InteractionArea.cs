﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionArea : MonoBehaviour
{
    public GameObject interactionMessage;
    public MercanciaScript mercancia;
    public moneyManager MoneyManager;
    // Start is called before the first frame update
    void Start()
    {
        interactionMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (mercancia && MoneyManager.money >= mercancia.cost)
            {
                MoneyManager.UpdateMoney(-mercancia.cost);
                Destroy(mercancia.gameObject);
                StopInteraction();
            } else if (MoneyManager.money < mercancia.cost)
            {
                Debug.Log("no te alcanza");
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        mercancia = other.GetComponent<MercanciaScript>();
        if (mercancia)
        {
            interactionMessage.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        interactionMessage.SetActive(false);
        mercancia = null;
    }
    void StopInteraction()
    {
        interactionMessage.SetActive(false);
        mercancia = null;
    }
}
