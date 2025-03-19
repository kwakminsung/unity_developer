using UnityEngine;

public class object_flow : MonoBehaviour
{
    private Vector3 target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Update()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, target, 2f);
        Vector3 velo = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velo, 0.1f);
    }
}
