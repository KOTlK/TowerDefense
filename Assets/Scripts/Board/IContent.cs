using UnityEngine;

namespace Game.Board
{
    public interface IContent
    {
        void Place(Vector3 position);
        void Destroy();

        public class Empty : IContent
        {
            public void Place(Vector3 position){}
            public void Destroy(){}
        }
    }
}