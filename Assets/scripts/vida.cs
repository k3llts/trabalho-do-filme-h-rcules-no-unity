using UnityEngine;
using UnityEngine.UI;

public class vida : MonoBehaviour
{
    [SerializeField] private Image barraDeVida;

    public void alterarBarradeVida(int vidaAtual, int vidaMaxima)
    {
        barraDeVida.fillAmount = (float)vidaAtual / vidaMaxima;
    }
}