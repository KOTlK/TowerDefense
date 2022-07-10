﻿using System;
using UnityEngine;

namespace Game.Board
{
    public class Cell : MonoBehaviour, ICell
    {
        [SerializeField] private float _outlineWidth = 0.1f;
        
        private bool _initialized = false;
        private Material _material;
        private int _propertyID;
        private Bounds _bounds;
        private Collider _collider;
        
        private const string PropertyName = "_FirstOutlineWidth";

        public Vector3 Pivot => _collider.ClosestPointOnBounds(transform.position + new Vector3(0, _bounds.extents.y, 0)) ;
        public Vector3 Position => transform.position;
        public IBuilding Building { get; private set; }

        private void Awake()
        {
            _collider = GetComponent<Collider>();
            _bounds = _collider.bounds;
            _propertyID = Shader.PropertyToID(PropertyName);
            
            _material = GetComponent<Renderer>().material;
        }

        public void Initialize(IBuilding building)
        {
            if (_initialized) return;

            Building = building;
            _initialized = true;
        }
        
        public void Build(IBuilding building)
        {
            Building.Destroy();
            Building = building;
        }

        public void DestroyBuilding()
        {
            Building.Destroy();
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