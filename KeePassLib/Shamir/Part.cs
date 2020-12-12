using System;
using System.Numerics;

namespace KeePassLib.Shamir
{
    public sealed class Part
    {
        BigInteger x;
        BigInteger y;
        public Part(BigInteger x, BigInteger y)
        {
            this.x = x;
            this.y = y;
        }public Part(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Part(Part part)
        {
            this.x = part.x;
            this.y = part.y;
        }
        override public String ToString()
        {
            return pad(x.ToString("X")) + ":" + pad(y.ToString("X"));
        }
        private String pad(String hex)
        {
            if (hex.Length % 2 == 1) 
            {
                return "0" + hex;
            }
            return hex;
        }
        public BigInteger GetX()
        {
            return this.x;
        }

        public BigInteger GetY()
        {
            return this.y;
        }
    }
}