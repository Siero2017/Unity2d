using UnityEngine;

public class GameFinish : MonoBehaviour
{
    private Detector[] _detectors;

    private void OnEnable()
    {
        _detectors = GetComponentsInChildren<Detector>();

        foreach(var detector in _detectors)
        {
            detector.Reached += OnDetectorReached;
        }
    }

    private void OnDetectorReached()
    {
        foreach(var detector in _detectors)
        {
            if (detector.IsReached == false)
            {
                return;
            }                
        }

        Debug.Log("GameFinish");
    }
}
