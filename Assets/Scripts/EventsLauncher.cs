using UnityEngine;
using UnityEngine.Events;

public class EventsLauncher : MonoBehaviour
{
    public UnityEvent deathActions;

    public void LaunchDeathActions()
    {
        deathActions.Invoke();
    }
}