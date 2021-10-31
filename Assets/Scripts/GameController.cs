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
    public GameObject panelMap, panelCams;

    public GameObject playerCam, cam1, cam2;

    private void Start()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        PanelsControll(false, false);
    }

    private void Update()
    {
        CamsControll();
    }





    //Com base na interação do player com o PC exibimos msgs ou desativamos/habilitamos move do player
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

    //Habilitar e desabilitar a movimentação do player qndo interagir com o PC
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
    void PanelsControll(bool pMap, bool pCams)
    {
        panelMap.SetActive(pMap);
        panelCams.SetActive(pCams);
    }


    public void SairPanelMapa()
    {
        PanelsControll(false, false);
        activeCams = false;
    }
    public void VoltarPanelCam()
    {
        PanelsControll(true, false);
        EnabledCams(false, false);
    }

    #region Botão para habilitar/desabitar cameras
    //Nome do btn define qual cam sera ativada
    public void BtnCam(GameObject btn)
    {
        PanelsControll(false, true);
        switch (btn.name)
        {
            case "cam1":
                EnabledCams(true, false);
                break;
            case "cam2":
                EnabledCams(false, true);
                break;
            default:
                EnabledCams(false, false);
                break;
        }
    }

    void EnabledCams(bool c1, bool c2)
    {
        //Define qual cam fica ativada / desativada
        cam1.SetActive(c1);
        cam2.SetActive(c2);
    }
    #endregion

}
