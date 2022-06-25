using System;

namespace GLMathCSharp
{
    /// <summary>
    /// Represents a four dimensional vector.
    /// </summary>
    public struct Vec4
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public float this[int index]
        {
            get
            {
                if (index == 0) return X;
                else if (index == 1) return Y;
                else if (index == 2) return Z;
                else if (index == 3) return W;
                else throw new Exception("Out of range.");
            }
            set
            {
                if (index == 0) X = value;
                else if (index == 1) Y = value;
                else if (index == 2) Z = value;
                else if (index == 3) W = value;
                else throw new Exception("Out of range.");
            }
        }

        public Vec4(float s)
        {
            X = Y = Z = W = s;
        }

        public Vec4(float x, float y, float z, float w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        public Vec4(Vec4 v)
        {
            this.X = v.X;
            this.Y = v.Y;
            this.Z = v.Z;
            this.W = v.W;
        }

        public Vec4(Vec3 xyz, float w)
        {
            this.X = xyz.X;
            this.Y = xyz.Y;
            this.Z = xyz.Z;
            this.W = w;
        }

        public static Vec4 operator +(Vec4 lhs, Vec4 rhs)
        {
            return new Vec4(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z, lhs.W + rhs.W);
        }

        public static Vec4 operator +(Vec4 lhs, float rhs)
        {
            return new Vec4(lhs.X + rhs, lhs.Y + rhs, lhs.Z + rhs, lhs.W + rhs);
        }

        public static Vec4 operator -(Vec4 lhs, float rhs)
        {
            return new Vec4(lhs.X - rhs, lhs.Y - rhs, lhs.Z - rhs, lhs.W - rhs);
        }

        public static Vec4 operator -(Vec4 lhs, Vec4 rhs)
        {
            return new Vec4(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z, lhs.W - rhs.W);
        }

        public static Vec4 operator *(Vec4 self, float s)
        {
            return new Vec4(self.X * s, self.Y * s, self.Z * s, self.W * s);
        }

        public static Vec4 operator *(float lhs, Vec4 rhs)
        {
            return new Vec4(rhs.X * lhs, rhs.Y * lhs, rhs.Z * lhs, rhs.W * lhs);
        }

        public static Vec4 operator *(Vec4 lhs, Vec4 rhs)
        {
            return new Vec4(rhs.X * lhs.X, rhs.Y * lhs.Y, rhs.Z * lhs.Z, rhs.W * lhs.W);
        }

        public static Vec4 operator /(Vec4 lhs, float rhs)
        {
            return new Vec4(lhs.X / rhs, lhs.Y / rhs, lhs.Z / rhs, lhs.W / rhs);
        }

        public float[] ToArray()
        {
            return new[] { X, Y, Z, W };
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
            if (obj.GetType() == typeof(Vec4))
            {
                var vec = (Vec4)obj;
                if (this.X == vec.X && this.Y == vec.Y && this.Z == vec.Z && this.W == vec.W)
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
        public static bool operator ==(Vec4 v1, Vec4 v2)
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
        public static bool operator !=(Vec4 v1, Vec4 v2)
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
            return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode() ^ this.W.GetHashCode();
        }

        #endregion

        #region ToString support

        public override string ToString()
        {
            return String.Format("[{0}, {1}, {2}, {3}]", X, Y, Z, W);
        }

        #endregion
    }

}