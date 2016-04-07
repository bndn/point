/// Copyright (C) 2016 The Authors.
module Point

/// Make the Vector type available without using Vector.Vector
open Vector

[<Sealed>]
type Point

/// Raised in case of attempting to round a point to a negative number of decimals.
exception RoundNegativeDeicmalsException

/// Create a point with three coordinates.
val make : float -> float -> float -> Point

/// Get the x coordinate of a point.
val getX : Point -> float

/// Get the y coordinate of a point.
val getY : Point -> float

/// Get the z coordinate of a point.
val getZ : Point -> float

/// Get all coordinates of a point.
val getCoord : Point -> float * float * float

/// Displace a point by a vector.
val move : Point -> Vector -> Point

/// Compute the distance vector between two points.
val distance : Point -> Point -> Vector

/// Compute the direction vector between two points.
val direction : Point -> Point -> Vector

/// Round a point to a specific number of decimals.
val round : Point -> int -> Point
