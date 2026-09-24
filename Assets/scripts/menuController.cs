using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    public string proximaFase;
    public string menu;
    public GameObject[] itensMenu;
    public GameObject[] itensConfig;
    public GameObject[] itensCreditos;
    public GameObject[] itensvoltandoCreditos;
    public GameObject[] itensMenuEmJogo;
    public GameObject[] ItensMenu2EmJogo;
    public GameObject[] ItensCreditosEmJogo;
    public GameObject[] ItensMenuDeMorte;
    public GameObject[] ItensCreditosEmTelaDeMorte;
    public GameObject[] ItensMenuDeVitoria;
    public GameObject[] ItensCreditosEmTelaDeVitoria;

    public void startGame()
    {
        SceneManager.LoadScene(proximaFase);
    }

    public void voltarParaMenuInicial()
    {
        SceneManager.LoadScene(menu);
    }


    public void configuracoes()
    {
        for (int i = 0; i < itensMenu.Length; i++)
        {
            itensMenu[i].SetActive(false);
        }

        for (int i = 0; i < itensConfig.Length; i++)
        {
            itensConfig[i].SetActive(true);
        }
    }

    public void voltar()
    {
        for (int i = 0; i < itensMenu.Length; i++)
        {
            itensMenu[i].SetActive(true);
        }

        for (int i = 0; i < itensConfig.Length; i++)
        {
            itensConfig[i].SetActive(false);
        }
    }

    public void creditos()
    {
        for (int i = 0; i < itensCreditos.Length; i++)
        {
            itensCreditos[i].SetActive(true);
        }

        for (int i = 0; i < itensMenu.Length; i++)
        {
            itensMenu[i].SetActive(false);
        }


    }

    public void VoltandoDecreditos()
    {
        for (int i = 0; i < itensCreditos.Length; i++)
        {
            itensCreditos[i].SetActive(false);
        }

        for (int i = 0; i < itensMenu.Length; i++)
        {
            itensMenu[i].SetActive(true);
        }


    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void abrindoMenuEmJogo()
    {
        for (int i = 0; i < itensMenuEmJogo.Length; i++)
        {
            itensMenuEmJogo[i].SetActive(true);
        }

        for (int i = 0; i < ItensMenu2EmJogo.Length; i++)
        {
            ItensMenu2EmJogo[i].SetActive(false);
        }

    }
    public void abrindoMenu2EmJogo()
    {
        for (int i = 0; i < itensMenuEmJogo.Length; i++)
        {
            itensMenuEmJogo[i].SetActive(false);
        }

        for (int i = 0; i < ItensMenu2EmJogo.Length; i++)
        {
            ItensMenu2EmJogo[i].SetActive(true);
        }
    }

    public void abrindocreditosEmJogo()
    {
        for (int i = 0; i < itensMenuEmJogo.Length; i++)
        {
            itensMenuEmJogo[i].SetActive(false);
        }

        for (int i = 0; i < ItensCreditosEmJogo.Length; i++)
        {
            ItensCreditosEmJogo[i].SetActive(true);
        }
    }

    public void fechandocreditosEmJogo()
    {
        for (int i = 0; i < itensMenuEmJogo.Length; i++)
        {
            itensMenuEmJogo[i].SetActive(true);
        }

        for (int i = 0; i < ItensCreditosEmJogo.Length; i++)
        {
            ItensCreditosEmJogo[i].SetActive(false);
        }
    }

    public void abrindócreditosemtelademorte()
    {
        for (int i = 0; i < ItensMenuDeMorte.Length; i++)
        {
            ItensMenuDeMorte[i].SetActive(false);
        }

        for (int i = 0; i < ItensCreditosEmTelaDeMorte.Length; i++)
        {
            ItensCreditosEmTelaDeMorte[i].SetActive(true);
        }
    }

    public void abrindócreditosemteladeVitoria()
    {
        for (int i = 0; i < ItensMenuDeVitoria.Length; i++)
        {
            ItensMenuDeVitoria[i].SetActive(false);
        }

        for (int i = 0; i < ItensCreditosEmTelaDeVitoria.Length; i++)
        {
            ItensCreditosEmTelaDeVitoria[i].SetActive(true);
        }
    }
}