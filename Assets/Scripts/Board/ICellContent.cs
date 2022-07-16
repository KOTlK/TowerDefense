namespace Game.Board
{
    public interface ICellContent
    {
        void Execute(long time);
        void Destroy();

        public class Empty : ICellContent
        {
            public void Execute(long time){}
            public void Destroy(){}
        }
    }
}