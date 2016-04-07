/// Copyright (C) 2016 The Authors.
module Point

open Vector

[<Sealed>]
type Point

/// <summary>
/// Raised in case of attempting to round a point to a negative number of decimals.
/// </summary>
exception RoundNegativeDecimalsException

/// <summary>
/// Create a point with three coordinates.
/// </summary>
/// <param name=x>The x coordinate of the point.</param>
/// <param name=y>The y coordinate of the point.</param>
/// <param name=z>The z coordinate of the point.</param>
/// <returns>The created point.</returns>
val make : float -> float -> float -> Point

/// <summary>
/// Get the x coordinate of a point.
/// </summary>
/// <param name=p>The point whose x coordinate to get.</param>
/// <returns>The x coordinate of the point.</returns>
val getX : Point -> float

/// <summary>
/// Get the y coordinate of a point.
/// </summary>
/// <param name=p>The point whose y coordinate to get.</param>
/// <returns>The y coordinate of the point.</returns>
val getY : Point -> float

/// <summary>
/// Get the z coordinate of a point.
/// </summary>
/// <param name=p>The point whose z coordinate to get.</param>
/// <returns>The z coordinate of the point.</returns>
val getZ : Point -> float

/// <summary>
/// Get all coordinates of a point.
/// </summary>
/// <param name=p>The point whose coordinates to get.</param>
/// <returns>The coordinates of the point.</returns>
val getCoord : Point -> float * float * float

/// <summary>
/// Displace a point by a vector.
/// </summary>
/// <param name=p>The point to displace.</param>
/// <param name=v>The vector to displace the point by.</param>
/// <returns>The displaced point.</returns>
val move : Point -> Vector -> Point

/// <summary>
/// Compute the distance vector between two points.
/// </summary>
/// <param name=p>The first point.</param>
/// <param name=q>The second point.</param>
/// <returns>The distance vector between the two points.</returns>
val distance : Point -> Point -> Vector

/// <summary>
/// Compute the direction vector between two points.
/// </summary>
/// <param name=p>The first point.</param>
/// <param name=q>The second point.</param>
/// <returns>The direction vector between the two points.</returns>
val direction : Point -> Point -> Vector

/// <summary>
/// Round a point to a specific number of decimals.
/// </summary>
/// <param name=p>The point to round.</param>
/// <returns>The rounded point.</returns>
val round : Point -> int -> Point
