using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArrowsObjectPool : MonoBehaviour
{
    private Arrow _prefabb;
    private List<Arrow> _arrowsPool = new List<Arrow>();

    public void Initialise(Arrow prefab, int count = 5)
    {
        _prefabb = prefab;

        for (int i = 0; i < count; i++)
        {
            Arrow spawned = Create();
            spawned.gameObject.SetActive(false);
        }
    }

    public Arrow Get()
    {
        Arrow arrow = _arrowsPool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        arrow.gameObject.SetActive(true);

        return arrow;
    }

    private Arrow Create()
    {
        Arrow arrow = Instantiate(_prefabb, transform);
        arrow.Hitted += Return;
        _arrowsPool.Add(arrow);

        return arrow;
    }

    private void Return(Arrow arrow)
    {
        arrow.Hitted -= Return;
        arrow.gameObject.SetActive(false);
    }
}
