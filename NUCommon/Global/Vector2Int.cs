using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Struct holding two integer components
    /// </summary>
    public struct Vector2Int
    {
        /// <summary>
        /// The x component
        /// </summary>
        private int x;

        /// <summary>
        /// Gets or sets the X component.
        /// </summary>
        /// <value>
        /// The X component.
        /// </value>
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        /// The y component
        /// </summary>
        private int y;

        /// <summary>
        /// Gets or sets the Y component.
        /// </summary>
        /// <value>
        /// The Y component.
        /// </value>
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2Int"/> struct.
        /// </summary>
        /// <param name="x">The x component.</param>
        /// <param name="y">The y component.</param>
        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if(obj is Vector2Int)
            {
                Vector2Int other = (Vector2Int)obj;
                return (other.X == x && other.Y == y);
            }
            return false;
        }

        /// <summary>
        /// Gets the length of the instance.
        /// </summary>
        /// <returns>Math.Sqrt((x * x) + (y * y))</returns>
        public double Length()
        {
            return Math.Sqrt((x * x) + (y * y));
        }

        /// <summary>
        /// Normalizes this instance.
        /// </summary>
        public void Normalize()
        {
            this /= (int)Length();
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + x;
            hash = (hash * 7) + y;
            return hash;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "X: " + x + ", Y: " + y;
        }

        /// <summary>
        /// Adds the two Vector2Ints
        /// </summary>
        /// <param name="a">Left Vector2Int.</param>
        /// <param name="b">Right Vector2Int.</param>
        /// <returns>a.X + b.X, a.Y + b.Y</returns>
        public static Vector2Int operator +(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.X + b.X, a.Y + b.Y);
        }

        /// <summary>
        /// Adds the value to both components of the Vector2Int
        /// </summary>
        /// <param name="a">Left Vector2Int.</param>
        /// <param name="b">The number to add.</param>
        /// <returns>a.X + b, a.Y + b</returns>
        public static Vector2Int operator +(Vector2Int a,int b)
        {
            return new Vector2Int(a.X + b, a.Y + b);
        }

        /// <summary>
        /// Subtracts the value to both components of the Vector2Int
        /// </summary>
        /// <param name="a">Left Vector2Int.</param>
        /// <param name="b">The number to subtract.</param>
        /// <returns>a.X - b, a.Y - b</returns>
        public static Vector2Int operator -(Vector2Int a, int b)
        {
            return new Vector2Int(a.X - b, a.Y - b);
        }

        /// <summary>
        /// Multiplies the value to both components of the Vector2Int
        /// </summary>
        /// <param name="a">Left Vector2Int.</param>
        /// <param name="b">The number to multiply by.</param>
        /// <returns>a.X * b, a.Y * b</returns>
        public static Vector2Int operator *(Vector2Int a, int b)
        {
            return new Vector2Int(a.X * b, a.Y * b);
        }

        /// <summary>
        /// Divides the value to both components of the Vector2Int
        /// </summary>
        /// <param name="a">Left Vector2Int.</param>
        /// <param name="b">The number to divide by.</param>
        /// <returns>a.X / b, a.Y / b</returns>
        public static Vector2Int operator /(Vector2Int a, int b)
        {
            return new Vector2Int(a.X / b, a.Y / b);
        }

        /// <summary>
        /// Subtracts the right Vector2Int from the left Vector2Int.
        /// </summary>
        /// <param name="a">Left Vector2Int.</param>
        /// <param name="b">Right Vector2Int.</param>
        /// <returns>a.X - b.X, a.Y - b.Y</returns>
        public static Vector2Int operator -(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.X - b.X, a.Y - b.Y);
        }

        /// <summary>
        /// Multiplies the components of the two Vector2Ints together
        /// </summary>
        /// <param name="a">Left Vector2Int.</param>
        /// <param name="b">Right Vector2Int.</param>
        /// <returns>a.X * b.X, a.Y * b.Y</returns>
        public static Vector2Int operator *(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.X * b.X, a.Y * b.Y);
        }

        /// <summary>
        /// Multiplies the components of the left Vecto2Int by the components of the right Vector2Int 
        /// </summary>
        /// <param name="a">Left Vector2Int.</param>
        /// <param name="b">Right Vector2Int.</param>
        /// <returns>a.X / b.X, a.Y / b.Y</returns>
        public static Vector2Int operator /(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.X / b.X, a.Y / b.Y);
        }

        /// <summary>
        /// Checks for value equality between two Vector2Ints
        /// </summary>
        /// <param name="a">Left Vector2Int.</param>
        /// <param name="b">Right Vector2Int.</param>
        /// <returns>a==b</returns>
        public static bool operator ==(Vector2Int a, Vector2Int b)
        {
            return (a.X == b.X) && (a.Y == b.Y);
        }

        /// <summary>
        /// !=s the specified a.
        /// </summary>
        /// <param name="a">Left Vector2Int.</param>
        /// <param name="b">Right Vector2Int.</param>
        /// <returns>!(a==b)</returns>
        public static bool operator !=(Vector2Int a, Vector2Int b)
        {
            return !(a==b);
        }
    }
}
