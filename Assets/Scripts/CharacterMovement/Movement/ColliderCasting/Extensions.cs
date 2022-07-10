using System.Linq;
using UnityEngine;

namespace CharacterMovement.Movement.Extensions
{
    public static class Extensions
    {
        public static Contacts ExtractContacts(this RaycastHit[] hits)
        {
            return new Contacts(hits.TakeWhile(hit => hit.collider != null && hit.point != Vector3.zero).Select(hit => hit.normal).ToArray());
        }
        
        public static OverlapContacts ExtractContacts(this Collider[] colliders)
        {
            return new OverlapContacts(colliders.TakeWhile(collider => collider != null).ToArray());
        }

        public static Rayhit ExtractHits(this RaycastHit[] hits)
        {
            var validHits = hits.TakeWhile(hit => hit.collider != null && hit.point != Vector3.zero);
            var points = validHits.Select(hit => hit.point).ToArray();
            var normals = validHits.Select(hit => hit.normal).ToArray();

            return new Rayhit(points, normals);
        }

        public static Vector3 Average(this Contacts contacts)
        {
            var count = 0;
            var average = Vector3.zero;

            foreach (Vector3 contact in contacts)
            {
                count++;
                average += contact;
            }
            
            return average / count;
        }

        
    }
}