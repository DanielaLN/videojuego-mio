using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSHOU : MonoBehaviour 
{
    public GameObject menuPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            bool estaActivo = menuPanel.activeSelf;
            menuPanel.SetActive(!estaActivo);
        }
    }

    public void Guardar()
    {
        GameObject jugador = GameObject.FindWithTag("Player");
        if (jugador != null)
        {
            PlayerPrefs.SetFloat("PosX", jugador.transform.position.x);
            PlayerPrefs.SetFloat("PosY",jugador.transform.position.y);
        }
        PlayerPrefs.SetString("Escena",SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
        Debug.Log("Partida guardada");
    }
}
