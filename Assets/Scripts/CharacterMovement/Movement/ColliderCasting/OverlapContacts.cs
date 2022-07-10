using System;
using System.Collections;
using UnityEngine;

namespace CharacterMovement.Movement
{
    public readonly struct OverlapContacts : IEnumerable
    {
        private readonly Collider[] _contacts;

        public OverlapContacts(Collider[] contacts)
        {
            _contacts = contacts;
        }

        public static OverlapContacts Zero = new OverlapContacts(Array.Empty<Collider>());

        public int Count => _contacts.Length;

        public static bool operator ==(OverlapContacts first, OverlapContacts second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(OverlapContacts first, OverlapContacts second)
        {
            return !first.Equals(second);
        }

        public override bool Equals(object obj)
        {
            if (obj is OverlapContacts == false) return false;
            return obj.GetHashCode() == GetHashCode();
        }

        public IEnumerator GetEnumerator()
        {
            return _contacts.GetEnumerator();
        }

        public override int GetHashCode()
        {
            return _contacts.GetHashCode();
        }
    }
}