using UnityEngine;
using UnityEngine.SceneManagement;

public class jugar : MonoBehaviour 
{
    public GameObject menuCanvas;
    public GameObject worldObject;

    private void Start()
    {
        menuCanvas.SetActive(true);
        worldObject.SetActive(false);
    }
    public void Jugar ()
    {
        menuCanvas.SetActive(false);
        worldObject.SetActive(true);
    }

    public void Salir ()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
