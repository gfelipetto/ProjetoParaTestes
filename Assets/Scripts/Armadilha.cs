using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadilha : MonoBehaviour
{
    private MovimentoLobinho lobo;

    private void Start ( ) {
        lobo = FindObjectOfType<MovimentoLobinho>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lobisomem")
        {
            
            lobo.enabled = false;
            this.gameObject.GetComponent<Animator>().SetTrigger("AtivarArmadilha");
            Destruir();
        }
    }
    private void Destruir()
    {
        
        Destroy(this.gameObject, 3f);
    }

    private void OnDestroy ( ) {
        
        lobo.enabled = true;
    }
}
