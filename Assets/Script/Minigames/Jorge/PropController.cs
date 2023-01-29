using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PropController : MonoBehaviour
{
    public List<Vector3> spawners;
    public List<GameObject> prefabs;
    public List<GameObject> instances;
    public List<GameObject> previews;

    public GameObject jorgem2;
    public GameObject jorgem3;
    public GameObject jorgem4;

    public GameObject jorger1;
    public GameObject jorger2;
    public GameObject jorger4;
    
    public GameObject jorgey1;
    public GameObject jorgey2;
    public GameObject jorgey4;
    
    public GameObject jorgeyk1;
    public GameObject jorgeyk2;
    public GameObject jorgeyk3;
    
    public GameObject jorgeyyk1;
    public GameObject jorgeyyk2;
    public GameObject jorgeyyk3;

    public GameObject preview1;
    public GameObject preview2;
    public GameObject preview3;
    public GameObject preview4;
    public GameObject preview5;

    public int kit;
    public bool success;

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

        prefabs = new List<GameObject>()
        {
            jorgem2,
            jorgem3,
            jorgem4,

            jorger1,
            jorger2,
            jorger4,

            jorgey1,
            jorgey2,
            jorgey4,

            jorgeyk1,
            jorgeyk2,
            jorgeyk3,

            jorgeyyk1,
            jorgeyyk2,
            jorgeyyk3
        };

        previews = new List<GameObject>()
        {
            preview1,
            preview2,
            preview3,
            preview4,
            preview5
        };

        for (int i = 0; i < prefabs.Count(); i++)
        {
            instances.Add(Instantiate(prefabs[i], new Vector3(15, 15, 0), prefabs[i].transform.rotation));
        }
        NewRound();
    }

    // Update is called once per frame
    void Update()
    {
        int totalWeared = 0;
        for (int i = 0; i < instances.Count(); i ++)
        {
            if (instances[i].GetComponent<WearableObject>().weared) {
                if (i/3 == kit)
                {
                    instances[i].GetComponent<WearableObject>().wearObject.SetActive(true);
                    totalWeared++;
                } else
                {
                    instances[i].SetActive(true);
                }
            }
        }
        if (totalWeared == 3)
        {
            success = true;
        }
    }

    void HidePreviews()
    {
        foreach (var preview in previews)
        {
            preview.SetActive(false);
        }
    }

    void ChooseKit()
    {
        kit = UnityEngine.Random.Range(0, prefabs.Count() / 3);
        previews[kit].SetActive(true);
    }

    void NewRound()
    {
        success = false;
        HidePreviews();
        PositionProps();
        ChooseKit();
    }

    void PositionProps()
    {
        var randomInt = RandomPermutation(instances.Count()); // 15!
        var indices = SelectedIndices(spawners.Count(), spawners.Count() - instances.Count()); // 20 choose 5

        for (int i = 0; i < instances.Count(); i++)
        {
            instances[randomInt[i]].transform.position = spawners[indices[i]];
            instances[randomInt[i]].SetActive(true);
        }
    }

    List<int> SelectedIndices(int n, int k)
    {
        var list = Enumerable.Range(0, n).ToList();
        for (int i = 0; i < k; i++)
        {
            int m = UnityEngine.Random.Range(0, n-i);
            list.RemoveAt(m);
        }
        return list;
    }

    public List<int> RandomPermutation(int n)
    {
        var list = Enumerable.Range(0, n).ToList();
        while (n > 1)
        {
            int i = UnityEngine.Random.Range(0, n);
            n--;
            int temp = list[i];
            list[i] = list[n];
            list[n] = temp;
        }
        return list;
    }
}
