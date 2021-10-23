using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CamControll : MonoBehaviour
{

    public Text textMensagem;

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.name == "PC")
        {
            textMensagem.text = "Press Enter to view the cams";
        }
    }

}
