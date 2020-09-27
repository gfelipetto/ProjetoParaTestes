using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadilha : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lobisomem")
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("AtivarArmadilha");
            Destruir();
        }
    }
    private void Destruir()
    {
        Destroy(this.gameObject, 3f);
    }
}
