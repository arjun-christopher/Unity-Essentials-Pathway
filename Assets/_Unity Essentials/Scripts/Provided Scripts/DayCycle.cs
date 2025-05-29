using UnityEngine;

public class DayCycle : MonoBehaviour

{
    [Tooltip("The length of one full day in seconds.")]
    public float dayDurationInSeconds = 120f; // Default value of 120 seconds for a full day
    
    private float rotationSpeed;

    void Start()
    {
        // Calculate the speed of rotation based on the duration of the day
        rotationSpeed = 360f / dayDurationInSeconds; // 360 degrees for a full rotation (one day)
    }

    void Update()
    {
        // Rotate the light every frame
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
