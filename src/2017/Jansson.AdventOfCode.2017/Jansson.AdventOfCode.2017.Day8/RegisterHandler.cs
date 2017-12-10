using System.Collections.Generic;
using System.Linq;

namespace Jansson.AdventOfCode._2017.Day8
{
    public class RegisterHandler
    {
        private readonly Dictionary<string, int> _registers = new Dictionary<string, int>();
        private int _largestTotalRegisterValue;

        public void ExecuteInstruction(Instruction instruction)
        {
            CheckLargestTotalValue();

            var valueToCompare = GetRegisterValue(instruction.RegisterToCheck);

            if (ShouldManipulate(valueToCompare, instruction.Operator, instruction.ValueToCompareWith))
            {
                var oldValue = GetRegisterValue(instruction.RegisterToManipulate);

                var newValue = ManipulateValue(
                    oldValue, instruction.TypeOfManipulation,
                    instruction.ValueToManipulateWith);

                _registers[instruction.RegisterToManipulate] = newValue;
            }
        }

        private void CheckLargestTotalValue()
        {
            if (_registers.Values.Count == 0) return;

            var largestValue = _registers.Values?.Max();

            if (largestValue > _largestTotalRegisterValue)
                _largestTotalRegisterValue = (int) largestValue;
        }

        private int ManipulateValue(
            int oldValue,
            string instructionTypeOfManipulation,
            int instructionValueToManipulateWith)
        {
            if (instructionTypeOfManipulation == "inc")
                return oldValue + instructionValueToManipulateWith;
            if (instructionTypeOfManipulation == "dec")
                return oldValue - instructionValueToManipulateWith;
            return 0;
        }

        private bool ShouldManipulate(int valueToCompare, string instructionOperator, int instructionValueToCompareWith)
        {
            switch (instructionOperator)
            {
                case ">":
                    return valueToCompare > instructionValueToCompareWith;
                case "<":
                    return valueToCompare < instructionValueToCompareWith;
                case ">=":
                    return valueToCompare >= instructionValueToCompareWith;
                case "==":
                    return valueToCompare == instructionValueToCompareWith;
                case "<=":
                    return valueToCompare <= instructionValueToCompareWith;
                case "!=":
                    return valueToCompare != instructionValueToCompareWith;
                default: return false;
            }
        }

        private int GetRegisterValue(string register)
        {
            _registers.TryGetValue(register, out var value);
            return value;
        }

        public MaxRegisterValueModel MaxRegisterValue()
        {
            return new MaxRegisterValueModel
            {
                LargestFinalRegisterValue = _registers.Values.Max(),
                LargestTotalRegisterValue = _largestTotalRegisterValue
            };
        }
    }
}