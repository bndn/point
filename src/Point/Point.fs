/// Copyright (C) 2016 The Authors.
module Point

type Point =
  | P of float * float * float
  override p.ToString() =
    match p with
    | P(x, y, z) -> "(" + x.ToString() + "," + y.ToString() + "," + z.ToString() + ")"

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
let make x y z = P(x, y, z)

/// <summary>
/// Get the x coordinate of a point.
/// </summary>
/// <param name=p>The point whose x coordinate to get.</param>
/// <returns>The x coordinate of the point.</returns>
let getX (P(x, _, _)) = x

/// <summary>
/// Get the y coordinate of a point.
/// </summary>
/// <param name=p>The point whose y coordinate to get.</param>
/// <returns>The y coordinate of the point.</returns>
let getY (P(_, y, _)) = y

/// <summary>
/// Get the z coordinate of a point.
/// </summary>
/// <param name=p>The point whose z coordinate to get.</param>
/// <returns>The z coordinate of the point.</returns>
let getZ (P(_, _, z)) = z

/// <summary>
/// Get all coordinates of a point.
/// </summary>
/// <param name=p>The point whose coordinates to get.</param>
/// <returns>The coordinates of the point.</returns>
let getCoord (P(x, y, z)) = (x, y, z)

/// <summary>
/// Displace a point by a vector.
/// </summary>
/// <param name=p>The point to displace.</param>
/// <param name=v>The vector to displace the point by.</param>
/// <returns>The displaced point.</returns>
let move (P(px, py, pz)) v = P(px + Vector.getX v, py + Vector.getY v, pz + Vector.getZ v)

/// <summary>
/// Compute the distance vector between two points.
/// </summary>
/// <param name=p>The first point.</param>
/// <param name=q>The second point.</param>
/// <returns>The distance vector between the two points.</returns>
let distance (P(px, py, pz)) (P(qx, qy, qz)) = Vector.make (qx - px) (qy - py) (qz - pz)

/// <summary>
/// Compute the direction vector between two points.
/// </summary>
/// <param name=p>The first point.</param>
/// <param name=q>The second point.</param>
/// <returns>The direction vector between the two points.</returns>
let direction p q = Vector.normalise (distance p q)

/// <summary>
/// Round a point to a specific number of decimals.
/// </summary>
/// <param name=p>The point to round.</param>
/// <param name=d>The number of decimals to round to.</param>
/// <returns>The rounded point.</returns>
let round (P(x, y, z)) (d:int) =
  if d < 0 then raise RoundNegativeDecimalsException
  let f = 10.0 ** float d
  P(round (x * f) / f, round (y * f) / f, round (z * f) / f)
