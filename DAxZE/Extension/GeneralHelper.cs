namespace DAxZE.Extension
{
    internal class GeneralHelper
    {
        /// <summary>
        /// 查找字符串中间的字符串
        /// </summary>
        /// <param name="str">查找的字符串</param>
        /// <param name="str1">前面的字符串</param>
        /// <param name="str2">后面的字符串</param>
        /// <returns></returns>
        public static string FindBetweenString(string str, string str1, string str2)
        {
            int n1, n2;
            n1 = str.IndexOf(str1, 0) + str1.Length;
            n2 = str.IndexOf(str2, n1);
            return n1 > n2 ? str : str.Substring(n1, n2 - n1);
        }

    }
}
