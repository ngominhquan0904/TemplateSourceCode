using System;
using System.IO;

namespace WindowServiceTemplate
{
    public class Utility
    {
        /// <summary>
        /// use a special escape sequence to specify the delimiter character.
        /// </summary>
        /// <param name="inputForHL7"></param>
        /// <returns></returns>
        public static string EscapeSpecialCharacter(string inputForHL7)
        {
            string output = string.Empty;

            if (!string.IsNullOrEmpty(inputForHL7))
            {
                output = inputForHL7;
                output = output.Replace(@"\", @"\E\"); // this must be first
                output = output.Replace("&", @"\T\");
                output = output.Replace("^", @"\S\");
                output = output.Replace("|", @"\F\");
                output = output.Replace("~", @"\R\");
            }
            return output;
        }
        public static string GetHL7OrderFileName(string patientId, DateTimeOffset PointOfTime)
        {
            const char paddingChar = '0';
            const int fixedLength = 2;
            string timeStamp = string.Format("{0}{1}{2}{3}{4}{5}", PointOfTime.Year,
                PointOfTime.Month.ToString().PadLeft(fixedLength, paddingChar),
                PointOfTime.Day.ToString().PadLeft(fixedLength, paddingChar),
                PointOfTime.Hour.ToString().PadLeft(fixedLength, paddingChar),
                PointOfTime.Minute.ToString().PadLeft(fixedLength, paddingChar),
                PointOfTime.Second.ToString().PadLeft(fixedLength, paddingChar));

            string fileName = string.Format("O_{0}_{1}.DAT", timeStamp, patientId);
            fileName = MakeValidFileName(fileName);
            return fileName;
        }
        private static string MakeValidFileName(string fileName)
        {
            return string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));
        }
    }
}