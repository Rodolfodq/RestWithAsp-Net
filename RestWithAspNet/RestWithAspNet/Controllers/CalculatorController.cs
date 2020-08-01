using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase        
    {
        //GET api/values/sum/5/5
        [HttpGet("sum/{firstnumber}/{secondnumber}")]
        public IActionResult Sum(string firstnumber, string secondnumber)
        {
            if(IsNumeric(firstnumber) && IsNumeric(secondnumber))
            {
                var sum = ConvertToDecimal(firstnumber) + ConvertToDecimal(secondnumber);
                return Ok(sum.ToString());
            }            
            return BadRequest("Invalid Input");
        }

        //GET api/values/sub/5/5
        [HttpGet("sub/{firstnumber}/{secondnumber}")]
        public IActionResult Sub(string firstnumber, string secondnumber)
        {
            if(IsNumeric(firstnumber) && IsNumeric(secondnumber))
            {
                var sub = ConvertToDecimal(firstnumber) - ConvertToDecimal(secondnumber);
                return Ok(sub.ToString());
            }
            return BadRequest("Invalid Input");
        }

        //GET api/values/mult/5/5
        [HttpGet("mult/{firstnumber}/{secondnumber}")]
        public IActionResult Mult(string firstnumber, string secondnumber)
        {
            if (IsNumeric(firstnumber) && IsNumeric(secondnumber))
            {
                var mult = ConvertToDecimal(firstnumber) * ConvertToDecimal(secondnumber);
                return Ok(mult.ToString());
            }
            return BadRequest("Invalid Input");
        }

        //GET api/values/div/5/5
        [HttpGet("div/{firstnumber}/{secondnumber}")]
        public IActionResult Div(string firstnumber, string secondnumber)
        {
            if (IsNumeric(firstnumber) && IsNumeric(secondnumber))
            {
                if (ConvertToDecimal(secondnumber) > 0)
                {
                    var div = ConvertToDecimal(firstnumber) / ConvertToDecimal(secondnumber);
                    return Ok(div.ToString());
                }
                return BadRequest("Indivisible by zero");

            }
            return BadRequest("Invalid Input");
        }

        //GET api/values/mult/5/5
        [HttpGet("mean/{firstnumber}/{secondnumber}")]
        public IActionResult Mean(string firstnumber, string secondnumber)
        {
            if (IsNumeric(firstnumber) && IsNumeric(secondnumber))
            {
                var mean = (ConvertToDecimal(firstnumber) + ConvertToDecimal(secondnumber))/2;
                return Ok(mean.ToString());
            }
            return BadRequest("Invalid Input");
        }

        //GET api/values/squareroot/5
        [HttpGet("squareroot/{number}")]
        public IActionResult SquareRoot(string number)
        {
            if (IsNumeric(number))
            {
                var squareRoot = Math.Sqrt((double)ConvertToDecimal(number));
                return Ok(squareRoot.ToString());
            }
            return BadRequest("Invalid Input");
        }
        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;
            if (decimal.TryParse(number, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }


    }
}