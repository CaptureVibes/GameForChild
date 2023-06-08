using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragAddition : MonoBehaviour
{
    public struct Fraction 
    {
        public int numerator;
        public int denominator;

        public void Simplify()
        {
            int gcd = GCD(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;
        }

        private int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
            
        public float ToDecimal()
        {
            return (float)numerator / denominator;
        }
    }


    public Fraction Add(Fraction a, Fraction b)
    {
        Fraction result = new Fraction();
        result.numerator = a.numerator * b.denominator + b.numerator * a.denominator;
        result.denominator = a.denominator * b.denominator;
        result.Simplify(); // 化简分数
        
        return result;
    }
}
