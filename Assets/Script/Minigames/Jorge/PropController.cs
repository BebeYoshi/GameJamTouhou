using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropController : MonoBehaviour
{
    public List<Vector3> spawners;
    public GameObject jorgem4;

    // Start is called before the first frame update
    void Start()
    {
        spawners = new List<Vector3>()
        {
            new Vector3(-9.8f, 0.5f, 0),
            new Vector3(-7.8f, -1.3f, 0),
            new Vector3(-10.3f, -1.8f, 0),
            new Vector3(-7.3f, -3.3f, 0),
            new Vector3(-8.5f, 2.6f, 0),
            new Vector3(-6.8f, 0.6f, 0),
            new Vector3(-5.5f, -1.9f, 0),
            new Vector3(-4.5f, 0.3f, 0),
            new Vector3(-3.9f, -3.9f, 0),
            new Vector3(-5.3f, 2.8f, 0),
            new Vector3(-2.7f, -0.3f, 0),
            new Vector3(-2.1f, -2.6f, 0),
            new Vector3(-2.7f, 2.2f, 0),
            new Vector3(-0.9f, 0.3f, 0),
            new Vector3(0.7f, 2.4f, 0),
            new Vector3(0f, -1.8f, 0),
            new Vector3(1.7f, 0.3f, 0),
            new Vector3(2.2f, -3.2f, 0),
            new Vector3(0f, -3.8f, 0),
            new Vector3(-9.3f, -3.9f, 0)
        };

        foreach (var s in spawners)
        {
            Instantiate(jorgem4, s, Quaternion.identity);
        }
    }

// Update is called once per frame
    void Update()
    {
        
    }
}
