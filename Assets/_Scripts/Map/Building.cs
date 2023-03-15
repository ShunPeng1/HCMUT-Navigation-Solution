﻿using System;
using System.Collections.Generic;
using System.Linq;
using Shapes;
using UnityEngine;

namespace Map
{
    public class Building : MonoBehaviour
    {
        public bool Is3D = true;
        public float BuildingHeight = 10f;

        [SerializeField] private Polygon polygon;
        private List<Vector2> geoCoordinates;
        private List<Vector2> worldCoordinates;

        public void Init(string buildingName, List<Vector2> coordinates)
        {
            gameObject.name = buildingName;
            geoCoordinates = new(coordinates);
            worldCoordinates = coordinates.Select(MapHelper.GeoToWorldPosition).ToList();
            
            if (Is3D) Init3D();
            else Init2D();
        }

        private void Init2D()
        {
            foreach (var coordinate in worldCoordinates)
            {
                polygon.AddPoint(coordinate);
            }
        }

        private void Init3D()
        {
            for (int i = 0; i < worldCoordinates.Count; i++)
            {
                var firstIndex = i;
                var secondIndex = (i + 1) % worldCoordinates.Count;

                var bottomFirstPoint = worldCoordinates[firstIndex];
                var bottomSecondPoint = worldCoordinates[secondIndex];
                var topSecondPoint = bottomSecondPoint + Vector2.up * BuildingHeight;
                var topFirstPoint = bottomFirstPoint + Vector2.up * BuildingHeight;

                var sidePolygon = Instantiate(polygon);
                sidePolygon.transform.Rotate(Vector3.right, -90);
                sidePolygon.AddPoints(new[] {bottomFirstPoint, bottomSecondPoint, topSecondPoint, topFirstPoint});
            }
        }
    }
}