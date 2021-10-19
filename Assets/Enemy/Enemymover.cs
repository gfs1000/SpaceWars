using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range( 0f, 5f )] float enemySpeed = 1f;

    void findPath()
    {
        path.Clear();

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

        foreach(GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<Waypoint>());
        }
    }

    void returnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float interpolationRatio = 0f;
            transform.LookAt(endPosition);

            while (interpolationRatio < 1)
            {
                interpolationRatio += Time.deltaTime * enemySpeed;
                transform.position = Vector3.Lerp(startPosition, endPosition, interpolationRatio);
                yield return new WaitForEndOfFrame();
            }
            
        }
        Destroy(gameObject);
    }
    void Start()
    {
        findPath();
        returnToStart();
        StartCoroutine(FollowPath());
    }

   
}
