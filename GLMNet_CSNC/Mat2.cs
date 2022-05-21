using System;
using System.Linq;

namespace GLMNet_CSNC
{
    /// <summary>
    /// Represents a 2x2 matrix.
    /// </summary>
    public struct Mat2
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat2"/> struct.
        /// This matrix is the identity matrix scaled by <paramref name="scale"/>.
        /// </summary>
        /// <param name="scale">The scale.</param>
        public Mat2(float scale)
        {
            _cols = new[]
            {
                new Vec2(scale, 0.0f),
                new Vec2(0.0f, scale)
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat2"/> struct.
        /// The matrix is initialised with the <paramref name="_cols"/>.
        /// </summary>
        /// <param name="_cols">The colums of the matrix.</param>
        public Mat2(Vec2[] cols)
        {
            this._cols = new[]
            {
                cols[0],
                cols[1]
            };
        }

        public Mat2(Vec2 a, Vec2 b)
        {
            this._cols = new[]
            {
                a, b
            };
        }

        public Mat2(float a, float b, float c, float d)
        {
            this._cols = new[]
            {
                new Vec2(a,b), new Vec2(c,d)
            };
        }

        /// <summary>
        /// Creates an identity matrix.
        /// </summary>
        /// <returns>A new identity matrix.</returns>
        public static Mat2 Identity()
        {
            return new Mat2
            {
                _cols = new[]
                {
                    new Vec2(1,0),
                    new Vec2(0,1)
                }
            };
        }

        #endregion

        #region Index Access

        /// <summary>
        /// Gets or sets the <see cref="Vec2"/> column at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="Vec2"/> column.
        /// </value>
        /// <param name="column">The column index.</param>
        /// <returns>The column at index <paramref name="column"/>.</returns>
        public Vec2 this[int column]
        {
            get { return _cols[column]; }
            set { _cols[column] = value; }
        }

        /// <summary>
        /// Gets or sets the element at <paramref name="column"/> and <paramref name="row"/>.
        /// </summary>
        /// <value>
        /// The element at <paramref name="column"/> and <paramref name="row"/>.
        /// </value>
        /// <param name="column">The column index.</param>
        /// <param name="row">The row index.</param>
        /// <returns>
        /// The element at <paramref name="column"/> and <paramref name="row"/>.
        /// </returns>
        public float this[int column, int row]
        {
            get { return _cols[column][row]; }
            set { _cols[column][row] = value; }
        }

        #endregion

        #region Conversion

        /// <summary>
        /// Returns the matrix as a flat array of elements, column major.
        /// </summary>
        /// <returns></returns>
        public float[] ToArray()
        {
            return _cols.SelectMany(v => v.ToArray()).ToArray();
        }

        #endregion

        #region Multiplication

        /// <summary>
        /// Multiplies the <paramref name="lhs"/> matrix by the <paramref name="rhs"/> vector.
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS vector.</param>
        /// <returns>The product of <paramref name="lhs"/> and <paramref name="rhs"/>.</returns>
        public static Vec2 operator *(Mat2 lhs, Vec2 rhs)
        {
            return new Vec2(
                lhs[0, 0] * rhs[0] + lhs[1, 0] * rhs[1],
                lhs[0, 1] * rhs[0] + lhs[1, 1] * rhs[1]
            );
        }

        /// <summary>
        /// Multiplies the <paramref name="lhs"/> matrix by the <paramref name="rhs"/> matrix.
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS matrix.</param>
        /// <returns>The product of <paramref name="lhs"/> and <paramref name="rhs"/>.</returns>
        public static Mat2 operator *(Mat2 lhs, Mat2 rhs)
        {
            return new Mat2(new[]
            {
          lhs[0][0] * rhs[0] + lhs[1][0] * rhs[1],
          lhs[0][1] * rhs[0] + lhs[1][1] * rhs[1]
            });
        }

        public static Mat2 operator *(Mat2 lhs, float s)
        {
            return new Mat2(new[]
            {
                lhs[0]*s,
                lhs[1]*s
            });
        }

        #endregion

        #region ToString support

        public override string ToString()
        {
            return String.Format(
                "[{0}, {1}; {2}, {3}]",
                this[0, 0], this[1, 0],
                this[0, 1], this[1, 1]
            );
        }

        #endregion

        #region comparision
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
            if (obj.GetType() == typeof(Mat2))
            {
                var mat = (Mat2)obj;
                if (mat[0] == this[0] && mat[1] == this[1])
                    return true;
            }

            return false;
        }
        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="m1">The first Matrix.</param>
        /// <param name="m2">The second Matrix.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Mat2 m1, Mat2 m2)
        {
            return m1.Equals(m2);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="m1">The first Matrix.</param>
        /// <param name="m2">The second Matrix.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Mat2 m1, Mat2 m2)
        {
            return !m1.Equals(m2);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this[0].GetHashCode() ^ this[1].GetHashCode();
        }

        #endregion

        /// <summary>
        /// The columms of the matrix.
        /// </summary>
        private Vec2[] _cols;
    }
}