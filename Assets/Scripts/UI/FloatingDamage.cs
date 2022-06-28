using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FloatingDamage : MonoBehaviour
{
    public Color corInicial;
    public Color corFinal;
    public Vector2 posicaoInicial;
    public Vector2 posicaoFinal;
    public float duracaoAnimacao;
    private float tempoInicial;
    private TextMeshProUGUI dmgText;


    private void Awake()
    {
        dmgText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        tempoInicial = Time.time;
    }

    private void Update()
    {
        float progressoAnimacao = (Time.time - tempoInicial) / duracaoAnimacao;
        if(progressoAnimacao <= 1)
        {
            transform.localPosition = Vector2.Lerp(posicaoInicial, posicaoFinal, progressoAnimacao);
            dmgText.color = Color.Lerp(corInicial, corFinal, progressoAnimacao);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetDamageValue(int Damage)
    {
        dmgText.SetText(Damage.ToString());
    }
}
