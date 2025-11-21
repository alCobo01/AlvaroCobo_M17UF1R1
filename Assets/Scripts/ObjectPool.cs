using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour, IPooleable
{
    [SerializeField] private GameObject pooledObject;
    private Stack<GameObject> _pool = new Stack<GameObject>();

    public GameObject Pop()
    {
        if (_pool.Count > 0)
        {
            GameObject obj = _pool.Pop();
            obj.SetActive(true);
            return obj;
        }
        else return Instantiate(pooledObject);
    }

    public void Push(GameObject obj)
    {
        obj.SetActive(false);
        _pool.Push(obj);
    }
}
