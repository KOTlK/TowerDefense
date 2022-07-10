namespace Game.Board
{
    public interface IBuilding
    {
        void Work();
        void Destroy();

        public class Empty : IBuilding
        {
            public void Work(){}
            public void Destroy(){}
        }
    }
}