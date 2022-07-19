using UnityEngine;

namespace Game.Board
{
    public interface ICellContent
    {
        void Place(Vector3 position);
        void Destroy();

        public class Empty : ICellContent
        {
            public void Place(Vector3 position){}
            public void Destroy(){}
        }
    }
}