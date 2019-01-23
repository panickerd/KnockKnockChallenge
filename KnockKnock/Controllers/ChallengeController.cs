using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace KnockKnock.Controllers
{
    [Route("api/7537f01e-cc2f-4d5e-b3d3-03f37ab25260")]
    public class ChallengeController : Controller
    {
        /// <summary>
        /// Returns the nth fibonacci number
        /// </summary>
        /// <param name="n">number</param>
        /// <returns>nTh fibonacci number</returns>
        [HttpGet("Fibonacci")]
        public ActionResult GetFibonacciNumber([Required] long n)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "The request is invalid." });
            }

            if (n > 92 || n < -92)
            {
                return BadRequest("no content");
            }

            if (n == 0)
            {
                return Ok(0);
            }
            else if ((n == 1) || (n == 2) || (n == -1) || (n == -2))
            {
                return Ok(1);
            }
            else
            {
                long sign = n / Math.Abs(n) * (n % 2 == 0 ? 1 : -1);                
                n = Math.Abs(n);
                long no1 = 1, no2 = 1, result = 0, counter = 2;
                while (counter < n)
                {
                    result = no1 + no2;
                    no1 = no2;
                    no2 = result;
                    counter++;
                }

                return Ok(result * sign);
            }
        }

        /// <summary>
        /// Reverses the letters of each word in a sentence
        /// </summary>
        /// <param name="sentence">sentence</param>
        /// <returns>reverse string</returns>
        [HttpGet("ReverseWords")]
        public ActionResult GetReverseWords(string sentence)
        {
            string result = string.Join(" ", sentence
                .Split(' ').Select(x => new String(x.Reverse().ToArray())));
            return Ok(result);
        }

        /// <summary>
        /// Your token
        /// </summary>
        /// <returns>token guid</returns>
        [HttpGet("Token")]
        public ActionResult GetToken()
        {
            return Ok(new Guid("7537f01e-cc2f-4d5e-b3d3-03f37ab25260"));
        }

        /// <summary>
        /// Returns the type of triange given the lengths of its sides.
        /// </summary>
        /// <param name="a">side a</param>
        /// <param name="b">side b</param>
        /// <param name="c">side c</param>
        /// <returns>triange type</returns>
        [HttpGet("TriangleType")]
        public ActionResult GetTriangleType([Required] int a, [Required] int b, [Required] int c)
        {
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "The request is invalid." });
            }
            if (a + b > c && a + c > b && b + c > a)
            {
                int[] sides = new int[3] { a, b, c };
                int count = sides.GroupBy(x => x).Count();
                if (count == 1)
                {
                    result = "Equilateral";
                }
                else if (count == 2)
                {
                    result = "Isosceles";
                }
                else
                {
                    result = "Scalene";
                }
            }
            else
            {
                result = "Error";
            }

            return Ok(result);
        }
    }
}