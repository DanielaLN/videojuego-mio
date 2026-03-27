using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    public float leftLimit;

    public float rightLimit;

    void Start()
    {

    }

    void Update()
    {
        if(target.position.x > leftLimit && target.position.x < rightLimit)
        {
            transform.position =  new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z);
        }

    }
}
