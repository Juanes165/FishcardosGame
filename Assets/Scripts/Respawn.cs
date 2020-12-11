using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{

    private float respawnPointX, respawnPointY;


    public void PlayerRespawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
