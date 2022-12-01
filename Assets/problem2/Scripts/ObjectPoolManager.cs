using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{    
    public GameObject cube;
    Queue<GameObject> ObjPool;
    public int maximum_Box;
    void Start()
    {
        ObjPool = new Queue<GameObject>();

        for(int i = 0; i < maximum_Box; i++)
        {
            GameObject Cube = Instantiate(cube, gameObject.transform.position, Quaternion.identity);
            Cube.transform.parent = gameObject.transform;
            Cube.SetActive(false);
            ObjPool.Enqueue(Cube);
        }
    }

    public void ActiveCube()
    {
        GameObject obj = Pop();
        obj.SetActive(true);
    }

    public GameObject Pop()
    {
        return ObjPool.Dequeue();
    }

    public void Dequeue(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = this.transform.position;
        ObjPool.Enqueue(obj);
    }    
}