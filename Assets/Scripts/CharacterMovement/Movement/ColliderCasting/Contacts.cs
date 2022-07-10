using System;
using System.Collections;
using UnityEngine;

namespace CharacterMovement.Movement
{
    public readonly struct Contacts : IEnumerable
    {
        private readonly Vector3[] _contacts;

        public Contacts(Vector3[] contacts)
        {
            _contacts = contacts;
        }

        public static Contacts None = new Contacts(Array.Empty<Vector3>());
        public Vector3 this[int index] => _contacts == Array.Empty<Vector3>() ? Vector3.zero : _contacts[index];


        public static bool operator ==(Contacts first, Contacts second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Contacts first, Contacts second)
        {
            return !first.Equals(second);
        }
        
        public override bool Equals(object obj)
        {
            if (obj is Contacts == false) return false;

            return obj.GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            return _contacts.GetHashCode();
        }

        public IEnumerator GetEnumerator()
        {
            return _contacts.GetEnumerator();
        }
    }
}