using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Scripts
{
    public class Pool<T> where T : MonoBehaviour
    {
        public T Prefab;
        public Transform Container;
        public readonly List<T> PoolObj;

        public Pool(T prefab, Transform container, int initialCount)
        {
            Prefab = prefab;
            Container = container;
            PoolObj = new List<T>();
            CreatePool(initialCount);
        }

        private void CreatePool(int initialCount)
        {
            for (int i = 0; i < initialCount; i++)
            {
                CreateElement();
            }
        }

        private T CreateElement(bool isActive = false)
        {
            var el = GameObject.Instantiate(Prefab, Container);
            el.gameObject.SetActive(isActive);
            PoolObj.Add(el);
            return el;
        }

        private bool HasFreeElement(out T element)
        {
            foreach (var mono in PoolObj)
            {
                if (!mono.gameObject.activeInHierarchy)
                {
                    element = mono;
                    return true;
                }
            }

            element = null;
            return false;
        }

        public T GetFreeElement()
        {
            if (HasFreeElement(out T element))
            {
                element.gameObject.SetActive(true);
                return element;
            }
            return CreateElement(true);
        }
    }
}