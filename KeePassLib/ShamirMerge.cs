using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Math;
using System.Numerics;

namespace WindowsFormsApp1
{
    public sealed class ShamirMerge
    {

        //largest 64 bit prime number
        //may need to generalise
        // taken from https://msdn.microsoft.com/en-us/library/ee621251.aspx
        //System.Numerics.BigInteger p = System.Numerics.BigInteger.Parse("18446744073709551629");
        System.Numerics.BigInteger p = System.Numerics.BigInteger.Parse("18446744073709551557");
        System.Numerics.BigInteger Sum;
        System.Numerics.BigInteger mult;
        public System.Numerics.BigInteger[] Merge(Part[][] parts, int threshold)
        {

            Org.BouncyCastle.Math.BigInteger p1 = new Org.BouncyCastle.Math.BigInteger(p.ToString());
            Console.WriteLine("p1" + p1.ToString());
            int secretSize = parts[0].Length;
            Console.WriteLine("secretsize" + secretSize);
            System.Numerics.BigInteger[] results = new System.Numerics.BigInteger[secretSize];
            string[] secret = new string[secretSize];
            byte[] ba;
            string str;
            int count = 0;

            // loop through each secret partition
            for (int i = 0; i < secretSize; i++)
            {
                Sum = System.Numerics.BigInteger.Zero;
                //doing lagrange interpolation
                for (int j = 0; j< threshold; j++)
                {
                    mult = System.Numerics.BigInteger.One;
                    for (int k = 0; k < threshold; k++)
                    {
                        if (j != k)
                        {
                            System.Numerics.BigInteger numerator = parts[k][i].GetX();
                            System.Numerics.BigInteger denominator = System.Numerics.BigInteger.Subtract(numerator, parts[j][i].GetX());
                            
                            // take mod of negative number
                            while (System.Numerics.BigInteger.Compare(denominator, System.Numerics.BigInteger.Zero)<0)
                            {

                                denominator = System.Numerics.BigInteger.Add(denominator, p);
                            }
                            //convert to bouncycastle biginteger to calculate modInverse
                            Org.BouncyCastle.Math.BigInteger denominator1 = new Org.BouncyCastle.Math.BigInteger(denominator.ToString());
                           
                            Org.BouncyCastle.Math.BigInteger invDenominator1 = denominator1.ModInverse(p1);
                            
                            System.Numerics.BigInteger invDenominator = System.Numerics.BigInteger.Parse(invDenominator1.ToString());
                            
                            mult = System.Numerics.BigInteger.Multiply(mult, System.Numerics.BigInteger.Multiply(numerator, invDenominator));
                            
                            mult = System.Numerics.BigInteger.Remainder(mult, p);
                            
                            

                        }
                    }
                    mult = System.Numerics.BigInteger.Multiply(mult, parts[j][i].GetY());
                    
                    mult = System.Numerics.BigInteger.Remainder(mult, p);
                    
                    Sum = System.Numerics.BigInteger.Add(Sum, mult);
                    
                    Sum = System.Numerics.BigInteger.Remainder(Sum, p);
                    

                }
                
                results[i] = Sum;
                
            }
            foreach (System.Numerics.BigInteger r in results)
            {
                //Console.WriteLine(r);
                //System.Numerics.BigInteger.TryParse
                ba = r.ToByteArray();
                str = Encoding.UTF8.GetString(ba);
                //Console.WriteLine(str);
                secret[count++] = str;
            }
            str = string.Join("", secret);
            str.Replace("\n", "");
            return results;
        }
    }
}
