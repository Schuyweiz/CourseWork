using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMath;
using System.IO;
namespace Coursework5
{
    static class LatexToImage
    {
        /// <summary>
        /// Transforms latex text expression of a problem
        /// into a formula PNG
        /// new line to test how git works
        /// </summary>
        /// <param name="texExpression"></param>
        /// <returns></returns>
        public static string MakeFormulaImage(string path,string texExpression)
        {
            
            var parser = new TexFormulaParser();
            var formula = parser.Parse(texExpression);

            var pngByte = formula.RenderToPng(17, 1, 1, "Arial");

            File.WriteAllBytes(path, pngByte);

            return path;


        }
    }
}
