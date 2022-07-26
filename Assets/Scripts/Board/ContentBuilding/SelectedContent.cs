using UnityEngine;
using Utils;

namespace Game.Board.ContentBuilding
{
    public class SelectedContent : ISelectedContent
    {
        private IContent _selected;
        private IFactory<IContent> _contentFactory;
        public void Place(Vector3 position)
        {
            _selected.Place(position);
        }

        public void Destroy() => _selected.Destroy();


        public void Build(IContentCell cell)
        {
            cell.Build(_selected);
            _selected = _contentFactory.Instantiate();
        }

        public void Select(IFactory<IContent> factory)
        {
            _contentFactory = factory;
            _selected?.Destroy();
            _selected = factory.Instantiate();
        }
    }
}