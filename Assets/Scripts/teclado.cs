using UnityEngine;
using TMPro;

public class teclado: MonoBehaviour
{
    private TMP_Text tmpText;

    private void Start()
    {
        tmpText = GetComponent<TMP_Text>();
        Invoke(nameof(HideText), 10f);

    }

    void HideText()
    {
        tmpText.enabled = false; 
    }

}
