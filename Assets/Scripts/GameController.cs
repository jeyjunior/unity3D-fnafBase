using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool activeCams = false, onPC = false;
    public TextMeshProUGUI textMensagem;

    public FirstPersonController playerMove;
    public GameObject panelMap;

    public GameObject cam1;

    private void Start()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        panelMap.SetActive(false); //Desativa panelMap ao iniciar game
    }

    private void Update()
    {
        CamsControll();
    }






    void CamsControll()
    {
        if (onPC && !activeCams)
        {
            TextControll(true, "press 'E' to active cams");
            PlayerMoveControll(true);
        }
        else if (onPC && activeCams)
        {
            TextControll(false, "");
            PlayerMoveControll(false);

        }
        else if (!onPC)
        {
            TextControll(false, "");
            PlayerMoveControll(true);
        }
    }

    void PlayerMoveControll(bool move)
    {
        
        if (move) //Habilita movimentação do player
        {
            playerMove.enabled = true; 
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else //Desativa movimentação do player
        {
            playerMove.enabled = false; 
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
    }

    void TextControll(bool value, string msg)
    {
        textMensagem.gameObject.SetActive(value);
        textMensagem.text = msg;
    }

    //Botões
    public void SairPanelMapa()
    {
        panelMap.SetActive(false);
        activeCams = false;
    }
}
