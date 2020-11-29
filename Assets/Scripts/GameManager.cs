using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private ObjectiveUI _objectiveUI;
    private int _objectivesCount = 0;
    private int _totalObjectives = 5;

    private void Awake()
    {
        _objectiveUI = FindObjectOfType<ObjectiveUI>();
    }

    public void AddObjective()
    {
        _objectivesCount++;
        _objectiveUI.UpdateObjectives(_objectivesCount, _totalObjectives);
    }

}