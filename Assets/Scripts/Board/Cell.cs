using System;
using UnityEngine;

namespace Game.Board
{
    public class Cell : MonoBehaviour, IContentCell
    {
        public event Action Clicked;
        public event Action Selected;
        
        [SerializeField] private float _outlineWidth = 0.1f;
        
        private bool _initialized = false;
        private Material _material;
        private int _propertyID;
        private Bounds _bounds;
        
        private const string OutlineProperty = "_FirstOutlineWidth";

        public Vector3 Pivot => transform.position + new Vector3(0, _bounds.extents.y, 0);
        public Vector3 Position => transform.position;
        public IContent Content { get; private set; }

        private void Awake()
        {
            var collider = GetComponent<Collider>();
            _bounds = collider.bounds;
            _propertyID = Shader.PropertyToID(OutlineProperty);
            
            _material = GetComponent<Renderer>().material;
        }

        public void Initialize(IContent content)
        {
            if (_initialized) return;

            Content = content;
            _initialized = true;
        }
        
        public void Build(IContent content)
        {
            Content.Destroy();
            Content = content;
            Content.Place(Pivot);
        }

        public void DestroyContent()
        {
            Content.Destroy();
        }

        private void OnMouseEnter()
        {
            Selected?.Invoke();
            _material.SetFloat(_propertyID, _outlineWidth);
        }

        private void OnMouseExit()
        {
            _material.SetFloat(_propertyID, 0);
        }

        private void OnMouseDown()
        {
            Clicked?.Invoke();
        }
    }
}