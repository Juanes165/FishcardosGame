using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ParpadeoTexto : MonoBehaviour
{
    private Text textoParpadeante;
    private string textoQueParpadea = "Press any key to play";
    private string textoEnBlanco = "";
    private string textoEstatico = "No parpadea";
    private bool estaParpadeando = true;

    private void Start()
    {
        textoParpadeante = GetComponent<Text>();

        StartCoroutine(TextoParpadeo());
        
    }

    private IEnumerator TextoParpadeo()
    {
        while (estaParpadeando)
        {
            textoParpadeante.text = textoEnBlanco;
            
            yield return new WaitForSeconds(0.5f);

            textoParpadeante.text = textoQueParpadea;
            
            yield return new WaitForSeconds(0.5f);
        }
    }
}
