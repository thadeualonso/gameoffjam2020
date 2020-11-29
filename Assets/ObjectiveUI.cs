using UnityEngine;
using TMPro;

public class ObjectiveUI : MonoBehaviour
{
    private TextMeshProUGUI _objectiveLabel;

    private void Awake()
    {
        _objectiveLabel = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateObjectives(int current, int total)
    {
        _objectiveLabel.text = $"Objectives\n{current}/{total}";
    }
}
