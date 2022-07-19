namespace Game.Hp
{
    public interface IDrawable<in TView>
    {
        void Draw(TView view);
    }
}