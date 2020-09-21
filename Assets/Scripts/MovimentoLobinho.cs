using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoLobinho : MonoBehaviour
{
    public Animator lobo;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            lobo.SetBool("Andar", true);
        }
    }
}
