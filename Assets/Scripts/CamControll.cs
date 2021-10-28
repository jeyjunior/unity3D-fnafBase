using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CamControll : MonoBehaviour
{
    
    
    public GameController gc;

    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "PC")
        {
            gc.onPC = true;
            if (gc.onPC && Input.GetKeyDown(KeyCode.E))
            {
                gc.activeCams = true;
                gc.panelMap.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "PC")
        {
            gc.onPC = false; gc.activeCams = false;
        }
    }

}
