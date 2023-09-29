using TMPro;
using UnityEngine;

public class PlayerAttributesShow : MonoBehaviour
{
    public TextMeshProUGUI healthshowUI;
    [SerializeField]
    PlayerAttributes currenthealth;

    public TextMeshProUGUI nnosofbulletsUI;
    [SerializeField]
    MouseRotation bulbul;

    void Update()
    {
        healthshowUI.text = (currenthealth.playertothealth + "/100");
        nnosofbulletsUI.text = (bulbul.nosofbullets + "/" + bulbul.totnosofbullets);
    }
}
