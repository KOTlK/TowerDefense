using Game.Board;
using UnityEngine;

namespace Units
{
    public class UnitsTest : MonoBehaviour
    {
        [SerializeField] private SimpleUnit _unit;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var hits = new RaycastHit[16];
                if (Physics.RaycastNonAlloc(ray, hits) == 0) return;

                foreach (var hit in hits)
                {
                    if (hit.collider == null) break;

                    if (hit.transform.TryGetComponent(out ICell cell))
                    {
                        _unit.Move(cell.Pivot);
                        Debug.Log("Hit");
                    }
                }
            }
        }
    }
}