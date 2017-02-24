﻿using System;
using UnityEngine;

/// <summary>
/// A class representing spherical coordinates. These are created by the lidar sensor.
/// </summary>
public class SphericalCoordinates
{
    private float radius;
    private float inclination;
    private float azimuth;

    public SphericalCoordinates(float radius, float inclination, float azimuth)
    {
        this.radius = radius;
        this.inclination = inclination;
        this.azimuth = azimuth;
    }

    // Constructor based on cartesian coordinates
	/// <summary>
	/// Initializes a new instance of the <see cref="SphericalCoordinates"/> class using cartesian coordinates.
	/// </summary>
	/// <param name="coordinates">Coordinates.</param>
    public SphericalCoordinates(Vector3 coordinates)
    {
        this.radius = Mathf.Sqrt(Mathf.Pow(coordinates.x, 2) + Mathf.Pow(coordinates.y, 2) + Mathf.Pow(coordinates.z, 2));

        if (radius == 0)
        {
            inclination = 0;
            azimuth = 0;
        }
        this.inclination = Mathf.Atan(coordinates.z / radius);
        this.azimuth = Mathf.Atan(coordinates.y / coordinates.x);
    }

	/// <summary>
	/// Gets the radius.
	/// </summary>
	/// <returns>The radius.</returns>
    private float GetRadius()
    {
        return this.radius;
    }
	/// <summary>
	/// Gets the inclination.
	/// </summary>
	/// <returns>The inclination.</returns>
    private float GetInclination()
    {
        return this.radius;
    }
	/// <summary>
	/// Gets the azimuth.
	/// </summary>
	/// <returns>The azimuth.</returns>
    private float GetAzimuth()
    {
        return this.azimuth;
    }
}