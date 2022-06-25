using System;

namespace GLMathCSharp
{
    /// <summary>
    /// Represents a three dimensional vector.
    /// </summary>
    public struct Vec3
    {
        public float X;
        public float Y;
        public float Z;

        public float this[int index]
        {
            get
            {
                if (index == 0) return X;
                else if (index == 1) return Y;
                else if (index == 2) return Z;
                else throw new Exception("Out of range.");
            }
            set
            {
                if (index == 0) X = value;
                else if (index == 1) Y = value;
                else if (index == 2) Z = value;
                else throw new Exception("Out of range.");
            }
        }

        public Vec3(float s)
        {
            X = Y = Z = s;
        }

        public Vec3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vec3(Vec3 v)
        {
            this.X = v.X;
            this.Y = v.Y;
            this.Z = v.Z;
        }

        public Vec3(Vec4 v)
        {
            this.X = v.X;
            this.Y = v.Y;
            this.Z = v.Z;
        }

        public Vec3(Vec2 xy, float z)
        {
            this.X = xy.X;
            this.Y = xy.Y;
            this.Z = z;
        }

        public static Vec3 operator +(Vec3 lhs, Vec3 rhs)
        {
            return new Vec3(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
        }

        public static Vec3 operator +(Vec3 lhs, float rhs)
        {
            return new Vec3(lhs.X + rhs, lhs.Y + rhs, lhs.Z + rhs);
        }

        public static Vec3 operator -(Vec3 lhs, Vec3 rhs)
        {
            return new Vec3(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
        }

        public static Vec3 operator -(Vec3 lhs, float rhs)
        {
            return new Vec3(lhs.X - rhs, lhs.Y - rhs, lhs.Z - rhs);
        }

        public static Vec3 operator *(Vec3 self, float s)
        {
            return new Vec3(self.X * s, self.Y * s, self.Z * s);
        }
        
        public static Vec3 operator *(float lhs, Vec3 rhs)
        {
            return new Vec3(rhs.X * lhs, rhs.Y * lhs, rhs.Z * lhs);
        }

        public static Vec3 operator /(Vec3 lhs, float rhs)
        {
            return new Vec3(lhs.X / rhs, lhs.Y / rhs, lhs.Z / rhs);
        }

        public static Vec3 operator *(Vec3 lhs, Vec3 rhs)
        {
            return new Vec3(rhs.X * lhs.X, rhs.Y * lhs.Y, rhs.Z * lhs.Z);
        }

        public float[] ToArray()
        {
            return new[] { X, Y, Z };
        }

        #region Comparision

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// The Difference is detected by the different values
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Vec3))
            {
                var vec = (Vec3)obj;
                if (this.X == vec.X && this.Y == vec.Y && this.Z == vec.Z)
                    return true;
            }

            return false;
        }
        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="v1">The first Vector.</param>
        /// <param name="v2">The second Vector.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Vec3 v1, Vec3 v2)
        {
            return v1.Equals(v2);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="v1">The first Vector.</param>
        /// <param name="v2">The second Vector.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Vec3 v1, Vec3 v2)
        {
            return !v1.Equals(v2);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode();
        }

        #endregion

        #region ToString support

        public override string ToString()
        {
            return String.Format("[{0}, {1}, {2}]", X, Y, Z);
        }

        #endregion
    }

}