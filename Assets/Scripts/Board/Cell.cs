using System;
using UnityEngine;

namespace Game.Board
{
    public class Cell : MonoBehaviour, IContentCell
    {
        [SerializeField] private float _outlineWidth = 0.1f;
        
        private bool _initialized = false;
        private Material _material;
        private int _propertyID;
        private Bounds _bounds;
        
        private const string OutlineProperty = "_FirstOutlineWidth";

        public Vector3 Pivot => transform.position + new Vector3(0, _bounds.extents.y, 0);
        public Vector3 Position => transform.position;
        public ICellContent Content { get; private set; }

        private void Awake()
        {
            var collider = GetComponent<Collider>();
            _bounds = collider.bounds;
            _propertyID = Shader.PropertyToID(OutlineProperty);
            
            _material = GetComponent<Renderer>().material;
        }

        public void Initialize(ICellContent cellContent)
        {
            if (_initialized) return;

            Content = cellContent;
            _initialized = true;
        }
        
        public void Build(ICellContent cellContent)
        {
            Content.Destroy();
            Content = cellContent;
        }

        public void DestroyBuilding()
        {
            Content.Destroy();
        }

        private void OnMouseEnter()
        {
            _material.SetFloat(_propertyID, _outlineWidth);
        }

        private void OnMouseExit()
        {
            _material.SetFloat(_propertyID, 0);
        }
    }
}