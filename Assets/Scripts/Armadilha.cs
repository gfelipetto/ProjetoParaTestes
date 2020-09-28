using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadilha : MonoBehaviour
{
    private MovimentoLobinho lobo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lobisomem")
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("AtivarArmadilha");
            lobo = other.GetComponent<MovimentoLobinho>();
            lobo.animacao.SetBool("Uivar", true);
            Destruir();
        }
    }
    private void Destruir()
    {
        Destroy(this.gameObject, 3f);
    }
}
