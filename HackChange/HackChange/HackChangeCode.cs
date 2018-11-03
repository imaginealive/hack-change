using System;
using System.Collections.Generic;
using System.IO;

namespace HackChange
{
    public class ChangeOut
    {
    }
    public class HackChangeCode
    {
        public new Dictionary<string, string> Change(int amout, int payment)
        {
            var data = new Dictionary<string, string>();

            if (payment - amout < 0)
            {
                data.Add("Note", "เงินไม่พอ");
                return data;
            }
            var sum = payment - amout;
            data.Add("Note", string.Empty);
            data.Add("Change", sum.ToString());

            sum = BillCalculate(sum, 1000, data);
            sum = BillCalculate(sum, 500, data);
            sum = BillCalculate(sum, 100, data);
            sum = BillCalculate(sum, 50, data);
            sum = BillCalculate(sum, 20, data);
            sum = BillCalculate(sum, 5, data);
            sum = BillCalculate(sum, 1, data);

            return data;
        }
        
        private static int BillCalculate(int sum, int billValue, Dictionary<string, string> data)
        {
            var value = sum / billValue;
            data.Add("Bill" + billValue, value.ToString());
            sum -= billValue * value;
            return sum;
        }

    }
}
