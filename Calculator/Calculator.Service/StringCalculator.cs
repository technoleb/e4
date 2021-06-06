using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Service
{
    public class StringCalculator
    {
        public int StringAdd(string strNumber)
        {
            int result = 0;
            if (!string.IsNullOrEmpty(strNumber))
            {
                List<int> lstNum = new List<int>();

                if (!string.IsNullOrEmpty(strNumber))
                {
                    var isMinus = false;
                    foreach (char c in strNumber)
                    {

                        if ((c >= '0' && c <= '9'))
                        {
                            if (isMinus)
                            {
                                lstNum.Add(int.Parse("-" + c.ToString()));

                            }
                            else
                            {
                                lstNum.Add(int.Parse(c.ToString()));
                            }
                            isMinus = false;
                        }

                        if (isMinus)
                        {
                            isMinus = false;
                        }
                        if (c == '-')
                        {
                            isMinus = true;
                        }
                    }

                    if (lstNum.Where(x => x < 0).Count() > 0)
                    {
                        var negativeNumbers = string.Join(",", lstNum.Where(x => x < 0).Select(x => x.ToString()).ToArray());
                        throw new FormatException($"negatives not allowed '{negativeNumbers}'");
                    }
                    else
                    {
                        result = lstNum.Sum();
                    }
                }
            }
            return result;
        }
    }
}
