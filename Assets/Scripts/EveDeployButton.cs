using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EveDeployButton : MonoBehaviour
{
    [Header("Setup")]
    public Eve eveData;                     
    public EveSpawner spawner;             
    public int laneIndex = 0;

    [Header("UI")]
    public TextMeshProUGUI buttonText;

    private Button button;

    private void Awake() {
        button = GetComponent<Button>();
        button.onClick.AddListener(Deploy);
        UpdateButtonText();
    }

    private void Deploy() {
        spawner.SpawnEve(eveData, laneIndex);
    }

    private void UpdateButtonText() {
        if (buttonText != null && eveData != null) {
            buttonText.text = $"{eveData.name} [{eveData.manaCost}]";
        }
    }
}
