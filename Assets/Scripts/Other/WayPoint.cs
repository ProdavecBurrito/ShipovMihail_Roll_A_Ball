using System;
using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal sealed class VayPoint : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        private LineDrawer _rootWayPoint;

        public void InstantiateObj(Vector3 pos)
        {
            if (!_rootWayPoint)
            {
                _rootWayPoint = new GameObject("WayPoint").AddComponent<LineDrawer>();
            }

            if (_prefab != null)
            {
                Instantiate(_prefab, pos, Quaternion.identity, _rootWayPoint.transform);
            }
            else
            {
                throw new Exception($"Нет префаба на компоненте {typeof(LineDrawer)} {gameObject.name}");
            }
        }

    }
}
