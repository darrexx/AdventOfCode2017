using System;
using System.Collections.Generic;
using System.Linq;

namespace Day08
{
    public class Instruction : IEquatable<Instruction>
    {
        public String RegisterName { get; set; }

        public bool Increase { get; set; }

        public int Argument { get; set; }

        public String LeftSide { get; set; }

        public ComparisonOperation Operation { get; set; }

        public int RightSide { get; set; }

        public static ComparisonOperation GetOperationFromString(string operation)
        {
            switch (operation)
            {
                case "<":
                    return ComparisonOperation.Lesser;
                case "<=":
                    return ComparisonOperation.LesserOrEqual;
                case ">":
                    return ComparisonOperation.Greater;
                case ">=":
                    return ComparisonOperation.GreaterOrEqual;
                case "==":
                    return ComparisonOperation.Equal;
                case "!=":
                    return ComparisonOperation.NotEqual;
                default:
                    throw new ArgumentException();
            }
        }

        public bool Equals(Instruction other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(RegisterName, other.RegisterName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Instruction) obj);
        }

        public override int GetHashCode()
        {
            return (RegisterName != null ? RegisterName.GetHashCode() : 0);
        }

        public void Perform(IEnumerable<Register> registers)
        {
            var affectedRegister = registers.FirstOrDefault(x => x.Name == RegisterName);
            var leftComparsionRegisterValue = registers.FirstOrDefault(x => x.Name == LeftSide).Value;
            switch (Operation)
            {
                case ComparisonOperation.Lesser:
                    if (leftComparsionRegisterValue < RightSide)
                    {
                        if (Increase)
                        {
                            affectedRegister.Value += Argument;
                        }
                        else
                        {
                            affectedRegister.Value -= Argument;
                        }
                    }
                    break;
                case ComparisonOperation.LesserOrEqual:
                    if (leftComparsionRegisterValue <= RightSide)
                    {
                        if (Increase)
                        {
                            affectedRegister.Value += Argument;
                        }
                        else
                        {
                            affectedRegister.Value -= Argument;
                        }
                    }
                    break;
                case ComparisonOperation.Greater:
                    if (leftComparsionRegisterValue > RightSide)
                    {
                        if (Increase)
                        {
                            affectedRegister.Value += Argument;
                        }
                        else
                        {
                            affectedRegister.Value -= Argument;
                        }
                    }
                    break;
                case ComparisonOperation.GreaterOrEqual:
                    if (leftComparsionRegisterValue >= RightSide)
                    {
                        if (Increase)
                        {
                            affectedRegister.Value += Argument;
                        }
                        else
                        {
                            affectedRegister.Value -= Argument;
                        }
                    }
                    break;
                case ComparisonOperation.Equal:
                    if (leftComparsionRegisterValue == RightSide)
                    {
                        if (Increase)
                        {
                            affectedRegister.Value += Argument;
                        }
                        else
                        {
                            affectedRegister.Value -= Argument;
                        }
                    }
                    break;
                case ComparisonOperation.NotEqual:
                    if (leftComparsionRegisterValue != RightSide)
                    {
                        if (Increase)
                        {
                            affectedRegister.Value += Argument;
                        }
                        else
                        {
                            affectedRegister.Value -= Argument;
                        }
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum ComparisonOperation
    {
        Lesser,
        LesserOrEqual,
        Greater,
        GreaterOrEqual,
        Equal,
        NotEqual,
    }
}